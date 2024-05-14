using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsEnemy : MonoBehaviour
{
    //external Information
    [SerializeField] private GameObject EnemyPrefab;
    [SerializeField] private int NumberOfEnemysToInstantiate;
    [SerializeField] private float ChangeZ;
    [SerializeField] public List<GameObject> TurnColidersList { get; private set;}
    //intrnal Information
    private GameObject TurnColider;
    private float PosChange;
    ColisionDetection CurrentColisionDetection_Script;
    
    // Start is called before the first frame update
    void Start()
    {
        PosChange = 0;
        for (int i = 0; i < NumberOfEnemysToInstantiate; i++)
        {
            GameObject Enemy = Instantiate(EnemyPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z -PosChange),transform.rotation);
            PosChange = PosChange + ChangeZ;
            CurrentColisionDetection_Script = Enemy.GetComponentInChildren<ColisionDetection>();
            
            for (int j = 0; j < TurnColidersList.Count; j++)
            {
                Debug.Log("Is This Working? " + TurnColidersList[j]);
                TurnColider = TurnColidersList[j];
                Debug.Log("j " + j);
                Debug.Log("Turncolider = " + TurnColider);
                CurrentColisionDetection_Script.GiveObjectForList();
            }
            CurrentColisionDetection_Script.FirstTarget();
        }
    }
}
