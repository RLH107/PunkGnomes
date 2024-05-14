using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionDetection : MonoBehaviour
{
    //external Information
    [SerializeField] private GameObject Enemy;
    public GameObject Target {get; private set;}

    //internal Working
    bool called;
    private int x;
    Inimigo_Base Inimigo_Base_Script;

    private void Start()
    {
        x = 0;
        called = false;
        Inimigo_Base_Script = Enemy.GetComponent<Inimigo_Base>(); 
    }

    public void GiveObjectForList()
    {
    }

    public void FirstTarget()
    {
        if (called == false)
        {
            Inimigo_Base_Script.NewTarget(Target);
            called = true;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Detector Detects Coision");
        if (other.gameObject.tag == "TurnColider")
        {
            x++;
            Inimigo_Base_Script.NewTarget(Target);
        }
    }
}
