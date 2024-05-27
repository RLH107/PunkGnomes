using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WawesControl : MonoBehaviour
{
    //Lists Of Lists
    private List<List<GameObject>> LOfObjLs; // List Of GameOjectcts Lists
    private List<List<int>> LOfIntLs; // List Of IntegerNumbers Lists


    //Wawes Lists
    private List<List<GameObject>> InstantiatedObjects_OrWawes_ListOfLists;

    //Lists within List of Lists
    private List<GameObject> L_Obj;
    private List<int> L_Int;

    public void InsWawes()
    {
        StartWawesSistemTest();
        Instantiate_AllObjects_InListOfLists();  
    }

    private void StartWawesSistemTest()
    {
        //Lists Can Not be 0
        if (LOfObjLs.Count == 0)
        {
            Debug.LogError("GameObj ListOfLists can not be null");
        }
        if (LOfIntLs.Count == 0)
        {
            Debug.LogError("Int ListOfLists can not be null");
        }

        //Sees if Information In lists maches
        if (LOfObjLs.Count != LOfIntLs.Count)
        {
            Debug.LogError("The Lists Of Lists Info does not match _Information Is Missing");
        }

        //For every List in ListOfLists
        for (int i = 0; i < LOfObjLs.Count; i++)
        {
            //gets Lists From ListsOfLists
            L_Obj = LOfObjLs[i];
            L_Int = LOfIntLs[i];            
            //Sees if Information In lists maches
            if (L_Obj.Count != L_Int.Count)
            {
                Debug.LogError("Lists In ListsOfLists Positions " + i + "Info does not match __Information Is Missing");
            }
        }
    }
    private void Instantiate_AllObjects_InListOfLists()
    {
        //Temporary GameObject
        GameObject thisObject;

        //Creates a Temporery List
        List<GameObject> L_Temp;
        L_Temp = new List<GameObject>();

        //For every member in {List Of GameOjectct Lists}
        for (int i = 0;i < LOfObjLs.Count;i++)
        {
            //gets Lists From Lists Of Lists
            L_Obj = LOfObjLs[i];
            L_Int = LOfIntLs[i];

            //For Every member in L_Obj instantiate Objects Requiered
            for (int j = 0; j < L_Obj.Count; j++)
            {
                //For every Quantety in L_Int Instantiate L_Obj[j]
                for (int k = 0; k < L_Int[j]; k++)
                {
                    //thisObject is the Instantiated(L_Obj[j]) Object
                    thisObject = Instantiate(L_Obj[j], new Vector3(0, -100, 0), transform.rotation);
                    // Adds thisObject to Temporary List
                    L_Temp.Add(thisObject);
                }
            }
            //Adds Temporary List To {InstantiatedObjects_OrWawes_ListOfLists}
            InstantiatedObjects_OrWawes_ListOfLists.Add(L_Temp);
            //Clears All Information From Temporary List
            L_Temp.Clear();
        }
    }

    public void NumberOfWawes(int Number)
    {
        for(int i = 0; i < Number; i++)
        {
            LOfObjLs[i] = new List<GameObject>();
            LOfIntLs[i] = new List<int>();
        }
    }
    

    public void AddGameObjToListOfLists(int WhatListToAddTo, GameObject GO)
    {
        LOfObjLs[WhatListToAddTo].Add(GO);
    }
    public void AddToIntListOfLists(int WhatListToAddTo, int Int)
    {
        List<int> LIO = LOfIntLs[WhatListToAddTo];
        LIO.Add(Int);
    }
    
    //Return members?
    /*

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

    */
}
