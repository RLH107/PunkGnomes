using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSceneChange : MonoBehaviour
{
    [SerializeField] private string LoadingScene;
    [SerializeField] private string NextScene;

    private GameObject DoNotDestroyObject;
    DontDestroyOnLoad DontDestroyOnLoad_SCRIPT;

    private void Start()
    {
        DoNotDestroyObject = GameObject.Find("DoNotDestroy");
        DontDestroyOnLoad_SCRIPT = DoNotDestroyObject.GetComponent<DontDestroyOnLoad>();
    }
    public void OnButtonClick_ChangeScene()
    {
        Debug.Log("ButtonPressed");
        DontDestroyOnLoad_SCRIPT.ChangeToNextScene(NextScene,LoadingScene);
    }
}
