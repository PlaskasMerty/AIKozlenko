using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RecordManager : MonoBehaviour
{
    public TMP_Text Score;
    void Start()
    {
        if (PlayerPrefs.HasKey("RScore"))
        {
            Score.text = PlayerPrefs.GetString("RScore");  
        }
        else
        {
            PlayerPrefs.SetString("RScore", "0");
        }
    }
}
