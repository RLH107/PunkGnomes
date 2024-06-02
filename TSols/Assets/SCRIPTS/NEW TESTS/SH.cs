using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SH : MonoBehaviour
{
    private GameObject[] TowerPrefabs;

    private int NextTowerN;
    public void SetTower(int TowerN)
    {
        NextTowerN = TowerN;
    }
}
