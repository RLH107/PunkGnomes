using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMenues : MonoBehaviour
{
    // Menus Start = 0, Menu Play = 1, Menu Win = 2, Menu Lose = 3.

    //Deleget StartLevel
    public delegate void LevelMenuSet();
    public LevelMenuSet LisenStartLevelMenu;
    //Deleget Play
    public LevelMenuSet LisenPlayLevelMenu;
    //Deledet EndWin
    public LevelMenuSet LisenEndWinLevelMenu;
    //Deleget EndLose
    public LevelMenuSet LisenEndLoseLevelMenu;

    [SerializeField] private GameObject[] StartMenuArray; //When start level pressed. Make all StartMenu objects SetFalse
    [SerializeField] private GameObject[] PlayMenuArray; //After all other menus are false SetTrue or Setfalse all PlayMenu objects
    [SerializeField] private GameObject[] EndMenuWinArray; //After all other menus are false SetTrue or Setfalse all EndMenuWin objects
    [SerializeField] private GameObject[] EndMenuLoseArray; //After all other menues are false SetTrue or Setfalse all EndMenuLose objects

    private int PreveosMenu;
    private int CurrentMenu;


    private void Start()
    {
        CurrentMenu = 0;
        PreveosMenu = CurrentMenu;



        for(int i = 0; i < StartMenuArray.Length; i++)
        {
            StartMenuArray[i].SetActive(true);
        }
        for (int i = 0; i < PlayMenuArray.Length; i++)
        {
            PlayMenuArray[i].SetActive(false);
        }
        for (int i = 0; i < EndMenuWinArray.Length; i++)
        {
            EndMenuWinArray[i].SetActive(false);
        }
        for (int i = 0; i < EndMenuLoseArray.Length; i++)
        {
            EndMenuLoseArray[i].SetActive(false);
        }

    }

    public void ChangeMenu(int NextMenu)
    {
        CurrentMenu = NextMenu;
        if(CurrentMenu != PreveosMenu)
        {
            LevelMenuSelect();
        }
    }

    private void LevelMenuSelect()
    {
        int s = PreveosMenu;
        int While = 0;
        // Set current menu to false
        
        Debug.Log("LevelMenuSelect");
        // Set the Current Menu to False and Next Menu to true
        do
        {
            switch (s)
            {
                case 0:
                    Debug.Log("case 0 Start");
                    if(LisenStartLevelMenu != null)
                    {
                        //LisenStartLevelMenu();
                    }
                    break;
                case 1:
                    Debug.Log("case 1 Play");
                    if(LisenPlayLevelMenu != null)
                    {
                        //LisenPlayLevelMenu();
                    }
                    break;
                case 2:
                    Debug.Log("case 2 Win");
                    if(LisenEndWinLevelMenu != null)
                    {
                        //LisenEndWinLevelMenu();
                    }
                    break;
                case 3:
                    Debug.Log("case 3 Lose");
                    if(LisenEndLoseLevelMenu != null)
                    {
                        //LisenEndLoseLevelMenu();
                    }
                    break;
            }
            s = CurrentMenu;
            While++;
        }
        while (While < 2);
        PreveosMenu = CurrentMenu;
    }


    private void ChangeMenu(GameObject[] MenuArray,bool TrueOrFalce)
    {
        Debug.Log("Change Menu Called");
        for(int i = 0; i <= MenuArray.Length; i++)
        {

        }
    }
}
