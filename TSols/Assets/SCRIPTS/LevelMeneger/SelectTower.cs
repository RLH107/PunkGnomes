using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SelectTower : MonoBehaviour
{
    // External Information
    [SerializeField] UnityEvent TowerChange;
    [SerializeField] UnityEvent CheckChange;

    // Internal Information
    private int NextTowerN;

    public void SetTower(int TowerN)
    {
        NextTowerN = TowerN;
        BeforeInvoke();
    }

    private void BeforeInvoke()
    {
        //Debug.Log("BeforeInvoke");
        TowerChange.Invoke();
        CheckChange.Invoke();
    }

    public int RetuenTowerN()
    {
        return NextTowerN;
    }
}