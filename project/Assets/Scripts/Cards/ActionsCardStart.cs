using UnityEngine;
public class ActionsCardStart : BaseForActions
{

    public override void SetPowerMultiplyValue(int value = 1)
    {
        PowerMultiplyValue = value;
    }

    public override void Actions(bool ToEnemy = false)
    {
        if (ToEnemy) 
        { 
            HealthManager.DamageEnemy(10 * PowerMultiplyValue);
        } 
        else 
        {
            HealthManager.HealPlayer(10 * PowerMultiplyValue);
        }
        GameObject[] CardsOnDesk = Internal.GetArrayOfCardsOnTable();
        if (this.gameObject == CardsOnDesk[0].gameObject)
        {
            for (int c = 1; c < CardsOnDesk.Length; c++)
            {
                CardsOnDesk[c].GetComponent<Card>().ActionsController.SetPowerMultiplyValue(2);
            }
        }
    }
}