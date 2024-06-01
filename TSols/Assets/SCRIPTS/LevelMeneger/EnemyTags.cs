using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTags : MonoBehaviour
{
    [SerializeField] private string[] EnemyTags_Array;
    private string EnemyTag;

    public int ReturnEnemyTags_Length()
    {
        return EnemyTags_Array.Length;
    }

    public string ReturnEnemyTags (int EnemyTagPosInArray)
    {
        if (EnemyTagPosInArray > EnemyTags_Array.Length)
        {
            Debug.LogWarning("EnemyTagPosInArray Does Not Exist Returning Last TAG added. ENEMY TAG POS REQUESTED = " + EnemyTagPosInArray);
            EnemyTagPosInArray = EnemyTags_Array.Length;
        }

        EnemyTag = EnemyTags_Array[EnemyTagPosInArray];
        return EnemyTag;
    }
}
