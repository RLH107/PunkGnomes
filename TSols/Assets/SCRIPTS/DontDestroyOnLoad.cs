using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoad : MonoBehaviour
{
    [SerializeField] private string LoadingScene;
    private string NextScene_Name;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    public void ChangeToNextScene(string next_scene)
    {
        NextScene_Name = next_scene;
        SceneManager.LoadScene(LoadingScene);
        //SceneManager.LoadSceneAsync(next_scene);
    }

    public string NextSceneName()
    {
        return NextScene_Name;
    }

}
