using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo_Base : MonoBehaviour
{
    [SerializeField] private string EnemyTipe;
    [SerializeField] private Rigidbody rb;

    [HideInInspector] public bool ActivationState;

    private float Health;
    private float MaxHealth; 
    private float HealthCheck;
    private float Attack;
    private float Speed;
    private float SpeedVariance;
    private float Force;



    private Vector3 XForce;
    private Vector3 YForce;
    private Vector3 ZForce;
    private Quaternion RotateTo;
    private float RSpeed;

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

        if (Speed <= 0f)
        {
            Speed = 2f;
        }

        if (SpeedVariance <= 0f)
        {
            SpeedVariance = 0.5f;
        }

        if (Force <= 0f)
        {
            Force = 1f;
        }

        RSpeed = 1f;

        //Debug.Log(MinSpeed +"MIN MAX"+  MaxSpeed);

        ActivationState = true;
        XForce = new Vector3(Force, 0, 0);
        YForce = new Vector3(0, Force, 0);
        ZForce = new Vector3(0, 0, Force);
        RotateTo = transform.rotation;
        EnemyStateSwitch(EState.IDLE);
    }


    /// <summary>
    /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    /// <param name="DemegeTaken"></param>


    private void TakeDamege(float DemegeTaken)
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
            EnemyStateSwitch(EState.STOP);
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
                StartCoroutine(IDLE());
                break;
            case EState.MOVE:
                StartCoroutine(MOVE());
                break;
            case EState.TURN:
                StartCoroutine(TURN());
                break;
            case EState.STOP:
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
            EnemyStateSwitch(EState.MOVE);
        }
        else
        {
            //Debug.Log("ActivationState" + ActivationState);
            EnemyStateSwitch(EState.IDLE);
        }
    }


    private IEnumerator MOVE()
    {
        //Debug.Log("MOVE Called");
        yield return null;
        if(ActivationState == false)
        {
            EnemyStateSwitch(EState.STOP);
        }
        else
        {
            if(transform.rotation == RotateTo)
            {
                ///////////////////////////////////////////////////////////////////
                if(rb.velocity.x < Speed)
                {
                    //Debug.Log("Velocity < Speed " + rb.velocity);
                    rb.AddForce( XForce, ForceMode.Acceleration);
                }
                if(rb.velocity.x > Speed)
                {
                    //Debug.Log("Velocity > Speed " + rb.velocity);
                    rb.AddForce(-XForce, ForceMode.Acceleration);
                }
                ///////////////////////////////////////////////////////////////////

                EnemyStateSwitch(EState.MOVE);
            }
            else
            {
                EnemyStateSwitch(EState.STOP);
            }
        }
    }

    private IEnumerator STOP()
    {
        yield return null;
        if (rb.velocity.x == 0 && rb.velocity.y == 0 && rb.velocity.z == 0 && transform.rotation != RotateTo)
        {
            EnemyStateSwitch(EState.TURN);
        }
        if (rb.velocity.x == 0 && rb.velocity.y == 0 && rb.velocity.z == 0 && transform.rotation == RotateTo && ActivationState == true)
        {
            EnemyStateSwitch(EState.MOVE);
        }
        if (rb.velocity.x == 0 && rb.velocity.y == 0 && rb.velocity.z == 0 && transform.rotation == RotateTo && ActivationState == false)
        {
            EnemyStateSwitch(EState.IDLE);
        }

        if (rb.velocity.x <= 1 && rb.velocity.x >= -1)
        {
            rb.velocity = new Vector3( 0, rb.velocity.y, rb.velocity.z);
        }
        if (rb.velocity.y <= 1 && rb.velocity.y >= -1)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        }
        if (rb.velocity.z <= 1 && rb.velocity.z >= -1)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 0);
        }

        ///////////////////////
        if (rb.velocity.x != 0)
        {
            if (rb.velocity.x > 0)
            {
                rb.AddForce(-XForce, ForceMode.Acceleration);
            }
            if (rb.velocity.x < 0)
            {
                rb.AddForce(XForce, ForceMode.Acceleration);
            }
        }
        if (rb.velocity.y != 0)
        {
            if (rb.velocity.x > 0)
            {
                rb.AddForce(-YForce, ForceMode.Acceleration);
            }
            if (rb.velocity.x < 0)
            {
                rb.AddForce(YForce, ForceMode.Acceleration);
            }
        }
        if (rb.velocity.z != 0)
        {
            if (rb.velocity.x > 0)
            {
                rb.AddForce(-ZForce, ForceMode.Acceleration);
            }
            if (rb.velocity.x < 0)
            {
                rb.AddForce(ZForce, ForceMode.Acceleration);
            }
        }
        EnemyStateSwitch(EState.STOP);
    }

    private IEnumerator TURN()
    {
        yield return null;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, RotateTo, RSpeed * Time.deltaTime);
        EnemyStateSwitch(EState.TURN);
    }
    
    //private void TurnEnemy(float HowMutshToRotate, float HowFast)
    //{
    //    ToRotate = Quaternion.Euler(0, HowMutshToRotate, 0);
    //    transform.rotation = Quaternion.Slerp(transform.rotation, ToRotate, Time.deltaTime * HowFast);
    //}
}
