using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurningColiderList : MonoBehaviour
{
    //external Information
    [SerializeField] private List<GameObject> TurnColidersList;

    //intrnal Information

    public GameObject GetObjectsFromColiderList(int ListPos)
    {
        return TurnColidersList[ListPos];
    }
    //InsEnemy_Script.GetObjectsFromColiderList(x);

    public int ReturnNumberOfObjectsInColiderList()
    {
        return TurnColidersList.Count;
    }
    //InsEnemy_Script.ReturnNumberOfObjectsInColiderList();
}
