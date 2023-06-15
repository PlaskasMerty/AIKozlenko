using UnityEngine;
public class CardScore : BaseForCards
{
    public override void InitializePrice()
    {
        ManaCost = 3;
    }
    public override float GetSizeMultipler_Float() => 1.1f;
    public override Sprite GetCover_Sprite() => Internal.GetDictionaryOfAllCardCovers_Dictionary()["CoverCardPrefs"];
    public override Sprite GetCover_Info() => Internal.GetDictionaryOfAllCardCovers_Dictionary()["CCPI"];
}
