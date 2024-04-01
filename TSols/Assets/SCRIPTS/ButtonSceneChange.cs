using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonSceneChange : MonoBehaviour
{
    [SerializeField] private string NextScene;
    LevelChanger LChanger_Script;

    private void Start()
    {
        LChanger_Script = GetComponent<LevelChanger>();
    }
    public void OnButtonClick_ChangeScene()
    {
        Debug.Log("Button_PRESET");
        SceneManager.LoadScene(NextScene);
    }
}
