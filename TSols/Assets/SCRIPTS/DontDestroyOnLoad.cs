using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoad : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    public void ChangeToNextScene(string next_scene, string LoadingScene)
    {
        SceneManager.LoadScene(LoadingScene);
        SceneManager.LoadSceneAsync(next_scene);
    }
}
