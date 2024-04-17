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

    public void TurnEnemy(float HowMutshToRotate, float HowFast)
    {
        ToRotate = Quaternion.Euler(0, HowMutshToRotate, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, ToRotate, Time.deltaTime * HowFast);
    }

    private void Dead()
    {
        Debug.Log("DEAD");
    }
}
