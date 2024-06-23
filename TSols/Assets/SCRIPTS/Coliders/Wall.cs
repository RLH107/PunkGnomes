using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Wall : MonoBehaviour
{
    [SerializeField] private LevelMenues LevelMenues_Script;
    [SerializeField] private EnemyTags EnemyTags_Script;
    [SerializeField] private float WallHealthStart;
    [SerializeField] private TMP_Text HPtext;

    private float WallHealth;
    private Inimigo_Base Inimigo_BaseScript;

    private void Start()
    {
        WallHealth = WallHealthStart;
        HPtext.text = WallHealth.ToString();
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
                    TakeDamege(Inimigo_BaseScript.ReturnDeamege());
                }
            }
        }
    }

    public void TakeDamege(float DemegeTaken)
    {
        WallHealth -= DemegeTaken;
        HPtext.text = WallHealth.ToString();
        if (WallHealth <= 0)
        {
            //Change Scene To Lose
            LevelMenues_Script.ChangeMenu(3);
        }
    }

    public void ResetWall()
    {
        WallHealth = WallHealthStart;
        HPtext.text = WallHealth.ToString();
    }
}
