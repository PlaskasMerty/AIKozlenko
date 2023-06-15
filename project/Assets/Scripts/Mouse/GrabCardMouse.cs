using UnityEngine;
using UnityEngine.UI;

public class GrabCardMouse : MonoBehaviour
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    private bool InDrag = false;
    private bool LastButtonInfo = false;
    private bool InFlip = false;
    private Vector3 MousePos;
    private float MouseSpeed;
    private Vector3 RealStartPoz;
    public Vector3 StartPose;
    public Vector3 StartScale;
    public Vector3 EndScale;
    public Vector3 InfoScale;
    public bool FromDesk = false;
    private string CurrentColiderTag;
    public SpriteRenderer SR;
    public GameObject Glow;
    public Card Card;
    public bool CurrentTurnCard = true;
    public bool CanFlip = true;
    public Buttons Buttons;

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    private void OnMouseDown()
    {
        if (TurnManager.PlayerTurn == true && !LastButtonInfo)
        {
            Glow.SetActive(true);
            SR.sortingOrder   = 1000;
            InDrag            = true;
        }
    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1) && CanFlip)
        {
            LastButtonInfo = true;
            FlipFlip();
            foreach (GameObject Element in Internal.GetArrayOfCardsNotOnTable())
            {
                if (Element != this.gameObject)
                {
                    Element.GetComponent<Renderer>().sortingOrder = 0000;
                }
            }

            if(InFlip)
            {
                foreach (GameObject Element in Internal.FindObjectsByLayer(5))
                {
                    Element.layer = 2;
                }

                SR.sortingOrder = 1000;
                GameObject.Find("ButtonEndTurn").GetComponent<Button>().interactable = false;
            }
            else
            {
                foreach (GameObject Element in Internal.FindObjectsByLayer(2))
                {
                    Element.layer = 5;
                }

                SR.sortingOrder = 0000;
                GameObject.Find("ButtonEndTurn").GetComponent<Button>().interactable = true;
            }
            gameObject.layer = 5;
        }
        else
        {
            LastButtonInfo = false;
        }
    }

    public void FlipFlip()
    {
        Card.FlipperController.Flip();
        InFlip = !InFlip; 
        Card.ChangeSprite();
    }
    private void OnMouseUp()
    {
        if (TurnManager.PlayerTurn == true && !LastButtonInfo)
        {
            Glow.SetActive(false);
            SR.sortingOrder   = 00000;
            InDrag            = false;
            if (FromDesk && CurrentColiderTag != "Desk" && CurrentTurnCard)
            {
                tag = "Card";
                StartPose = RealStartPoz;
                FromDesk  = false;
                Desk.CardsCount--;
                TurnManager.MP_Manager(GetComponent<Card>().CardController.ManaCost, 0);
                EndScale *= 1.1f;
                Desk.UpdateDesk();
            }
            Desk.BC2D.enabled = false;
        }
        if (ChooseCardManager.StartChooseFlag) 
        {
            if (this.name == "CardScore")
            {
                PlayerPrefs.SetString("CardScore", "CardScore");
            }
            if (this.name == "CardWhile")
            {
                PlayerPrefs.SetString("CardWhile", "CardWhile");
            }
            Buttons.SetMap(0);
        }
    }
    private void OnMouseDrag()
    {
        if (TurnManager.PlayerTurn == true && !InFlip)
        {
            Desk.BC2D.enabled       = true;
            MousePos                = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position      = Vector2.Lerp(transform.position, MousePos, MouseSpeed * Time.deltaTime * 3);
            transform.localScale    = Vector2.Lerp(transform.localScale, EndScale * 1.5f, Time.deltaTime * 3);
        }
    }
    private void Update()
    {
        if (!InDrag & !InFlip)
        {
            transform.position   = Vector2.Lerp(transform.position, StartPose, MouseSpeed * Time.deltaTime * 3);
            transform.localScale = Vector2.Lerp(transform.localScale, EndScale, Time.deltaTime * 3);
        }

        if (InFlip)
        {
            transform.position      = Vector2.Lerp(transform.position   , Vector2.zero  , MouseSpeed * Time.deltaTime * 3);
            transform.localScale    = Vector2.Lerp(transform.localScale , InfoScale     , Time.deltaTime * 3);
            SR.sortingOrder         = 1000;   
        }
        else if (!InDrag) 
        {
            transform.position      = Vector2.Lerp(transform.position   , StartPose , MouseSpeed * Time.deltaTime * 3);
            transform.localScale    = Vector2.Lerp(transform.localScale , EndScale  , Time.deltaTime * 3);
            SR.sortingOrder         = 0000;
        }
    }
    private void Awake()
    {
        Buttons         = GameObject.Find("EventSystem").GetComponent<Buttons>();
        
        MouseSpeed      = PlayerPrefs.GetFloat("MouseSpeed");
        RealStartPoz    = transform.position;
        StartPose       = transform.position;
        StartScale      = transform.localScale * 0.5f;
        EndScale        = transform.localScale;

        InfoScale       = new Vector3(EndScale.x * 7, EndScale.y * 2, EndScale.z);

        transform.localScale    = StartScale;
        SR                      = GetComponent<SpriteRenderer>();
        Glow                    = transform.GetChild(0).gameObject;

        Card = GetComponent<Card>();

        foreach (GameObject Element in Internal.FindObjectsByLayer(2))
        {
            Element.layer = 5;
        }
    }  
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    void OnTriggerExit2D(Collider2D collision)
    {
        if(!InDrag && !FromDesk && collision.tag == "Desk" && Desk.CardsCount != 5 && !InFlip && !LastButtonInfo)
        {
            Desk.SetCardOnDesk(gameObject);
        } CurrentColiderTag = null;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!InFlip)
        {
            CurrentColiderTag = collision.tag;
        }
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
}
