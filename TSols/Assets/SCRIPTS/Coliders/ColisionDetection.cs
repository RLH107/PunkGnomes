using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionDetection : MonoBehaviour
{
    [SerializeField] private GameObject Enemy;

    Inimigo_Base Inimigo_Base_Script;
    TurnInfo TurnInfo_Script;

    private float TimeOfTurn;
    private float HowMutchToTurn;

    private void Start()
    {
        Inimigo_Base_Script = Enemy.GetComponent<Inimigo_Base>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "TurnColider")
        {
            //Debug.Log("Script_Is" + Inimigo_Base_Script);
            //Debug.Log("Object_Is" + other.gameObject);
            TurnInfo_Script = other.gameObject.GetComponent<TurnInfo>();

            //Inimigo_Base_Script.TurnEnemy(TurnInfo_Script.HowMutchToTurn, TurnInfo_Script.HowLongIsTheTurn);
        }
    }
}
