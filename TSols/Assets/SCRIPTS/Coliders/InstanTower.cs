using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static TButon;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class InstanTower : MonoBehaviour
{
    //////////////////////// NEW_SISTEM

    private GameObject[] Towers;
    private int[] Prices;
    public List<TodasTorres> TodasTorres_ScriptsList;


    /// <summary>
    /// ////////// OLD_SISTEM
    /// </summary>

    // External Information
    [SerializeField] private Transform InsPOS;
    [SerializeField] private MeshRenderer Mesh;


    ////// Internal Information
    private SelectTower SelectTower_Script;
    private LevelRecorce LevelRecorce_Script;
    private TButon Tbuton_Script;
    private LevelMenues LevelMenues_Script;

    // private Script ThisTower;
    private TodasTorres Tower_Script1;

    // Current Script Beeing Used
    private TodasTorres Tower_Script;

    // Starting pos of the tower
    private Vector3 StartingPos1;

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
    private int DeactivationPrice;

    //Button Can be pressed
    private bool IsActive;
    private bool BeforeActivation;

    void Start()
    {
        GameObject levelMeneger = GameObject.Find("LevelMeneger");
        SelectTower_Script = levelMeneger.GetComponent<SelectTower>();
        LevelRecorce_Script = levelMeneger.GetComponent<LevelRecorce>();
        Tbuton_Script = levelMeneger.GetComponent<TButon>();
        LevelMenues_Script = levelMeneger.GetComponent<LevelMenues>();

        Vibration.Init();

        ThisTower1 = Instantiate(TowerPrefab_1, new Vector3(InsPOS.position.x + 10, InsPOS.position.y -5, InsPOS.position.z), Quaternion.identity);

        for (int i = 0; i < Towers.Length; i++)
        {

        }


        Tower_Script1 = ThisTower1.GetComponent<TodasTorres>();

        Tower_Script = Tower_Script1;
        TPrice = T1_price;


        StartingPos1 = ThisTower1.transform.position;


        StartingPos = StartingPos1;

        IsActive = false;
        TowerState = false;
        TowerChange = false;
        BeforeActivation = false;

        LevelMenues_Script.LisenStartLevelMenu += ResetTower;
        LevelMenues_Script.LisenStartLevelMenu += BrforeActivation;
        LevelMenues_Script.LisenPlayLevelMenu += ActivateButton;

        SelectTower_Script.ListenToNewTower += NewTower;


        Tbuton_Script.butonDelegate += SetMesh;
        //int ChangeNext
    }

    public void NewTower()
    {

    }

    public void BrforeActivation()
    {
        BeforeActivation = true;
        Debug.Log("Hã? BeforeActivation = " + BeforeActivation);
    }

    public void ActivateButton()
    {
        Debug.Log("ActivateButton");
        if (BeforeActivation == true)
        {
            Debug.Log("BEFORE-ACTIVE = " + BeforeActivation);
            StartCoroutine(TimerToZero());
            BeforeActivation = false;
            IsActive = true;
        }
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
        //Debug.Log("SetMesh Called");
        Mesh.enabled = !Mesh.enabled;
    }

    public void Touched(/* bool TowerState, TodasTorres Tower_Script, Vector3 StartingPos */)
    {
        DeactivationPrice = TPrice / 4;
        bool Used = false;
        if(IsActive == true)
        {
            if (timer > 0)
            {
                //Debug.Log("StillPressed");
                //Debounce Timer Reset
                timer = 0.05f;
            }
            if (timer <= 0)
            {
                if (LevelRecorce_Script.ReturnCurrentResorce() >= DeactivationPrice)
                {
                    Vibration.VibratePop();
                    //If Tower Is Active -> Deactivate Tower
                    if (TowerState == true && Used == false)
                    {
                        LevelRecorce_Script.PayResorce(DeactivationPrice);
                        Tower_Script.MoveTower(StartingPos);
                        TowerState = false;
                        Used = true;

                        if (TowerChange == true)
                        {
                            TowerChange = false;
                            switchTower(ChangeNext);
                        }
                    }
                }
                if (LevelRecorce_Script.ReturnCurrentResorce() >= TPrice)
                {
                    //If Tower Is Inactive -> Activate Tower
                    if (TowerState == false && Used == false)
                    {
                        LevelRecorce_Script.PayResorce(TPrice);
                        Tower_Script.MoveTower(InsPOS.position);
                        TowerState = true;
                        Used = true;
                    }
                }
                //Debounce Timer Start
                //timer = 0.05f;
                StartCoroutine(TimerToZero());
            }
        }
    }

    public void ResetTower()
    {
        if (TowerState == true)
        {
            Tower_Script.MoveTower(StartingPos);
            TowerState = false;
            IsActive = false;
            switchTower(0);
        }
    }

    IEnumerator TimerToZero()
    {
        timer = 0.05f;
        while (timer > 0)
        {
            yield return null;
            timer = timer - Time.deltaTime;
            //Debug.Log("Timer = " + timer);
        }
    }
}
