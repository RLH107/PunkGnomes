using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo_Base : MonoBehaviour
{
    [SerializeField] private string EnemyTipe;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform orientation;

    public bool ActivationState;
    private bool PreActive;

    [SerializeField] private float RSpeed;
    [SerializeField] private float Health;
    [SerializeField] private float MaxHealth;
    [SerializeField] private float Attack;
    [SerializeField] private float MoveSpeed;
    [SerializeField] private float MoveForce;


    private Vector3 StartingPos;
    private Quaternion StartingRot;
    private Vector3 CurrentVel;
    private Quaternion RotateTo;
    

    /// <summary>
    /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    
    private enum EState
    {
        IDLE,
        MOVE,
        TURN,
        STOP,
    }
    private EState enemyState;


    /// <summary>
    /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    /// <param name="Start"></param>


    void Start()
    {
        StartingPos = transform.position + new Vector3(0, -10, 0);
        StartingRot = transform.rotation;
        rb.freezeRotation = true;

        if (Health <= 0f)
        {
            Health = 50f;
        }

        if (MaxHealth <= 0f)
        {
            MaxHealth = 55f;
        }

        if (Attack <= 0f)
        {
            Attack = 5f;
        }

        if (MoveSpeed <= 0f)
        {
            MoveSpeed = 2f;
        }

        if (MoveForce <= 0f)
        {
            MoveForce = 1f;
        }

        RSpeed = 0.1f;

        ActivationState = true;
        PreActive = true;
        RotateTo = transform.rotation;
        EnemyStateSwitch(EState.IDLE);
    }

    void Update()
    {
        if (ActivationState == false)
        {
            PreActive = true;
        }
        if (ActivationState == true && PreActive == true)
        {
            PreActive = false;
            EnemyStateSwitch(EState.MOVE);
        }
    }

    /// <summary>
    /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    /// <param name="DemegeTaken"></param>


    public void TakeDamege(float DemegeTaken)
    {
        //Debug.Log("TakeDamge_CALLED");
        Health -= DemegeTaken;
        if (Health <= 0)
        {
            Dead();
        }
    }

    private void AddHealth(float HealthToAdd)
    {
        //Debug.Log("addHealth_CALLED");
        float 
        HealthCheck = Health;
        HealthCheck += HealthToAdd;
        if(HealthCheck < MaxHealth)
        {
            //Debug.Log("If_CALLED");
            Health += HealthToAdd;
        }
        else
        {
            //Debug.Log("Else_CALLED");
            Health = MaxHealth;
        }
    }
    private void Dead()
    {
        //Debug.Log(gameObject + "DEAD");
        ActivationState = false;
        EnemyStateSwitch(EState.IDLE);
        transform.position = StartingPos;
        transform.rotation = StartingRot;
    }
    /// <summary>
    /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    /// <param name="collision"></param>

    public void ColisionDetect(GameObject other)
    {
        if (other.gameObject.tag == "TurnColider")
        {
            //Debug.Log("Colision Detected");
            RotateTo = other.gameObject.transform.rotation;
        }
    }


    /// <summary>
    /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    /// <param name="StateSwitch"></param>


    private void EnemyStateSwitch(EState E_State)
    {
        enemyState = E_State;
        switch (enemyState)
        {
            case EState.IDLE:
                Debug.Log("IDLE");
                StartCoroutine(IDLE());
                break;
            case EState.MOVE:
                Debug.Log("MOVE");
                StartCoroutine(MOVE());
                break;
            case EState.TURN:
                Debug.Log("TURN");
                StartCoroutine(TURN());
                break;
            case EState.STOP:
                Debug.Log("STOP");
                StartCoroutine(STOP());
                break;
        }
    }

    /// <summary>
    /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    /// <param name="IEnumerators"></param>

    private IEnumerator IDLE()
    {
        //Debug.Log("IDLE Called");
        yield return null;
        if (ActivationState == true)
        {
            //Debug.Log("ActivationState" + ActivationState);
            rb.constraints = RigidbodyConstraints.None;
            EnemyStateSwitch(EState.MOVE);
        }
        if (ActivationState == false)
        {
            rb.constraints = RigidbodyConstraints.FreezePosition;
        }
    }

    private IEnumerator MOVE()
    {
        yield return null;

        //Get Velocity x and z 
        CurrentVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        
        if (ActivationState == false)
        {
            EnemyStateSwitch(EState.STOP);
        }

        //Check if velocity is less then speed
        if (CurrentVel.magnitude < MoveSpeed && ActivationState == true)
        {
            //Force Forward
            rb.AddForce(orientation.forward * MoveForce, ForceMode.Force);
        }
        //Check if velocity exeeds speed
        if (CurrentVel.magnitude > MoveSpeed && ActivationState == true)
        {
            //Calculates speed limit
            Vector3 LimitedSpeed = CurrentVel.normalized * MoveSpeed;
            //Limits speed
            rb.velocity = new Vector3(LimitedSpeed.x, rb.velocity.y, LimitedSpeed.z);
        }
        //Checks for Exit Condition
        if (RotateTo != orientation.rotation)
        {
            EnemyStateSwitch(EState.STOP);
        }
        else
        {
            EnemyStateSwitch(EState.MOVE);
        }
    }

    private IEnumerator STOP()
    {
        yield return null;

        CurrentVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);


        //Slows down Movement
        rb.AddForce(orientation.forward * -MoveForce, ForceMode.Acceleration);
        //Checks if speed is Slow
        if (rb.velocity.magnitude < 0.5f)
        {
            //Stops
            rb.velocity = new Vector3(0, 0, 0);
        }
        //Exit Clauses
        if (rb.velocity.magnitude == 0)
        {
            if (ActivationState == false)
            {
                EnemyStateSwitch(EState.IDLE);
            }
            if (orientation.rotation == RotateTo && ActivationState == true)
            {
                EnemyStateSwitch(EState.MOVE);
            }
            if (orientation.rotation != RotateTo && ActivationState == true)
            {
                EnemyStateSwitch(EState.TURN);
            }
        }
        else
        {
            EnemyStateSwitch(EState.STOP);
        }
    }

    private IEnumerator TURN()
    {
        yield return null;
        //Rotates
        orientation.rotation = Quaternion.RotateTowards(orientation.rotation, RotateTo, RSpeed * 100);

        if (RotateTo == orientation.rotation)
        {
            EnemyStateSwitch(EState.MOVE);
        }
        else
        {
            EnemyStateSwitch(EState.TURN);
        }
    }
    
}
