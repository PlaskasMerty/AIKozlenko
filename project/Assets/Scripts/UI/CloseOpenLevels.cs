using UnityEngine;
using UnityEngine.SceneManagement;
 using System.Collections;
 using UnityEngine.UI;

public class  CloseOpenLevels : MonoBehaviour
{
    public Button[] Buttons;
    public string[] LevelsName = { "Level_0", "Level_1_1", "Level_1_2", "Level_2"};
    public void Awake()
    { 
        if (Settings.GetMapPrefs_New())
        { 
            AwakeNewMap();
            Settings.SetMapPrefs(0);
        } 
        else
        { 
            AwakeOldMap();
        } 
    }

    public void AwakeNewMap()
    {
        foreach (string Level in LevelsName) 
        { 
            Settings.SetLevelPrefs(Level, 0);
        }

        Buttons[0].interactable = true;
        Settings.SetLevelPrefs("Level_0", 1);
    }

    public void AwakeOldMap()
    {
        Buttons[0].interactable = Settings.GetLevelPrefs_Open(LevelsName[0]);
        Buttons[1].interactable = Settings.GetLevelPrefs_Open(LevelsName[1]);
        Buttons[2].interactable = Settings.GetLevelPrefs_Open(LevelsName[2]);
        Buttons[3].interactable = Settings.GetLevelPrefs_Open(LevelsName[3]);
    }
}

