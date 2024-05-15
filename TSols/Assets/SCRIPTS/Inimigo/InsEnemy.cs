using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsEnemy : MonoBehaviour
{
    //external Information
    [SerializeField] private GameObject EnemyPrefab;
    [SerializeField] private int NumberOfEnemysToInstantiate;
    [SerializeField] private float ChangeZ;
    [SerializeField] private List<GameObject> TurnColidersList;

    //intrnal Information
    private GameObject Enemy;
    private GameObject TurnColider;
    private float PosChange;
    ColisionDetection CurrentColisionDetection_Script;
    
    // Start is called before the first frame update
    void Start()
    {
        PosChange = 0;
        for (int i = 0; i < NumberOfEnemysToInstantiate; i++)
        {
            Enemy = Instantiate(EnemyPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z -PosChange),transform.rotation);
            PosChange = PosChange + ChangeZ;
            CurrentColisionDetection_Script = Enemy.GetComponentInChildren<ColisionDetection>();
        }
    }

    public GameObject GetObjectsFromColiderList(int ListPos)
    {
        return TurnColidersList[ListPos];
    }
    //InsEnemy_Script.GetObjectsFromColiderList(x);

    public int ReturnNumberOfObjectsInColiderList()
    {
        return TurnColidersList.Count;
    }
    //InsEnemy_Script.ReturnNumberOfObjectsInColiderList();
}
