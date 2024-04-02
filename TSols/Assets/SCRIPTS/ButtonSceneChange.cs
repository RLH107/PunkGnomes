using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        //Adiciona a procima cena no DoNotDestroy
        SceneManager.LoadScene(LoadingScene);
    }
}
