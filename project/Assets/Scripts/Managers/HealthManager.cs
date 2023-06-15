using UnityEngine;
using TMPro;

public class HealthManager : MonoBehaviour
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public static TMP_Text PHealth;
    public static TMP_Text EHealth;

    public static int MaxPlayerHP = 100;
    public static int MinPlayerHP = 0;

    public static int MaxEnemyHP = 100;
    public static int MinEnemyHP = 0;

    public static bool StopDamageEnemy  = false;
    public static bool StopHealPlayer   = false;
    public static bool StopHealEnemy    = false;
    public static bool StopDamagePlayer = false;

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public static bool WinCheck()
    {
        return int.Parse(EHealth.text) <= 0;
    }
    public static bool LoseCheck()
    {
        return int.Parse(PHealth.text) <= 0;
    }
    void Start()
    {
        StopDamageEnemy = false;
        StopHealPlayer  = false;

        PHealth = GameObject.FindGameObjectWithTag("PH").GetComponent<TMP_Text>();
        EHealth = GameObject.FindGameObjectWithTag("EH").GetComponent<TMP_Text>();

        MaxEnemyHP = 100 * PlayerPrefs.GetInt("EnemyPowerMultiplicator");

        PHealth.text = MaxPlayerHP.ToString();
        EHealth.text = MaxEnemyHP.ToString();
    }
    public static void HealPlayer(int Value)
    {
        if (!StopHealPlayer)
        {
            if(int.Parse(PHealth.text) + Value > MaxPlayerHP)
            {

                StopHealPlayer = true;
                Value = MaxPlayerHP - int.Parse(PHealth.text);

            } else { StopHealPlayer = false; }

            PHealth.text = (int.Parse(PHealth.text) + Value).ToString();
            
        }
    }
    public static void DamageEnemy(int Value)
    {
        Debug.Log(StopDamageEnemy);
        if (!StopDamageEnemy)
        {
            EHealth.text = (int.Parse(EHealth.text) - Value).ToString();
            if(int.Parse(EHealth.text) <= MinEnemyHP) { StopDamageEnemy = true; } else { StopDamageEnemy = false; }
        }
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public static void DamagePlayer(int Value)
    {
        if (!StopDamagePlayer)
        {
            if(int.Parse(PHealth.text) - Value <= MinPlayerHP)
            {
                StopDamagePlayer    = true;
                PHealth.text        = MinPlayerHP.ToString();
            }
            else
            {
                StopDamagePlayer = false;
                PHealth.text = (int.Parse(PHealth.text) - Value).ToString();
            }
        }
        StopHealPlayer = false;
    }
    public static void HealEnemy(int Value)
    {
        if (!StopHealEnemy)
        {    
            if (int.Parse(EHealth.text) >= MaxEnemyHP)
            { 
                StopHealEnemy   = true;
                EHealth.text    = MaxEnemyHP.ToString();
            }
            else
            { 
                StopHealEnemy   = false;
                EHealth.text    = (int.Parse(EHealth.text) + Value).ToString();
            }
        }
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
}
