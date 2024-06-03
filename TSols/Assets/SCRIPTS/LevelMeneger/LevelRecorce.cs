using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class LevelRecorce : MonoBehaviour
{
    [SerializeField] private int Initial_RES_count;
    [SerializeField] private int Max_RES_count;
    [SerializeField] private float N_of_Seconds_before_next_addition;
    [SerializeField] private int N_of_Passive_Increce;
    [SerializeField] private TMP_Text REStext;
    private int RES_count;
    private int RES_sheck;
    private float NofSbA;
    void Start()
    {
        RES_count = Initial_RES_count;
        NofSbA = N_of_Seconds_before_next_addition;
    }

    void Update()
    {
        if( RES_count >= Max_RES_count || RES_count == Max_RES_count)
        {
            //Debug.Log("MAX_NUMBER_OF_RES is " + Max_RES_count);
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
                Debug.Log("NumberOf_RES" + RES_count);
            }
        }
        REStext.text = RES_count.ToString();

    }
    public void PayResorce(int NumberToSubtract)
    {
        RES_sheck = RES_count;
        RES_sheck -= NumberToSubtract;
        if(RES_sheck >= 0 || RES_sheck == 0)
        {
            RES_count -= NumberToSubtract;
        }
        else
        {
            Debug.Log("Insuficiant Recorces");
        }
    }
    public void AddResorce(int NumberToAdd)
    {
        RES_sheck = RES_count;
        RES_sheck += NumberToAdd;
        if(RES_sheck >= Max_RES_count)
        {
            RES_count = Max_RES_count;
            Debug.Log("Can Not Pass Max_RES_count" + RES_count);
        }
        if (RES_sheck == Max_RES_count)
        {
            RES_count += NumberToAdd;
            Debug.Log("RES_count = Max_RES_count");
        }
        else
        {
            RES_count += NumberToAdd;
            Debug.Log("RES Added");
        }
    }

    public int ReturnCurrentResorce()
    {
        return RES_count;
    }
}