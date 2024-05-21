using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private float WallHealth;

    Inimigo_Base Inimigo_BaseScript;

    private void Start()
    {
        WallHealth = 8;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Tower")
        {
            if (other.gameObject.tag == "ENEMY")
            {
                Inimigo_BaseScript = other.GetComponent<Inimigo_Base>();
                Inimigo_BaseScript.TakeDamege(80f);
                TakeDamege(1);
            }
        }
    }

    public void TakeDamege(float DemegeTaken)
    {
        WallHealth -= DemegeTaken;
        Debug.Log("EnemyHealth = " + WallHealth);
        if (WallHealth <= 0)
        {
            //Change Scene To Lose
        }
    }
}
