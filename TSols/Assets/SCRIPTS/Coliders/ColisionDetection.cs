using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionDetection : MonoBehaviour
{
    [SerializeField] private GameObject Enemy;

    Inimigo_Base Inimigo_Base_Script;

    private void Start()
    {
        Inimigo_Base_Script = Enemy.GetComponent<Inimigo_Base>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "TurnColider")
        {
            Inimigo_Base_Script.ColisionDetect(other.gameObject);
        }
    }
}
