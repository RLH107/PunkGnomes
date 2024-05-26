using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WawesControl : MonoBehaviour
{
    private List<List<GameObject>> LOfObjLs; // List Of GameOjectcts Lists
    private List<List<int>> LOfIntLs; // List Of IntegerNumbers Lists
    private GameObject Test;



    public void StartWawesSistemTest()
    {

    }

    public void AddToGOListOfLists(int WhatListToAddTo, GameObject GO)
    {
        List<GameObject> LGO = LOfObjLs[WhatListToAddTo];
        LGO.Add(GO);
    }
    public void AddToIntListOfLists(int WhatListToAddTo, int Int)
    {
        List<int> LIO = LOfIntLs[WhatListToAddTo];
        LIO.Add(Int);
    }

    private GameObject GetGameObjectInListOfLists(int ListOfListPos, int PosInList)
    {
        List<GameObject> LGO = LOfObjLs[ListOfListPos];
        return LGO[PosInList];
    }
    private int GetIntInListOfList(int ListOfListPos, int PosInList)
    {
        List<int> LIO = LOfIntLs[ListOfListPos];
        return LIO[PosInList];
    }
}
