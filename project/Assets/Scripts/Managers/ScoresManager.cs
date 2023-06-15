using System.Collections;
using UnityEngine;
using TMPro;

public class ScoresManager : MonoBehaviour
{
    public TMP_Text ScoreText;
    public int Score;
    public bool StopAddScore = false;

    private float Timer = 0;
    private float TimerLast;

    public void Update()
    {
        Timer += Time.deltaTime;

        if (StopAddScore == false && ChooseCardManager.StartChooseFlag == false && Timer >= TimerLast + 2)
        {
            StartCoroutine(AddScore(1));
            TimerLast = Timer;

            if(Score > int.Parse(PlayerPrefs.GetString("RScore")))
            {
                PlayerPrefs.SetString("RScore", Score.ToString());
            } 
        }

        ScoreText.text = Score.ToString();
    }

    public IEnumerator AddScore(int Value)
    {
        yield return new WaitForSeconds(1f);
        
        Settings.SetScorePrefs(Settings.GetScorePrefs() + Value);
        Score = Settings.GetScorePrefs();

        yield return new WaitForSeconds(1f);
    }
    
    public void Clear()
    {
        Settings.ClearScorePrefs();
    }
}