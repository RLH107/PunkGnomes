using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionDetection : MonoBehaviour
{
    //external Information
    [SerializeField] private GameObject Enemy;
    private GameObject Target;

    //internal Working
    private int x;
    private int ListCount;
    Inimigo_Base Inimigo_Base_Script;
    InsEnemy InsEnemy_Script;

    private void Start()
    {
        x = 0;
        Inimigo_Base_Script = Enemy.GetComponent<Inimigo_Base>();
        InsEnemy_Script = GameObject.Find("InsEnemy").GetComponent<InsEnemy>();

        ListCount = InsEnemy_Script.ReturnNumberOfObjectsInColiderList();
        Target = InsEnemy_Script.GetObjectsFromColiderList(x);

        Inimigo_Base_Script.NewTarget(Target);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (x > ListCount)
        {
            Debug.Log("x exeeds List Count");
            x = ListCount;
        }

        //Debug.Log("Detector Detects Coision");
        if (other.gameObject.tag == "TurnColider")
        {
            x++;
            Target = InsEnemy_Script.GetObjectsFromColiderList(x);
            Inimigo_Base_Script.NewTarget(Target);
        }
    }
}
