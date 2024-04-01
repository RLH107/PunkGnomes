using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    [SerializeField] private string LoadingScene;

    public void ChangeScene(string NameOfTheNewScene)
        {
            SceneManager.LoadScene(LoadingScene);
            SceneManager.LoadSceneAsync(NameOfTheNewScene);
        }
}
