using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class React2 : MonoBehaviour
{
    private float timer;
    private void Start()
    {
        Vibration.Init();
    }
    public void Touched()
    {
        Debug.Log("Touched");
        if(timer <= 0)
        {
            //Pressed
            Debug.Log("Button Was Pressed");
            GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value);
            Vibration.VibratePop();
            timer = 0.05f;
            StartCoroutine(TimerToZero());
        }
        if(timer > 0)
        {
            //Still Pressed
            Debug.Log("Still Pressed");
        }
        timer = 0.05f;
    }
    IEnumerator TimerToZero()
    {
        while (timer > 0)
        {
            yield return null;
            Debug.Log("timer = " + timer);
            timer = timer - Time.deltaTime;
        }
    }
}
