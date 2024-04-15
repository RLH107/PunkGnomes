using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionTest : MonoBehaviour
{
    [SerializeField] private float HowMutshToRotate;
    [SerializeField] private float RotateHowFast;
    Quaternion RotateTo;

    private void Start()
    {
        RotateTo = Quaternion.Euler(0, 0, HowMutshToRotate);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "ENEMY")
        {
            other.gameObject.transform.rotation = Quaternion.Slerp(transform.rotation, RotateTo, Time.deltaTime * RotateHowFast);
            print("FUck Y");
        }
    }
}
