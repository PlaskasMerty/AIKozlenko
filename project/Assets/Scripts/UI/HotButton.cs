using UnityEngine;
using UnityEngine.SceneManagement;

public class HotButton : MonoBehaviour
{
    public string[] LevelsToOpen;
    public string[] LevelsToClose;

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void Win()
    {
        int NewMap         = 0;
        string SceneName   = "Map";

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
                NewMap      = 1;
                SceneName   = "Menu";    
            }
        }

        Settings.SetMapPrefs(NewMap);
        SceneManager.LoadScene(SceneName);
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && TurnManager.PlayerTurn)
        {
            //StartCoroutine(TurnManager.SpawnNewCards());
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Settings.ClearAllPrefs();
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Win();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            GetComponent<Buttons>().Lose();
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            HealthManager.HealEnemy(10);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            PlayerPrefs.DeleteKey("CardScore");
            PlayerPrefs.DeleteKey("CardWhile");
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            PlayerPrefs.SetString("CardScore", "CardScore");
            PlayerPrefs.SetString("CardWhile", "CardWhile");
        }
    }
    public static void Slide(bool ToEnemy = true)
    {
        GameObject[] Cards = GameObject.FindGameObjectsWithTag("CardOnDesk");
        if (ToEnemy)
        {
            foreach (GameObject Card in Cards)
            {
                GrabCardMouse GRB = Card.GetComponent<GrabCardMouse>();
                GRB.StartPose = GameObject.FindGameObjectWithTag("RightSide").transform.position;
                GRB.EndScale  = Vector3.zero;
                Desk.CardsCount = 0;
                Card.GetComponent<Card>().ActionsController.Actions(true);
                Destroy(Card, 1.0f);
            }
        }
        else
        {
            foreach (GameObject Card in Cards)
            {
                GrabCardMouse GRB = Card.GetComponent<GrabCardMouse>();
                GRB.StartPose = GameObject.FindGameObjectWithTag("LeftSide").transform.position;
                GRB.EndScale = Vector3.zero;
                Desk.CardsCount = 0;
                Card.GetComponent<Card>().ActionsController.Actions(false);
                Destroy(Card, 1.0f);
            }
        }
        TurnManager.Static_Buttons.AfterCheck();
    }
    public static void ToEnemy()
    {
        Slide(true);
    }
    public static void ToPlayer()
    {
        Slide(false);
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
}