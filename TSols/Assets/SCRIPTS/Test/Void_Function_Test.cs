using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Void_Function_Test : MonoBehaviour
{
    [SerializeField] private GameObject Object;
    [SerializeField] private Transform Transform;
    private float T_F1;
    private float T_F2;
    private bool T1 = true;
    private bool T2 = true;
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        T_F1 = 10;
        T_F2 = 15;
    }

    //Update is called once per frame
    void Update()
    {
        T_F1 -= Time.deltaTime;
        T_F2 -= Time.deltaTime;
        if(T_F1 == 0 && T1 == true || T_F1 <= 0 && T1 == true)
        {
            transform.position = new Vector3(0, 0, 5);
            T1 = false;
        }
        if (T_F2 == 0 && T2 == true || T_F2 <= 0 && T2 == true)
        {
            transform.position = new Vector3(0, 0, 10);
            T2 = false;
        }
    }
}
