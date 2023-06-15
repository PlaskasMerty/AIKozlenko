using UnityEngine;
public class CardStart : BaseForCards
{
    public override void InitializePrice()
    {
        ManaCost = 2;
    }
    public override float GetSizeMultipler_Float() => 1.1f;
    public override Sprite GetCover_Sprite() => Internal.GetDictionaryOfAllCardCovers_Dictionary()["CoverCardStart"];
    public override Sprite GetCover_Info() => Internal.GetDictionaryOfAllCardCovers_Dictionary()["CCSI"];
}
