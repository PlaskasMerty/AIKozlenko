using UnityEngine;
public abstract class BaseForCards : MonoBehaviour
{
    public int ManaCost { get; set; }
    public Sprite Visual_Base { get; set; }
    public Sprite Visual_Info { get; set; }
    public abstract void InitializePrice();
    public abstract float GetSizeMultipler_Float();
    public abstract Sprite GetCover_Sprite();
    public abstract Sprite GetCover_Info();
}
