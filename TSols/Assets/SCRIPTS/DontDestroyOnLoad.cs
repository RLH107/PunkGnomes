using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
    //Public Info.

    [HideInInspector] public string ERROR_SCENE;

    private void Start()
    {
        Debug.Log("Next Scene to be Loaded" + ERROR_SCENE);
    }
}
