using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class React : MonoBehaviour
{
    private void Start()
    {
        Vibration.Init();
    }

    public void Touched()
    {
        GetComponent<Renderer>().material.color = new Color(Random.value,Random.value,Random.value,1.0f);
        Debug.Log("Touched");
        Vibration.VibratePop();
    }
}
