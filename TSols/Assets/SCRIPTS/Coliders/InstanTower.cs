using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static TButon;

public class InstanTower : MonoBehaviour
{
    // External Information
    [SerializeField] private GameObject TowerPrefab_1;
    [SerializeField] private int T1_price;
    [SerializeField] private GameObject TowerPrefab_2;
    [SerializeField] private int T2_price;
    [SerializeField] private GameObject TowerPrefab_3;
    [SerializeField] private int T3_price;
    [SerializeField] private GameObject TowerPrefab_4;
    [SerializeField] private int T4_price;

    [SerializeField] private Transform InsPOS;
    [SerializeField] private MeshRenderer Mesh;


    ////// Internal Information
    private SelectTower SelectTower_Script;
    private LevelRecorce LevelRecorce_Script;
    private TButon Tbuton_Script;

    private GameObject ThisTower1;
    private GameObject ThisTower2;
    private GameObject ThisTower3;
    private GameObject ThisTower4;

    // private Script ThisTower;
    private TodasTorres Tower_Script1;
    private TodasTorres Tower_Script2;
    private TodasTorres Tower_Script3;
    private TodasTorres Tower_Script4;

    // Current Script Beeing Used
    private TodasTorres Tower_Script;

    // Starting pos of the tower
    private Vector3 StartingPos1;
    private Vector3 StartingPos2;
    private Vector3 StartingPos3;
    private Vector3 StartingPos4;

    // Current pos Beeing Used
    private Vector3 StartingPos;

    // Is Tower There?
    private bool TowerState;
    // Do I Have to chenge Tower?
    private bool TowerChange;
    // What Tower to Change next?
    private int ChangeNext;

    private int TPrice;

    //Timer For Button Debounce
    private float timer;

    void Start()
    {
        GameObject levelMeneger = GameObject.Find("LevelMeneger");
        SelectTower_Script = levelMeneger.GetComponent<SelectTower>();
        LevelRecorce_Script = levelMeneger.GetComponent<LevelRecorce>();
        Tbuton_Script = levelMeneger.GetComponent<TButon>();

        Vibration.Init();

        ThisTower1 = Instantiate(TowerPrefab_1, new Vector3(InsPOS.position.x + 10, InsPOS.position.y -5, InsPOS.position.z), Quaternion.identity);
        ThisTower2 = Instantiate(TowerPrefab_2, new Vector3(InsPOS.position.x + 10, InsPOS.position.y -10, InsPOS.position.z), Quaternion.identity);
        ThisTower3 = Instantiate(TowerPrefab_3, new Vector3(InsPOS.position.x + 10, InsPOS.position.y -15, InsPOS.position.z), Quaternion.identity);
        ThisTower4 = Instantiate(TowerPrefab_4, new Vector3(InsPOS.position.x + 10, InsPOS.position.y -20, InsPOS.position.z), Quaternion.identity);

        //is not used1      ThisTower = ThisTower1;


        Tower_Script1 = ThisTower1.GetComponent<TodasTorres>();
        Tower_Script2 = ThisTower2.GetComponent<TodasTorres>();
        Tower_Script3 = ThisTower3.GetComponent<TodasTorres>();
        Tower_Script4 = ThisTower4.GetComponent<TodasTorres>();

        Tower_Script = Tower_Script1;
        TPrice = T1_price;


        StartingPos1 = ThisTower1.transform.position;
        StartingPos2 = ThisTower2.transform.position;
        StartingPos3 = ThisTower3.transform.position;
        StartingPos4 = ThisTower4.transform.position;

        StartingPos = StartingPos1;


        TowerState = false;
        TowerChange = false;

        Tbuton_Script.butonDelegate += SetMesh;
        //int ChangeNext
    }


    private void switchTower(int Tower)
    {
        switch (Tower)
        {
            case 0:
                if(TowerState == false)
                {
                    Tower_Script = Tower_Script1;
                    StartingPos = StartingPos1;
                    TPrice = T1_price;
                }
                if(TowerState == true)
                {
                    ChangeNext = Tower;
                    TowerChange = true;
                }
                break;
            case 1:
                if (TowerState == false)
                {
                    Tower_Script = Tower_Script2;
                    StartingPos = StartingPos2;
                    TPrice = T2_price;
                }
                if (TowerState == true)
                {
                    ChangeNext = Tower;
                    TowerChange = true;
                }
                break;
            case 2:
                if (TowerState == false)
                {
                    Tower_Script = Tower_Script3;
                    StartingPos = StartingPos3;
                    TPrice = T3_price;
                }
                if (TowerState == true)
                {
                    ChangeNext = Tower;
                    TowerChange = true;
                }
                break;
            case 3:
                if (TowerState == false)
                {
                    Tower_Script = Tower_Script4;
                    StartingPos = StartingPos4;
                    TPrice = T4_price;
                }
                if (TowerState == true)
                {
                    ChangeNext = Tower;
                    TowerChange = true;
                }
                break;
        }
    }

    public void CallSwitsh()
    {
        int i;
        //switchTower(SelectTower_Script.NextTowerN);
        i = SelectTower_Script.RetuenTowerN();
        switchTower(i);
    }

    public void SetMesh()
    {
        Debug.Log("SetMesh Called");
        Mesh.enabled = !Mesh.enabled;
    }

    public void Touched(/* bool TowerState, TodasTorres Tower_Script, Vector3 StartingPos */)
    {
        bool Used = false;
        if (timer > 0)
        {
            //Debug.Log("StillPressed");
            //Debounce Timer Reset
            timer = 0.05f;
        }
        if (timer <= 0)
        {
            if (LevelRecorce_Script.ReturnCurrentResorce() >= TPrice)
            {
                Vibration.VibratePop();
                //If Tower Is Active -> Deactivate Tower
                if (TowerState == true && Used == false)
                {
                    Tower_Script.MoveTower(StartingPos);
                    TowerState = false;
                    Used = true;

                    if (TowerChange == true)
                    {
                        TowerChange = false;
                        switchTower(ChangeNext);
                    }
                }


                //If Tower Is Inactive -> Activate Tower
                if (TowerState == false && Used == false)
                {
                    Tower_Script.MoveTower(InsPOS.position);
                    TowerState = true;
                    Used = true;
                }
            }

            //Debounce Timer Start
            timer = 0.05f;
            StartCoroutine(TimerToZero());
        }
    }
    
    IEnumerator TimerToZero()
    {
        while (timer > 0)
        {
            yield return null;
            timer = timer - Time.deltaTime;
            //Debug.Log("Timer = " + timer);
        }
    }
}
