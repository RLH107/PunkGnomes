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

    [SerializeField] private GameObject StartMenu; //When start level pressed. Make all StartMenu objects SetFalse
    [SerializeField] private GameObject PlayMenu; //After all other menus are false SetTrue or Setfalse all PlayMenu objects
    [SerializeField] private GameObject EndMenuWin; //After all other menus are false SetTrue or Setfalse all EndMenuWin objects
    [SerializeField] private GameObject EndMenuLose; //After all other menues are false SetTrue or Setfalse all EndMenuLose objects

    private int PreveosMenu;
    private int CurrentMenu;
    private int While;

    private void Start()
    {
        CurrentMenu = 0;
        PreveosMenu = CurrentMenu;


        StartMenu.SetActive(false);
        PlayMenu.SetActive(false);
        EndMenuWin.SetActive(false);
        EndMenuLose.SetActive(false);

        While = 1;
        PreveosMenu = 0;
        LevelMenuSelect();
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
        // Set current menu to false
        
        //Debug.Log("LevelMenuSelect");
        // Set the Current Menu to False and Next Menu to true
        do
        {
            switch (s)
            {
                case 0:
                    Debug.Log("case 0 Start");
                    if(LisenStartLevelMenu != null && While == 1)
                    {
                        Debug.Log("Start_Listen_Called");
                        LisenStartLevelMenu();
                    }
                    ChangeMenu(StartMenu, 0);
                    break;
                case 1:
                    Debug.Log("case 1 Play");
                    if(LisenPlayLevelMenu != null && While == 1)
                    {
                        Debug.Log("Play_Listen_Called");
                        LisenPlayLevelMenu();
                    }
                    ChangeMenu(PlayMenu, 1);
                    break;
                case 2:
                    Debug.Log("case 2 Win");
                    if(LisenEndWinLevelMenu != null && While == 1)
                    {
                        Debug.Log("Win_Listen_Called");
                        LisenEndWinLevelMenu();
                    }
                    ChangeMenu(EndMenuWin, 2);
                    break;
                case 3:
                    Debug.Log("case 3 Lose");
                    if(LisenEndLoseLevelMenu != null && While == 1)
                    {
                        Debug.Log("Lose_Listen_Called");
                        LisenEndLoseLevelMenu();
                    }
                    ChangeMenu(EndMenuLose, 3);
                    break;
            }
            s = CurrentMenu;
            While++;
        }
        while (While < 2);
        While = 0;
        PreveosMenu = CurrentMenu;
    }


    private void ChangeMenu(GameObject Menu, int MenuNumber)
    {
        //Debug.Log("Change Menu Called");

        if(MenuNumber == CurrentMenu)
        {
            //Debug.Log("True Called");
            Menu.SetActive(true);
        }
        if(MenuNumber != CurrentMenu)
        {
            //Debug.Log("False Called");
            Menu.SetActive(false);
        }
    }
}
