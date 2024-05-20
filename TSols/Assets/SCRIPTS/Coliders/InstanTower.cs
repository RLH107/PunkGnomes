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

    //Timer For Button Debounce
    private float timer;

    void Start()
    {
        Vibration.Init();

        ThisTower = Instantiate(TowerPrefab, new Vector3(InsPOS.position.x, InsPOS.position.y -5, InsPOS.position.z), Quaternion.identity);
        Tower_Script = ThisTower.GetComponent<TodasTorres>();
        StartingPos = ThisTower.transform.position;
        TowerState = false;
    }
    
    public void Touched()
    {
        if (timer <= 0)
        {
            Debug.Log("Timer = "+timer);
            Vibration.VibratePop();
            // If Pressed ////////////////////////////
            
            //If Tower Is Inactive -> Activate Tower
            if (TowerState == false)
            {
                Tower_Script.MoveTower(InsPOS.position);
                Debug.Log("Activating Tower/ TowerPos = "+ ThisTower.transform.position + "InsTransform.position = "+ InsPOS);
                TowerState = true;
                StartCoroutine(TimerToZero());
            }
            //If Tower Is Active -> Deactivate Tower
            if (TowerState == true)
            {
                Tower_Script.MoveTower(StartingPos);
                Debug.Log("Deactivating Tower/ TowerPos = " + ThisTower.transform.position + "Initial Tower Transform.position = " + StartingPos);
                TowerState = false;
            }
            //////////////////////////////////////////
        }
        if (timer > 0)
        {
            Debug.Log("StillPressed");
        }

        timer = 0.05f;
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
