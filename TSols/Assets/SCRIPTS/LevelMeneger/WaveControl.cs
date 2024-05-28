using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WaveControl : MonoBehaviour
{
    [SerializeField] private Transform TransformPos;

    [Tooltip("Lists need to have the same size. Every Row in the lists is a Wave. If you do not want a enemy in that wave leve it at 0")]
    [SerializeField] public List<int> BacicEnemy1Number;
    [Tooltip("Lists need to have the same size. Every Row in the lists is a Wave. If you do not want a enemy in that wave leve it at 0")]
    [SerializeField] public List<int> BacicEnemy2Number;


    //Internal Working
    List<GameObject> BacicEnemy1Pool;
    List<GameObject> BacicEnemy2Pool;

    List<GameObject> ActiveList;

    Inimigo_Base Inimigo_BaseScript;

    void Start()
    {
        //Adds Enemys to BacicEnemyPoolList
        BacicEnemy1Pool = GameObject.FindGameObjectsWithTag("ENEMY").ToList();
    }

    private void CallWave(int WaveNumber)
    {
        GameObject AddOrRemove;
        ////make a Wawe
        
        //Wave Number Can not Be Bigger then Pool List
        if(BacicEnemy1Pool.Count < WaveNumber)
        {
            Debug.LogError("ToBig AHHHHHHHHH");
            WaveNumber = BacicEnemy1Pool.Count;
        }
        //Get Object from Pool List
        for(int i = 0; i < BacicEnemy1Pool.Count; i++)
        {
            AddOrRemove = BacicEnemy1Pool[0];
            ActiveList.Add(AddOrRemove);
            BacicEnemy1Pool.Remove(AddOrRemove);

            //Do the same for other Lists
            //
        }
        //place these objects on the track 
        for(int i = 0; i < ActiveList.Count; i++)
        {
            Inimigo_BaseScript = ActiveList[i].GetComponent<Inimigo_Base>();

            //TransformPos = TransformPos + new Vector3( 0, 0, )

            Inimigo_BaseScript.MoveEnemyToANewPosition(TransformPos.position);

            Inimigo_BaseScript.ActivateEnemy();
        }
    }
    // if Enemy Is destroyed add to respective pool List
}
