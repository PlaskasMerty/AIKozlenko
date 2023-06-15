using UnityEngine;
public class ActionsCardWhile : BaseForActions
{

    public override void SetPowerMultiplyValue(int value = 1)
    {
        PowerMultiplyValue = value;
    }

    public override void Actions(bool ToEnemy = false)
    {
        GameObject[] CardsOnDesk = Internal.GetArrayOfCardsOnTable();
        int Counter = 0;

        foreach (GameObject CardObject in CardsOnDesk)
        {
            Counter = Counter + 1;
            if (CardObject == this.gameObject)
            {
                if (Counter < CardsOnDesk.Length)
                {
                    CardsOnDesk[Counter].GetComponent<Card>().ActionsController.SetPowerMultiplyValue(PowerMultiplyValue * 3);
                }
            }
        } 
    }
}