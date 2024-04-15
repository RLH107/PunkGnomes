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

    void Start()
    {
        Health = 50f;
        MaxHealth = 55f;
        Attack = 5f;
        Speed = 10f;
        ActivationState = false;

        Debug.Log(Health);

        AddHealth(10f);

        Debug.Log(Health);

        TakeDamege(15f);

        Debug.Log(Health);
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
}
