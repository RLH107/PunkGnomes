using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WaveControl : MonoBehaviour
{
    [SerializeField] private Transform TransformPOS_ToMoveEnemys;
    //TransformPOS_ToMoveEnemys

    [Tooltip("Lists need to have the same size. Every Row in the lists is a Wave. If you do not want a enemy in that wave leve it at 0")]
    [SerializeField] public List<int> BacicEnemy1Number;
    [Tooltip("Lists need to have the same size. Every Row in the lists is a Wave. If you do not want a enemy in that wave leve it at 0")]
    [SerializeField] public List<int> BacicEnemy2Number;

    //Internal Working


    //Pool_1
    [HideInInspector] public List<GameObject> BacicEnemy1Pool;

    //Pool_2
    [HideInInspector] public List<GameObject> BacicEnemy2Pool;



    //ActiveList
    [HideInInspector] public List<GameObject> ActiveList;

    // I hate that these Lists have to be public. And I dont know why they can not be privete, because I am not Using them in other classesS
    
    private Inimigo_Base Inimigo_BaseScript;
    private GameObject AddOrRemove;
    private int WaveNumber;
    private bool LastWave;

    void Start()
    {
        //Adds Enemys to BacicEnemyPoolList
        BacicEnemy1Pool = GameObject.FindGameObjectsWithTag("ENEMY").ToList();
        BacicEnemy2Pool = GameObject.FindGameObjectsWithTag("BacicEnemy2").ToList();
        LastWave = false;
        CallWave(0);
    }

    private void CallWave(int WaveNumber)
    {
        //  Call Pool 1
        ADD_EnemysFromPool(BacicEnemy1Number[WaveNumber], BacicEnemy1Pool);
        //  Call Pool 2
        ADD_EnemysFromPool(BacicEnemy2Number[WaveNumber], BacicEnemy2Pool);
        //  Call Pool 3

        //  Call Pool 4

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        /////////// Places Objects from ActiveList into the track AND Acitvates them
        //enemy displacement
        int p = 0;
        Vector3 EnemyStartPos;
        // FOR every member in ActiveList
        for (int i = 0; i < ActiveList.Count; i++)
        {
            // Get Script from Object
            Inimigo_BaseScript = ActiveList[i].GetComponent<Inimigo_Base>();
            // Changes Object POS acording to Last Position
            EnemyStartPos = TransformPOS_ToMoveEnemys.position + new Vector3(0, 0, p);
            // Gives new position
            Inimigo_BaseScript.MoveEnemyToANewPosition(EnemyStartPos);
            // Activates enemy
            Inimigo_BaseScript.ActivateEnemy();
            //Changes Enemy Displacement
            p = p - 2;
        }
        if (WaveNumber == BacicEnemy1Number.Count - 1)
        {
            LastWave = true;
            Debug.Log("Last Wave = " +  LastWave);
            // Start a Corutine that Checks active list
            LastWaveEndCheck();
        }
    }


    //Section to add Enemys from selected PoolList to ActiveList
    private void ADD_EnemysFromPool(int numberOfEnemysToPlace, List<GameObject> PoolToGetFrom)
    {
        if(numberOfEnemysToPlace > PoolToGetFrom.Count)
        {
            numberOfEnemysToPlace = PoolToGetFrom.Count;
        }

        for (int i = 0; i < numberOfEnemysToPlace; i++)
        {
            ActiveList.Add(PoolToGetFrom[i]);
        }
    }

    // if Enemy Is destroyed add to respective pool List

    public void IsEnemyDestroyed(GameObject EnemyThatHasBeenDestroyed, int NumberOfTheEnemyPoolList)
    {
        switch (NumberOfTheEnemyPoolList)
        {
            case 1:
                BacicEnemy1Pool.Add(EnemyThatHasBeenDestroyed);
                ActiveList.Remove(EnemyThatHasBeenDestroyed);
                break;
            case 2:
                BacicEnemy2Pool.Add(EnemyThatHasBeenDestroyed);
                ActiveList.Remove(EnemyThatHasBeenDestroyed);
                break;
        }
        Debug.Log("Destroyed Enemy = " + EnemyThatHasBeenDestroyed);
    }

    private IEnumerator LastWaveEndCheck()
    {
        while (ActiveList.Count > 0)
        {
            yield return new WaitForEndOfFrame();
        }
        //Game Over Winn
    }
}
