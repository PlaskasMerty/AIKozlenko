using UnityEngine;
public class Settings : MonoBehaviour
{
    public float MouseSpeed;
    public int MP;
    public int Score;
    public int EnemyPowerMultiplicator = 1;
    private void Awake(){
        PlayerPrefs.SetFloat("MouseSpeed", MouseSpeed);
        PlayerPrefs.SetInt("MP", MP);
        PlayerPrefs.SetInt("EnemyPowerMultiplicator", EnemyPowerMultiplicator);
    }
    public static void SetLevelPrefs(string Level, int Open = 0){
        string Level_Open = Level + "_Open";
        PlayerPrefs.SetInt(Level_Open, Open);
    }
    public static bool GetLevelPrefs_Open(string Level){
        string Level_Open = Level + "_Open";
        return PlayerPrefs.GetInt(Level_Open) == 1;
    }
    public static void SetMapPrefs(int New)
    {PlayerPrefs.SetInt("Map_New", New);}
    public static bool GetMapPrefs_New(){return PlayerPrefs.GetInt("Map_New") == 1;}
    public static void SetScorePrefs(int Value){PlayerPrefs.SetInt("Score", Value);}
    public static int GetScorePrefs(){return PlayerPrefs.GetInt("Score");}
    public static void ClearScorePrefs(){PlayerPrefs.SetInt("Score", 0);}
    public static void ClearAllPrefs(){
        PlayerPrefs.SetInt("EnemyPowerMultiplicator", 1);
        ClearScorePrefs();
        SetMapPrefs(1);
        SetLevelPrefs("Level_0_Open"    , 0);
        SetLevelPrefs("Level_1_1_Open"  , 0);
        SetLevelPrefs("Level_1_2_Open"  , 0);
        SetLevelPrefs("Level_2_Open"    , 0);
    }
}
