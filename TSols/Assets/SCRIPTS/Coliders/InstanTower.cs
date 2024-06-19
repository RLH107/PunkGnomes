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
    public List<Vector3> TowerStartingPosList;


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

        for (int i = 0; i < Towers.Length; i++)
        {
            GameObject InsTower = Instantiate(Towers[i], new Vector3(InsPOS.position.x + 10, InsPOS.position.y - 5 - 1 * i, InsPOS.position.z), Quaternion.identity);
            TodasTorres Torre_Script = InsTower.GetComponent<TodasTorres>();
            TodasTorres_ScriptsList.Add(Torre_Script);
            TowerStartingPosList.Add(InsTower.transform.position);
        }

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
                    Tower_Script = TodasTorres_ScriptsList[0];
                    StartingPos = TowerStartingPosList[0];
                    TPrice = Prices[0];
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
                    Tower_Script = TodasTorres_ScriptsList[1];
                    StartingPos = TowerStartingPosList[1];
                    TPrice = Prices[1];
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
                    Tower_Script = TodasTorres_ScriptsList[2];
                    StartingPos = TowerStartingPosList[2];
                    TPrice = Prices[2];
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
                    Tower_Script = TodasTorres_ScriptsList[3];
                    StartingPos = TowerStartingPosList[3];
                    TPrice = Prices[3];
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
