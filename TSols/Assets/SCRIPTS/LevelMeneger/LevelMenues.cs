using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    //Deleget start Play
    //Deledet EndWin
    //Deleget EndLose

    [SerializeField] private GameObject[] StartMenuArray; //When start level pressed. Make all StartMenu objects SetFalse
    [SerializeField] private GameObject[] PlayMenuArray; //After all other menus are false SetTrue or Setfalse all PlayMenu objects
    [SerializeField] private GameObject[] EndMenuWinArray; //After all other menus are false SetTrue or Setfalse all EndMenuWin objects
    [SerializeField] private GameObject[] EndMenuLoseArray; //After all other menues are false SetTrue or Setfalse all EndMenuLose objects

    private int PreveosScene;


    private void Start()
    {
        PreveosScene = 0;
        LevelMenuSelect(1);
    }

    private void LevelMenuSelect(int menu)
    {
        int s;
        // Set current menu to false
        s = PreveosScene;
        // Set the one menu that you want to true
        for (int i = 0; i < 1; i++)
        {
            Debug.Log("For and s = " + s);
            switch (s)
            {
                case 0:
                    Debug.Log("case 0");
                    break;
                case 1:
                    Debug.Log("case 1");
                    break;
                case 2:
                    Debug.Log("case 2");
                    break;
            }
            s = menu;
        }
        PreveosScene = menu;
    }

}
