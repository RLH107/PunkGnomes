using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class InstanTower : MonoBehaviour
{
    private bool Tower;
    [SerializeField] private GameObject TowerPrefab;
    [SerializeField] private Transform InsPOS;
    private TodasTorres TowerScript;
    private GameObject ThisTower;
    private float TCD;
    // Start is called before the first frame update
    void Start()
    {
        Vibration.Init();
        TCD = 0;
        ThisTower = Instantiate(TowerPrefab, new Vector3(InsPOS.position.x, InsPOS.position.y /*-50*/ , InsPOS.position.z), Quaternion.identity);
        TowerScript = ThisTower.GetComponent<TodasTorres>();
    }


    public void Touched()
    {
        if (TCD <= 0)
        {
            Vibration.VibratePop();
            TowerScript.MoveTower(new Vector3(InsPOS.position.x, InsPOS.position.y, InsPOS.position.z));
            TCD = 1;
        }
        else
        {
            TCD = 1;
        }
        TCD = TCD - Time.deltaTime;
    }




}
