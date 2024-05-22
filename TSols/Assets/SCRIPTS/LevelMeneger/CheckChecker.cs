using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckChecker : MonoBehaviour
{
    // External Information
    [SerializeField] private int ButtonNumber;
    [SerializeField] private Image CheckMarker;
    [SerializeField] private SelectTower SelectTower_Script;

    // Internal Information
    private int WhatButton;


    public void Change_CheckMarker()
    {
        WhatButton = SelectTower_Script.RetuenTowerN();
        
        if (ButtonNumber == WhatButton)
        {
            CheckMarker.enabled = true;
        }
        if (ButtonNumber != WhatButton)
        {
            CheckMarker.enabled = false;
        }
    }
}
