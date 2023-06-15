using UnityEngine;
public class CardWhile : BaseForCards
{
    public override void InitializePrice()
    {
        ManaCost = 4;
    }
    public override float GetSizeMultipler_Float() => 1.1f;
    public override Sprite GetCover_Sprite() => Internal.GetDictionaryOfAllCardCovers_Dictionary()["CoverCardWhile"];
    public override Sprite GetCover_Info() => Internal.GetDictionaryOfAllCardCovers_Dictionary()["CCWI"];
}
