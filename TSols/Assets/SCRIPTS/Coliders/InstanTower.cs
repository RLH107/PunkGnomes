using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class InstanTower : MonoBehaviour
{
    //External Information
    [SerializeField] private GameObject TowerPrefab;
    [SerializeField] private Transform InsPOS;

    //Internal Information
    private GameObject ThisTower;
    private TodasTorres Tower_Script;
    private Vector3 StartingPos;
    private bool TowerState;
    private MeshRenderer ThisMesh;

    //Timer For Button Debounce
    private float timer;

    void Start()
    {
        Vibration.Init();

        ThisTower = Instantiate(TowerPrefab, new Vector3(InsPOS.position.x, InsPOS.position.y /*-5*/, InsPOS.position.z), Quaternion.identity);
        Tower_Script = ThisTower.GetComponent<TodasTorres>();
        StartingPos = ThisTower.transform.position;
        TowerState = false;
    }
    
    public void Touched()
    {
        bool Used = false;
        if (timer > 0)
        {
            Debug.Log("StillPressed");
            timer = 0.05f;
        }

        if (timer <= 0)
        {
            Vibration.VibratePop();
            // If Pressed ////////////////////////////

            //If Tower Is Active -> Deactivate Tower
            if (TowerState == true && Used == false)
            {
                Tower_Script.MoveTower(StartingPos);
                TowerState = false;
                Used = true;
            }
            //If Tower Is Inactive -> Activate Tower
            if (TowerState == false && Used == false)
            {
                Tower_Script.MoveTower(InsPOS.position);
                TowerState = true;
                Used = true;
            }
            timer = 0.05f;
            StartCoroutine(TimerToZero());

            //////////////////////////////////////////
        }
    }
    IEnumerator TimerToZero()
    {
        while (timer > 0)
        {
            yield return null;
            timer = timer - Time.deltaTime;
            Debug.Log("Timer = " + timer);
        }
    }
}
