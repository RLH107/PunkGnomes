using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class InstanTower : MonoBehaviour
{
    [SerializeField] private GameObject TowerPrefab;
    [SerializeField] private Transform InsPOS;
    [SerializeField] private float ReactionCooldown;
    private float ReactCD_Number;
    private TodasTorres TowerScript;
    private GameObject ThisTower;
    private bool Tower;
    // Start is called before the first frame update
    void Start()
    {
        Vibration.Init();
        ReactCD_Number = 0f;
        Tower = false;
        ThisTower = Instantiate(TowerPrefab, new Vector3(InsPOS.position.x, InsPOS.position.y -50 , InsPOS.position.z), Quaternion.identity);
        TowerScript = ThisTower.GetComponent<TodasTorres>();

        Debug.Log("ReactCD_Number " + ReactCD_Number);
        Debug.Log("ReactionCooldown " + ReactionCooldown);
    }
    private void FixedUpdate()
    {
        if (ReactCD_Number > 0)
        {
            ReactCD_Number = ReactCD_Number - Time.deltaTime;
            Debug.Log("ReactCD_Number " + ReactCD_Number);
        }
    }

    public void Touched()
    {
        if (ReactCD_Number <= 0 && Tower == false)
        {
            Debug.Log("INS_T IF_");
            ReactCD_Number = ReactionCooldown;
            Debug.Log("ReactCD_Number " + ReactCD_Number);

            Vibration.VibratePop();
            TowerScript.MoveTower(InsPOS.position);

        }


    }
}
