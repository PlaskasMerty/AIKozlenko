using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class  Buttons : MonoBehaviour
{
    public string[] LevelsToOpen;
    public string[] LevelsToClose;
    public GameObject[] LoseWinUI_Lose;
    public GameObject[] LoseWinUI_Win;
    public ScoresManager SM;
    public EndAnim Anim;
    public ChooseCardManager CCM;
///////////////////////////////////////////////////////////////////
    public void ShowHideInfo(GameObject Info)
    {
        Info.SetActive(!Info.activeSelf);
    }
    public IEnumerator GameExitIEnumerator()
    {
        Settings.ClearAllPrefs();
        yield return new WaitForSeconds(3f);
        Application.Quit();
    }
    public IEnumerator SetLevelIEnumerator(string Level)
    {
        Anim.StartClose();

        yield return new WaitForSeconds(2.5f);
        if (Level == "Menu" && SceneManager.GetActiveScene().name != "Book" && SceneManager.GetActiveScene().name != "Map")
        {
            SM.StopAddScore = true;
            Settings.SetMapPrefs(1);
            SM.Clear();
        }

        SceneManager.LoadScene(Level);
    }
    public IEnumerator SetMapIEnumerator(int New = 0)
    {
        Anim.StartClose();
        if (New == 1)
        {
            Settings.ClearAllPrefs();
        }

        yield return new WaitForSeconds(2.5f);
        Settings.SetMapPrefs(New);
        SceneManager.LoadScene("Map");   
    }
    public void SetLevel(string Level)
    {
        StartCoroutine(SetLevelIEnumerator(Level));
    }
    public void GameExit()
    {
        Anim.StartClose();
        StartCoroutine(GameExitIEnumerator());
    }
    public void SetMap(int New = 0)
    {
       StartCoroutine(SetMapIEnumerator(New));   
    }
///////////////////////////////////////////////////////////////////
    public void EndTurn(int ActionsCount)
    {
        if (TurnManager.PlayerTurn == true)
        {
            TurnManager.PlayerTurn = false;

            Time.timeScale = 0.0f;
            StartCoroutine(RandomAction(ActionsCount));
            Time.timeScale = 0.7f;

            TurnManager.MP = TurnManager.Start_MP;
            StartCoroutine(TurnManager.SpawnNewCards());
          
            Time.timeScale = 1.0f;
        }
    }
    public IEnumerator RandomAction(int ActionsCount)
    {
        yield return new WaitForSeconds(2f);

        int value = Random.Range(1, ActionsCount);
        
        if (value == 1)
        {
            Heal();
        }
        else if (value == 2)
        {
            Attack();
        }

        AfterCheck();
    }
    public void Heal()
    {
        HealthManager.HealEnemy(10);
    }
    public void Attack()
    {
        HealthManager.DamagePlayer(30);   
    }
    public void AfterCheck()
    {
        if (HealthManager.WinCheck())
        {
            Anim.StartClose();
            StartCoroutine(Win());    
        }
        else if (HealthManager.LoseCheck())
        {
            Anim.StartClose();
            StartCoroutine(Lose());    
        }
    }
    public IEnumerator Lose()
    {
        SM.StopAddScore = true;

        yield return new WaitForSeconds(3.0f);

        foreach (GameObject ElementIU in LoseWinUI_Lose)
        {
            yield return new WaitForSeconds(1f);
            ElementIU.SetActive(true);
        }
    }
    public IEnumerator Win()
    {
        yield return new WaitForSeconds(3.0f);

        Settings.SetMapPrefs(0);
        foreach(string LevelToOpen in LevelsToOpen)
        {
            Settings.SetLevelPrefs(LevelToOpen, 1);
        }

        foreach(string LevelToClose in LevelsToClose)
        {
            Settings.SetLevelPrefs(LevelToClose, 0);
            
            if (LevelToClose == "Level_2")
            { 
                Settings.SetMapPrefs(1);
                SceneManager.LoadScene("Menu"); 
            }
        }

        if ( (SceneManager.GetActiveScene().name == "Level_0" && PlayerPrefs.HasKey("CardScore") ) || ((SceneManager.GetActiveScene().name == "Level_1_1" || SceneManager.GetActiveScene().name == "Level_1_2") && PlayerPrefs.HasKey("CardWhile")))
        {
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene("Map");
        } 

        foreach (GameObject ElementIU in LoseWinUI_Win)
        {
            yield return new WaitForSeconds(1f);                             
            ElementIU.SetActive(true);
        }

        CCM.StartChoose();
    }
    public void Start()
    {
        ChooseCardManager.StartChooseFlag = false;
    }
///////////////////////////////////////////////////////////////////
}