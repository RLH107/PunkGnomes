using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelRecorce : MonoBehaviour
{
    [SerializeField] private int Initial_RES_count;
    [SerializeField] private int Max_RES_count;
    [SerializeField] private float N_of_Seconds_before_next_addition;
    [SerializeField] private int N_of_Passive_Increce;
    private int RES_count;
    private float NofSbA;
    void Start()
    {
        RES_count = 0;
        NofSbA = N_of_Seconds_before_next_addition;
    }

    void Update()
    {
        if( RES_count >= Max_RES_count || RES_count == Max_RES_count)
        {
            Debug.Log("MAX_NUMBER_OF_RES is " + Max_RES_count);
        }
        else
        {
            if (NofSbA > 0)
            {
                NofSbA -= Time.deltaTime;
            }
            else
            {
                RES_count += N_of_Passive_Increce;
                NofSbA = N_of_Seconds_before_next_addition;
            }
        }
        print("NumberOf_RES" +  RES_count);
    }
}