using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo_Base : MonoBehaviour
{
    [SerializeField] private int Health;
    [SerializeField] private int Attack;
    [SerializeField] private float Speed;
    [SerializeField] private bool ActivationState;
    void Start()
    {
    //https://forum.unity.com/threads/toggling-on-off-update-event.270879/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
