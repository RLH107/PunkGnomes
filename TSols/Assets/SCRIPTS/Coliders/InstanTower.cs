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
    // Start is called before the first frame update
    void Start()
    {
        Vibration.Init();
        ThisTower = Instantiate(TowerPrefab, new Vector3(InsPOS.position.x, InsPOS.position.y /*-50*/ , InsPOS.position.z), Quaternion.identity);
        TowerScript = ThisTower.GetComponent<TodasTorres>();
    }
}
