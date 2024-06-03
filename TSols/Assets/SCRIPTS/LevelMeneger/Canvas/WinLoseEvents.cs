using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLoseEvents : MonoBehaviour
{
    public delegate void WinDelegete();
    public WinDelegete winDelegete;

    public delegate void LoseDelegete();
    public LoseDelegete loseDelegete;

    public void CallWin()
    {
        if (winDelegete != null)
        {
            winDelegete();
        }
    }
    public void CallLose()
    {
        if (loseDelegete != null)
        {
            loseDelegete();
        }
    }

    [SerializeField] private GameObject[] StatScreenObjects;
    [SerializeField] private GameObject[] PlayScreenObjects;
    [SerializeField] private GameObject[] EndScreenObjects;

    private void Start()
    {
        SetStatScreen(enabled);
    }



    private void SetStatScreen(bool set)
    {
        for (int i = 0; i < StatScreenObjects.Length; i++)
        {
            StatScreenObjects[i].SetActive(set);
        }
    }
    private void SetPlayScreen(bool set)
    {
        for(int i = 0;i < PlayScreenObjects.Length; i++)
        {
            PlayScreenObjects[i].SetActive(set);
        }
    }
    private void SetEndScreen(bool set)
    {
        for (int i = 0; i < EndScreenObjects.Length; i++)
        {
            EndScreenObjects[i].SetActive(set);
        }
    }
}
