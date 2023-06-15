using UnityEngine;

public class StartCard : BaseForCards
{
    public override void InitializePrice()
    {
        ManaCost = 1;
    }
    public override float GetSizeMultipler_Float() => 1.1f;
    public override Sprite GetCover_Sprite()
    {
        //Texture2D Texture = Internal.GetDictionaryOfAllCardCovers_Dictionary()["OneCover"];
        //Rect Rect = new Rect(0.0f, 0.0f, Texture.width, Texture.height);
        //Vector2 Vector2 = new Vector2(0.5f, 0.5f); 
        //float pixelsPerUnit = 100.0f; 
        //Card.GetComponent<SpriteRenderer>().sprite = Sprite.Create(Texture, Rect, Vector2, pixelsPerUnit);
        return null;
    }
    public override Sprite GetCover_Info()
    {
        //Texture2D Texture = Internal.GetDictionaryOfAllCardCovers_Dictionary()["OneCover"];
        //Rect Rect = new Rect(0.0f, 0.0f, Texture.width, Texture.height);
        //Vector2 Vector2 = new Vector2(0.5f, 0.5f); 
        //float pixelsPerUnit = 100.0f; 
        //Card.GetComponent<SpriteRenderer>().sprite = Sprite.Create(Texture, Rect, Vector2, pixelsPerUnit);
        return null;
    }
}

