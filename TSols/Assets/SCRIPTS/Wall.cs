using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    Inimigo_Base Inimigo_BaseScript;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Tower")
        {
            if (other.gameObject.tag == "ENEMY")
            {
                Inimigo_BaseScript = other.GetComponent<Inimigo_Base>();
                Inimigo_BaseScript.TakeDamege(80f);
            }
        }
    }
}
