using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo_Base : MonoBehaviour
{
    [SerializeField] private string EnemyTipe;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform orientation;

    [SerializeField] private float RSpeed;
    [SerializeField] private float Health;
    [SerializeField] private float MaxHealth;
    [SerializeField] private float Attack;
    [SerializeField] private float MoveSpeed;
    [SerializeField] private float MoveForce;
    [SerializeField] private float AngleBeforeMove;

    [SerializeField] private bool ActivationState;
    private Vector3 StartingPos;
    private Vector3 targetDirection;
    private Quaternion StartingRot;
    private Quaternion TurnTo;
    private GameObject Target;


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
        StartingPos = transform.position + new Vector3(0, -10, 0); //Change Later
        StartingRot = transform.rotation;
        rb.freezeRotation = true;
        ActivationState = true; // Change Later
        TurnTo = transform.rotation;

        EnemyStateSwitch(EState.IDLE);
    }

    /// <summary>
    /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    /// <param name="DemegeTaken"></param>


    public void TakeDamege(float DemegeTaken)
    {
        Health -= DemegeTaken;
        if (Health <= 0)
        {
            DeactivateEnemy();
        }
    }

    public void AddHealth(float HealthToAdd)
    {
        float HealthCheck = Health;

        HealthCheck += HealthToAdd;
        if (HealthCheck < MaxHealth)
        {
            Health += HealthToAdd;
        }
        else
        {
            Health = MaxHealth;
        }
    }

    public void ActivateEnemy()
    {
        if (ActivationState == false)
        {
            ActivationState = true;
            EnemyStateSwitch(EState.IDLE);
        }
    }

    public void DeactivateEnemy()
    {
        if (ActivationState)
        {
            StopAllCoroutines();
            ActivationState = false;
            EnemyStateSwitch(EState.IDLE);
        }
    }

    public void TurnEnemy(GameObject NextTarget)
    {
        Target = NextTarget;
        targetDirection = Target.transform.position - transform.position;
    }




    /// <summary>
    /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    /// <param name="collision"></param>

    private void OnCollisionEnter(Collision collision)
    {

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

        if (ActivationState == false)
        {
            transform.position = StartingPos;
            transform.rotation = StartingRot;
            rb.constraints = RigidbodyConstraints.FreezePosition;
        }
        if (ActivationState == true)
        {
            //Debug.Log("ActivationState" + ActivationState);
            rb.constraints = RigidbodyConstraints.None;
            rb.freezeRotation = true;
            EnemyStateSwitch(EState.MOVE);
        }
    }

    private IEnumerator MOVE()
    {
        yield return null;

        //REWRITE CODE
        TurnTo = Quaternion.LookRotation(targetDirection, Vector3.up);

        while (TurnTo == orientation.rotation)
        {
            TurnTo = Quaternion.LookRotation(targetDirection, Vector3.up);
            Vector3 CurrentVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
            if (CurrentVel.magnitude < MoveSpeed)
            {
                //Force Forward
                rb.AddForce(orientation.forward * MoveForce, ForceMode.Force);
            }

            if (CurrentVel.magnitude > MoveSpeed)
            {
                //Calculates speed limit
                Vector3 LimitedSpeed = CurrentVel.normalized * MoveSpeed;

                //Limits speed
                rb.velocity = new Vector3(LimitedSpeed.x, rb.velocity.y, LimitedSpeed.z);
            }



            yield return new WaitForEndOfFrame();
        }
        //End OF Loop

        //Corutine Exit Clauses
        if (TurnTo != orientation.rotation)
        {
            EnemyStateSwitch(EState.STOP);
        }


        ///REWRITE
    }

    private IEnumerator STOP()
    {

        yield return null;


        //While loop
        while (rb.velocity.magnitude != 0)
        {
            //Slows down Movement
            rb.AddForce(orientation.forward * -1, ForceMode.Acceleration);
            //Checks if speed is Slow
            if (rb.velocity.magnitude < 0.5f)
            {
                //Stops
                rb.velocity = new Vector3(0, 0, 0);
            }
            //Waits For End Of Frame
            yield return new WaitForEndOfFrame();
        }
        //End OF Loop

        //Corutine Exit Clauses

        if (rb.velocity.magnitude == 0)
        {
            EnemyStateSwitch(EState.TURN);
        }

        ////REWRITE


    }

    private IEnumerator TURN()
    {
        yield return null;


        targetDirection = Target.transform.position - transform.position;
        TurnTo = Quaternion.LookRotation(targetDirection, Vector3.up);

        while (TurnTo != orientation.rotation)
        {
            targetDirection = Target.transform.position - transform.position;
            TurnTo = Quaternion.LookRotation(targetDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(orientation.rotation, TurnTo, RSpeed);
            yield return new WaitForEndOfFrame();
        }
        //End OF Loop

        //Corutine Exit Clauses

        if (TurnTo == orientation.rotation)
        {
            EnemyStateSwitch(EState.MOVE);
        }

        ////Rewrite


    }

}
