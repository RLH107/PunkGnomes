using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaweMaker_Scrapped : MonoBehaviour
{
    [SerializeField] WawesControl_Scrapped Wawes_Script;
    [SerializeField] private GameObject prefab_1;
    [SerializeField] private GameObject prefab_2;
    [SerializeField] private GameObject prefab_3;
    [SerializeField] private GameObject prefab_4;

    //Internal List
    List<GameObject> G_Obj;
    List<int> EnemyNumbers;

    void Start()
    {
        /*
        G_Obj = new List<GameObject> { prefab_1, prefab_2 };
        EnemyNumbers = new List<int> { 3, 1 };
        */
    }

    public int ReturnListSize(string ListName)
    {

        return 1;
    }

}
