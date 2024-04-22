using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo_Base : MonoBehaviour
{
    [SerializeField] private string EnemyTipe;
    private float Health;
    private float MaxHealth; 
    private float HealthCheck;
    private float Attack;
    private float Speed;
    private bool ActivationState;

    private Quaternion CurrentRotation;
    private Quaternion ToRotate;


    public enum EState
    {
        IDLE,
        MOVE,
        TURN,
        ATTACK,
        DAMEGE,
    }
    public EState enemyState;

    void Start()
    {
        Health = 50f;
        MaxHealth = 55f;
        Attack = 5f;
        Speed = 10f;
        ActivationState = false;

        CurrentRotation = transform.rotation;
    }



    private void TakeDamege(float DemegeTaken)
    {
        Debug.Log("TakeDamge_CALLED");
        Health -= DemegeTaken;
        if (Health <= 0)
        {
            Dead();
        }
    }

    private void AddHealth(float HealthToAdd)
    {
        Debug.Log("addHealth_CALLED");
        HealthCheck = Health;
        HealthCheck += HealthToAdd;
        if(HealthCheck < MaxHealth)
        {
            Debug.Log("If_CALLED");
            Health += HealthToAdd;
        }
        else
        {
            Debug.Log("Else_CALLED");
            Health = MaxHealth;
        }
    }

    private void Dead()
    {
        Debug.Log("DEAD");
    }

    private void EnemyStateSwitch(EState E_State)
    {
        enemyState = E_State;
        switch (enemyState)
        {
            case EState.IDLE:
                break;
            case EState.MOVE:
                break;
            case EState.TURN:
                break;
            case EState.DAMEGE:
                break;
            case EState.ATTACK:
                break;
        }
    }
    private IEnumerator IDLE()
    {
        Debug.Log("IDLE Called");
        yield return null;
        if (ActivationState == true)
        {
            Debug.Log("ActivationState" + ActivationState);
            EnemyStateSwitch(EState.MOVE);
        }
        else
        {
            Debug.Log("ActivationState" + ActivationState);
            EnemyStateSwitch(EState.IDLE);
        }
    }
    private IEnumerator MOVE()
    {
        Debug.Log("MOVE Called");
        yield return null;
        if(ActivationState == false)
        {
            EnemyStateSwitch(EState.IDLE);
        }
        else
        {
            CurrentRotation = transform.rotation;
            if(CurrentRotation == ToRotate)
            {
                EnemyStateSwitch(EState.MOVE);
            }
            else
            {
                EnemyStateSwitch(EState.TURN);
            }
        }
    }
    private IEnumerator TURN()
    {
        Debug.Log("TURN Called");
        yield return null;
    }
    private IEnumerator DAMEGE()
    {
        yield return null;
    }
    private IEnumerator ATTACK()
    {
        yield return null;
    }

    private void TurnEnemy(float HowMutshToRotate, float HowFast)
    {
        ToRotate = Quaternion.Euler(0, HowMutshToRotate, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, ToRotate, Time.deltaTime * HowFast);
    }
}
