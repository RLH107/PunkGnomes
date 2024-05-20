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
        Debug.Log("This Object Is = "+ gameObject);
        Debug.Log("Tower object = "+ ThisTower);
        Debug.Log("TowerPos = " + ThisTower.transform.position);
        if (timer <= 0)
        {
            Debug.Log("Timer = "+timer);
            Vibration.VibratePop();
            // If Pressed ////////////////////////////
            if (TowerState == false)
            {
                Tower_Script.MoveTower(new Vector3(InsPOS.position.x, InsPOS.position.y, InsPOS.position.z));
                Debug.Log("false = "+ ThisTower.transform.position);
                TowerState = true;
            }
            if (TowerState == true)
            {
                Tower_Script.MoveTower(new Vector3(InsPOS.position.x, InsPOS.position.y - 50, InsPOS.position.z));
                Debug.Log("true = "+ ThisTower.transform.position);
                TowerState = false;
            }
            //////////////////////////////////////////
            StartCoroutine(TimerToZero());
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
