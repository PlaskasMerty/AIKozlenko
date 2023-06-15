using UnityEngine;
public class Card : MonoBehaviour
{
    public BaseForCards CardController;
    public GrabCardMouse MouseCountroller;
    public BaseForActions ActionsController;
    public SpriteFlipper FlipperController;
    void Awake()
    {
        Initialize();
    }
    public void SetControllers()
    {
        MouseCountroller = this.gameObject.AddComponent<GrabCardMouse>();
        {
           string[] Array = Internal.GetArrayOfAllCardTypes_String();
            switch (Array[Internal.GetRandomValueFromRange_Int(0, Array.Length)])
            {
                case "CardScore":
                   CardController      = this.gameObject.AddComponent<CardScore>();
                    ActionsController   = this.gameObject.AddComponent<ActionsCardScore>();
                    break;
                case "CardStart":
                    CardController      = this.gameObject.AddComponent<CardStart>();
                    ActionsController   = this.gameObject.AddComponent<ActionsCardStart>();
                    break;
                case "CardWhile":
                    CardController      = this.gameObject.AddComponent<CardWhile>();
                    ActionsController   = this.gameObject.AddComponent<ActionsCardWhile>();
                    break;
                default:
                    break;
            }
            if (name == "CardScore")
            {
                CardController      = this.gameObject.AddComponent<CardScore>();
                ActionsController   = this.gameObject.AddComponent<ActionsCardScore>();
            }
            if (name == "CardStart")
            {
                CardController      = this.gameObject.AddComponent<CardStart>();
                ActionsController   = this.gameObject.AddComponent<ActionsCardStart>();
            }
            if (name == "CardWhile")
            {
                CardController      = this.gameObject.AddComponent<CardWhile>();
                ActionsController   = this.gameObject.AddComponent<ActionsCardWhile>();
            }
        }
        FlipperController = this.gameObject.AddComponent<SpriteFlipper>();
        Audio.AudioCard();
    }
    public void Initialize()
    {
        SetControllers();
        CardController.InitializePrice();
        GetComponent<SpriteRenderer>().sprite = CardController.GetCover_Sprite();
        MouseCountroller.EndScale *= CardController.GetSizeMultipler_Float();

        CardController.Visual_Base = CardController.GetCover_Sprite();
        CardController.Visual_Info = CardController.GetCover_Info();
    }

    public void ChangeSprite()
    {
        if (GetComponent<SpriteRenderer>().sprite == CardController.GetCover_Sprite())
        {
            GetComponent<SpriteRenderer>().sprite = CardController.GetCover_Info();    
        }
        else
        {
           GetComponent<SpriteRenderer>().sprite = CardController.GetCover_Sprite(); 
        }
    }
}