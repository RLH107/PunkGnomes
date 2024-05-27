using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaweMaker : MonoBehaviour
{
    [SerializeField] WawesControl Wawes_Script;
    [SerializeField] private GameObject prefab_1;
    [SerializeField] private GameObject prefab_2;
    [SerializeField] private GameObject prefab_3;
    [SerializeField] private GameObject prefab_4;

    void Start()
    {
        Wawes_Script.NumberOfWawes(1);
        Wawes_Script.AddGameObjToListOfLists(0, prefab_1);

        Wawes_Script.InsWawes();
    }

}
