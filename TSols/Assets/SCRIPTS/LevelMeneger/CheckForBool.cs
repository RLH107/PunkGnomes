using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckForBool : MonoBehaviour
{
    [SerializeField] private Image CheckMarker;
    [SerializeField] private SelectTower SelectTower_Script;
    [SerializeField] private int WhatButton;
    public void Marker_1()
    {
        switch (WhatButton)
        {
            case 1:
                if (SelectTower_Script.Tower_1 == true)
                {
                    CheckMarker.enabled = true;
                }
                if (SelectTower_Script.Tower_1 == false)
                {
                    CheckMarker.enabled = false;
                }
                break;

            case 2:
                if (SelectTower_Script.Tower_2 == true)
                {
                    CheckMarker.enabled = true;
                }
                if (SelectTower_Script.Tower_2 == false)
                {
                    CheckMarker.enabled = false;
                }
                break;

            case 3:
                if (SelectTower_Script.Tower_3 == true)
                {
                    CheckMarker.enabled = true;
                }
                if (SelectTower_Script.Tower_3 == false)
                {
                    CheckMarker.enabled = false;
                }
                break;

            case 4:
                if (SelectTower_Script.Tower_4 == true)
                {
                    CheckMarker.enabled = true;
                }
                if (SelectTower_Script.Tower_4 == false)
                {
                    CheckMarker.enabled = false;
                }
                break;
        }
    }

    public void DebugInvoke() 
    {
        Debug.Log("InvokeLog");
    }
}
