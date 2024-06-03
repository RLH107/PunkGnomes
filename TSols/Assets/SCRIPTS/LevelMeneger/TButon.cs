using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TButon : MonoBehaviour
{
    public delegate void TButonDelegate();
    public TButonDelegate butonDelegate;

    public void RunDelegate()
    {
        if (butonDelegate != null)
        {
            butonDelegate();
        }
    }
}
