using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private LevelMenues LevelMenues_Script;
    [SerializeField] private EnemyTags EnemyTags_Script;
    [SerializeField] private float WallHealthStart;

    private float WallHealth;
    private string EnemyTag;
    private Inimigo_Base Inimigo_BaseScript;

    private void Start()
    {
        WallHealth = WallHealthStart;
        LevelMenues_Script.LisenStartLevelMenu += ResetWall;
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
                    Inimigo_BaseScript.TakeDamege(100000f);
                    TakeDamege(1);
                }
            }
        }
    }

    public void TakeDamege(float DemegeTaken)
    {
        WallHealth -= DemegeTaken;
        Debug.Log("Wall Health = " + WallHealth);
        if (WallHealth <= 0)
        {
            //Change Scene To Lose
            LevelMenues_Script.ChangeMenu(3);
        }
    }

    public void ResetWall()
    {
        WallHealth = WallHealthStart;
    }
}
