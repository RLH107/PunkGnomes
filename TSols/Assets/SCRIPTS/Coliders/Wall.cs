using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private EnemyTags EnemyTags_Script;


    private float WallHealth;
    private string EnemyTag;
    private Inimigo_Base Inimigo_BaseScript;

    private void Start()
    {
        WallHealth = 50;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Tower")
        {
            for(int i = 0; i < EnemyTags_Script.ReturnEnemyTags_Length(); i++)
            {
                if(other.gameObject.tag == EnemyTags_Script.ReturnEnemyTags(i))
                {
                    Inimigo_BaseScript = other.GetComponent<Inimigo_Base>();
                    Inimigo_BaseScript.TakeDamege(80f);
                    TakeDamege(1);
                }
            }
        }
        
//////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////
        /*
        if (other.gameObject.tag != "Tower")
        {
            if (other.gameObject.tag == "ENEMY")
            {
                Inimigo_BaseScript = other.GetComponent<Inimigo_Base>();
                Inimigo_BaseScript.TakeDamege(80f);
                TakeDamege(1);
            }
        }
        */
    }

    public void TakeDamege(float DemegeTaken)
    {
        WallHealth -= DemegeTaken;
        Debug.Log("Wall Health = " + WallHealth);
        if (WallHealth <= 0)
        {
            //Change Scene To Lose
        }
    }
}
