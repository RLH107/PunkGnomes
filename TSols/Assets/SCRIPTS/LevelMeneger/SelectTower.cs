using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SelectTower : MonoBehaviour
{
    public bool Tower_1 { get; private set; }
    public bool Tower_2 { get; private set; }
    public bool Tower_3 { get; private set; }
    public bool Tower_4 { get; private set; }



    // Start is called before the first frame update
    void Start()
    {
        SetTower_1_Bool();
    }

    public void SetTower_1_Bool()
    {
        Tower_2 = false;
        Tower_3 = false;
        Tower_4 = false;
        Tower_1 = true;
    }
    public void SetTower_2_Bool()
    {
        Tower_1 = false;
        Tower_3 = false;
        Tower_4 = false;
        Tower_2 = true;

    }
    public void SetTower_3_Bool()
    {
        Tower_2 = false;
        Tower_1 = false;
        Tower_4 = false;
        Tower_3 = true;

    }
    public void SetTower_4_Bool()
    {
        Tower_2 = false;
        Tower_3 = false;
        Tower_1 = false;
        Tower_4 = true;

    }
}