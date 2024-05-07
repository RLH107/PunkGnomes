using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionDetection : MonoBehaviour
{
    [SerializeField] private GameObject Enemy;

    public List<GameObject> TurnColiders;
    public GameObject LastTarget;
    private int x;

    Inimigo_Base Inimigo_Base_Script;

    private void Start()
    {
        x = 0;
        Inimigo_Base_Script = Enemy.GetComponent<Inimigo_Base>();

        Inimigo_Base_Script.TurnEnemy(TurnColiders[x].gameObject);
        x++;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "TurnColider")
        {
            //Debug.Log("Triggered");
            if (x >= TurnColiders.Count)
            {
                Inimigo_Base_Script.TurnEnemy(LastTarget.gameObject);
            }
            else
            {
                Inimigo_Base_Script.TurnEnemy(TurnColiders[x].gameObject);
            }
            x++;
        }
    }
}
