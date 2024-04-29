using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TodasTorres : MonoBehaviour
{
    [SerializeField] private float PCoolDown;
    [SerializeField] private float PSpeed;
    [SerializeField] private float Range;
    [HideInInspector] public List<GameObject> EnemysList;
    private enum TState
    {
        IDLE,
        AIM,
    }
    void Start()
    {
        
    }
    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        EnemysList.Add(other.gameObject);
    }
    private void OnTriggerExit(Collider other)
    {
        
    }

    private void Dead()
    {

    }
}
