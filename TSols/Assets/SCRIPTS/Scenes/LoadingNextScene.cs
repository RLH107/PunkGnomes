using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingNextScene : MonoBehaviour
{
    private string NextScene;
    private GameObject DoNotDestroyObject;
    DontDestroyOnLoad DontDestroyOnLoad_SCRIPT;

    // Start is called before the first frame update
    void Start()
    {
        DoNotDestroyObject = GameObject.Find("DoNotDestroy");
        DontDestroyOnLoad_SCRIPT = DoNotDestroyObject.GetComponent<DontDestroyOnLoad>();

        if (DontDestroyOnLoad_SCRIPT != null)
        {
            NextScene = DontDestroyOnLoad_SCRIPT.NextSceneName();
            if (NextScene != null)
            {
                SceneManager.LoadSceneAsync(NextScene);
            }
        }
    }
}
