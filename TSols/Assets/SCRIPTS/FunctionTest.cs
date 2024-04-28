using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionTest : MonoBehaviour
{
    private GameObject Enemy;
    Inimigo_Base Inimigo_Base_Script;

    private float T_F1;
    private float T_F2;
    private bool T1 = true;
    private bool T2 = true;
    // Start is called before the first frame update
    void Start()
    {
        Enemy = GameObject.FindWithTag("ENEMY");
        Inimigo_Base_Script = Enemy.GetComponent<Inimigo_Base>();
        T_F1 = 5;
        T_F2 = 28;
    }

    private void Update()
    {
        T_F1 -= Time.deltaTime;
        T_F2 -= Time.deltaTime;
        if (T_F1 == 0 && T1 == true || T_F1 <= 0 && T1 == true)
        {
            Inimigo_Base_Script.ActivationState = true;
            T1 = false;
        }
        if (T_F2 == 0 && T2 == true || T_F2 <= 0 && T2 == true)
        {

            T2 = false;
        }
    }
}
