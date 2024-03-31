using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonSceneChange : MonoBehaviour
{
    [SerializeField] private string NextScene;
    public void OnButtonClickSendMessege()
    {
        Debug.Log("Button_PRESET");
        SceneManager.LoadScene(NextScene);
    }
}
