using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Void_Function_Test : MonoBehaviour
{
    [SerializeField] private GameObject LevelMeneger;
    LevelRecorce LevelRecorce_Script;
    private float T_F1;
    private float T_F2;
    private bool T1 = true;
    private bool T2 = true;
    // Start is called before the first frame update
    void Start()
    {
        LevelRecorce_Script = LevelMeneger.GetComponent<LevelRecorce>();
        T_F1 = 5;
        T_F2 = 28;
    }

    // Update is called once per frame
    void Update()
    {
        T_F1 -= Time.deltaTime;
        T_F2 -= Time.deltaTime;
        if(T_F1 == 0 && T1 == true || T_F1 <= 0 && T1 == true)
        {
            LevelRecorce_Script.PayResorce(5);
            T1 = false;
        }
        if (T_F2 == 0 && T2 == true || T_F2 <= 0 && T2 == true)
        {
            LevelRecorce_Script.AddResorce(5);
            T2 = false;
        }
    }
}
