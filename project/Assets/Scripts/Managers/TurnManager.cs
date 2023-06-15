using System.Collections;
using UnityEngine;
using TMPro;

public class TurnManager : MonoBehaviour
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public static GameObject[] CardsPosGO;
    public GameObject[] CardsPosGO_Real;
    public GameObject[] ArrayOfCards;
    public static GameObject[] Cards;
    public static TMP_Text MP_Text;
    public static int Start_MP;
    public static int MP = 0;
    public static bool PlayerTurn = false;
    public static TurnManager TM;
    public static Buttons Static_Buttons;
    public Buttons Buttons;
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    void Start()
    {
        Start_MP = PlayerPrefs.GetInt("MP");
        MP_Text  = GameObject.Find("MP_Counter").GetComponent<TMP_Text>();
        
        TM = GetComponent<TurnManager>();       
        TM.StartCoroutine(SpawnNewCards());

        CardsPosGO  = CardsPosGO_Real;
        Cards       = ArrayOfCards;

        Static_Buttons = Buttons;
    }
    public static IEnumerator SpawnNewCards()
    {   
        PlayerTurn   = false;
        
        MP           = Start_MP;
        MP_Text.text = MP.ToString();

        DestroyCardsOnTable();
        MarkCardsOnDesk();

        yield return new WaitForSeconds(2.0f);
        foreach (GameObject CardPoz in CardsPosGO)
        {
            GameObject Card = Instantiate(Cards[Internal.GetRandomValueFromRange_Int(0, Cards.Length)], CardPoz.transform);

            Card.AddComponent<Card>();

            yield return new WaitForSeconds(0.5f);
        }

        PlayerTurn = true;
    }
    public static void DestroyCardsOnTable()
    {
        foreach (GameObject Card in GameObject.FindGameObjectsWithTag("Card"))
        {
            GrabCardMouse GCB = Card.GetComponent<GrabCardMouse>();
            GCB.StartPose = Vector3.zero;
            GCB.EndScale *= 0.0f;
            Destroy(Card, 1.0f);
        }
    }
    public static void MarkCardsOnDesk()
    {
        foreach (GameObject Card in GameObject.FindGameObjectsWithTag("CardOnDesk"))
        {
            GrabCardMouse GCB = Card.GetComponent<GrabCardMouse>();
            GCB.CurrentTurnCard = false;
        }
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    
    public static void Update_MP_Counter()
    {
        MP_Text.text = MP.ToString();
    }
    public static void MP_Manager(int AddValue = 0, int RemoveValue = 0)
    {
        MP += Mathf.Abs(AddValue);
        MP -= Mathf.Abs(RemoveValue);
        Update_MP_Counter();
    } 
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
}

