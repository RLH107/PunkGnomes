using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil : MonoBehaviour
{
    [SerializeField] private float Velocidade_Do_Projetil;
    [SerializeField] private float Dano_Do_Projetil;
    public Projectile_STATE STATE;

    public enum Projectile_STATE
    {
        Projectile_Active,
        Projectile_Inactive,
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StateSwitch(Projectile_STATE State)
    {
        STATE = State;
        switch (STATE)
        {
            case Projectile_STATE.Projectile_Active:
                break;
            case Projectile_STATE.Projectile_Inactive:
                break;
        }
    }
}
