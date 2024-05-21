using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SelectTower : MonoBehaviour
{
    [SerializeField] UnityEvent IfBoolChange1;


    public bool Tower_1 { get; private set; }
    public bool Tower_2 { get; private set; }
    public bool Tower_3 { get; private set; }
    public bool Tower_4 { get; private set; }

    public int NextTowerN { get; private set; }



    // Start is called before the first frame update
    void Start()
    {
        Tower_1 = true;
        Tower_2 = false;
        Tower_3 = false;
        Tower_4 = false;
        NextTowerN = 1;
        BeforeInvoke();
    }

    public void SetTower_1_Bool()
    {
        Tower_2 = false;
        Tower_3 = false;
        Tower_4 = false;
        Tower_1 = true;
        NextTowerN = 1;
        BeforeInvoke();
    }
    public void SetTower_2_Bool()
    {
        Tower_1 = false;
        Tower_3 = false;
        Tower_4 = false;
        Tower_2 = true;
        NextTowerN = 2;
        BeforeInvoke();
    }
    public void SetTower_3_Bool()
    {
        Tower_2 = false;
        Tower_1 = false;
        Tower_4 = false;
        Tower_3 = true;
        NextTowerN = 3;
        BeforeInvoke();
    }
    public void SetTower_4_Bool()
    {
        Tower_2 = false;
        Tower_3 = false;
        Tower_1 = false;
        Tower_4 = true;
        NextTowerN = 4;
        BeforeInvoke();
    }

    private void BeforeInvoke()
    {
        Debug.Log("BeforeInvoke");
        Debug.Log("Tower_1"+ Tower_1);
        Debug.Log("Tower_2" + Tower_2);
        Debug.Log("Tower_3" + Tower_3);
        Debug.Log("Tower_4" + Tower_4);
        IfBoolChange1.Invoke();

    }
}