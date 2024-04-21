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
        yield return null;

    }
    private IEnumerator TURN()
    {
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
