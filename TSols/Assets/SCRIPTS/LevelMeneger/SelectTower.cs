using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SelectTower : MonoBehaviour
{
    [SerializeField] public GameObject[] Towers;
    [SerializeField] public int[] Prices;




    // Delegate
    public delegate void TowerChangeHandler();
    public TowerChangeHandler ListenToNewTower;
    public TowerChangeHandler ListenToNewCheck;

    // Internal Information
    private int NextTowerN;

    public void SetTower(int TowerN)
    {
        NextTowerN = TowerN;
        BeforeInvoke();
    }
    private void BeforeInvoke()
    {
        ListenToNewTower();
        ListenToNewCheck();
    }
    public int RetuenTowerN()
    {
        return NextTowerN;
    }
    public GameObject[] ReturnTowerArray()
    {
        return Towers;
    }
    public int[] ReturnTowerPriceArray()
    {
        return Prices;
    }
}