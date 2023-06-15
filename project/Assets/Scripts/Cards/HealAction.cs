public class HealAction : BaseForActions
{
    public override void SetPowerMultiplyValue(int value = 1)
    {
        PowerMultiplyValue = value;
    }
    public override void Actions(bool ToEnemy = false)
    {
        if (ToEnemy)
        {
            Internal.GetArrayOfCardsOnTable();
            HealthManager.DamageEnemy(10 * PowerMultiplyValue);
        } 
        else
        {
            HealthManager.HealPlayer(10 * PowerMultiplyValue);
        }
    }
}
