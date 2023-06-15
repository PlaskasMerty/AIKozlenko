using UnityEngine;
public class ActionsCardScore : BaseForActions
{

    public override void SetPowerMultiplyValue(int value = 1)
    {
        PowerMultiplyValue = value;
    }

    public override void Actions(bool ToEnemy = false)
    {
        if (ToEnemy) 
        { 
            Settings.SetScorePrefs(Settings.GetScorePrefs() - 50 * PowerMultiplyValue);
        } 
        else 
        {
            Settings.SetScorePrefs(Settings.GetScorePrefs() + 50 * PowerMultiplyValue);
        }
    }
}