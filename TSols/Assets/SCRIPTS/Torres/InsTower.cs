using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsTower : MonoBehaviour
{
    [SerializeField] private GameObject TowerPrefab;
    [SerializeField] private Transform TowerPosition;
    private Transform InitialTransform;
    private GameObject Tower;
    private float ChangePos;


    void Start()
    {
        ChangePos = 10;
        Tower = Instantiate(TowerPrefab, new Vector3(transform.position.x +100, transform.position.y - ChangePos, transform.position.z), transform.rotation);
    }


}
