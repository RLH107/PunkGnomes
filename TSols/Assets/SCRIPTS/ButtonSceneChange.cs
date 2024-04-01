using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSceneChange : MonoBehaviour
{
    [SerializeField] private string NextScene;
    LevelChanger LChanger_Script;

    private void Start()
    {
        LChanger_Script = GetComponent<LevelChanger>();
    }
    public void OnButtonClickSendMessege()
    {
        Debug.Log("Button_PRESET");
        LChanger_Script.ChangeScene(NextScene);
    }
}
