using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChengeScene_SCRIPT : MonoBehaviour
{
    private GameObject DoNotDestroyObject;
    DontDestroyOnLoad DoNotDestroyOnLoad_SCRIPT;
    // Start is called before the first frame update
    void Start()
    {
        DoNotDestroyObject = GameObject.Find("DoNotDestroy");
        if(DoNotDestroyObject == null)
        {
            Debug.Log("GameObject = Null");
        }
        else
        {
            Debug.Log("THE_GAME_OBJECT" + DoNotDestroyObject);
        }
        //SceneManager.LoadSceneAsync(NextScene);
    }
}
