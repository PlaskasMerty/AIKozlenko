using System.Collections;
using UnityEngine;

public class SpawnBookCards : MonoBehaviour
{
    
    public GameObject[] AllCards;
    public GameObject[] CardsPos;
    public Sprite LockedSprite;
    
    void Start()
    {
        StartCoroutine(SpawnCards());
    }

    public IEnumerator SpawnCards()
    {   
        // 111111111111111111111111111111111111111111111
        yield return new WaitForSeconds(1.75f);
        
        if (PlayerPrefs.HasKey("CardStart"))
        {
            GameObject Card = Instantiate(AllCards[Internal.GetRandomValueFromRange_Int(0, AllCards.Length)], CardsPos[0].transform);
            Card.name = "CardStart";
            Card CardComponent = Card.AddComponent<Card>();
            Card.name = "NotCardStart";
        }
        else
        {
            GameObject Card = Instantiate(AllCards[Internal.GetRandomValueFromRange_Int(0, AllCards.Length)], CardsPos[0].transform);
            Card CardController = Card.AddComponent<Card>();
            CardController.enabled = false;
            Card.GetComponent<GrabCardMouse>().CanFlip = false;
            Card.GetComponent<SpriteRenderer>().sprite = LockedSprite;
        }

        // 222222222222222222222222222222222222222222
        yield return new WaitForSeconds(0.5f);

        if (PlayerPrefs.HasKey("CardScore"))
        {
            GameObject Card = Instantiate(AllCards[Internal.GetRandomValueFromRange_Int(0, AllCards.Length)], CardsPos[1].transform);
            Card.name = "CardScore";
            Card CardComponent = Card.AddComponent<Card>();
            Card.name = "NotCardScore";
        }
        else
        {
            GameObject Card = Instantiate(AllCards[Internal.GetRandomValueFromRange_Int(0, AllCards.Length)], CardsPos[1].transform);
            Card CardController = Card.AddComponent<Card>();
            CardController.enabled = false;
            Card.GetComponent<GrabCardMouse>().CanFlip = false;
            Card.GetComponent<SpriteRenderer>().sprite = LockedSprite;
        }

        // 33333333333333333333333333333333333333333333
        yield return new WaitForSeconds(0.5f);

        if (PlayerPrefs.HasKey("CardWhile"))
        {
            GameObject Card = Instantiate(AllCards[Internal.GetRandomValueFromRange_Int(0, AllCards.Length)], CardsPos[2].transform);
            Card.name = "CardWhile";
            Card CardComponent = Card.AddComponent<Card>();
            Card.name = "NotCardWhile";
        }
        else
        {
            GameObject Card = Instantiate(AllCards[Internal.GetRandomValueFromRange_Int(0, AllCards.Length)], CardsPos[2].transform);
            Card CardController = Card.AddComponent<Card>();
            CardController.enabled = false;
            Card.GetComponent<GrabCardMouse>().CanFlip = false;
            Card.GetComponent<SpriteRenderer>().sprite = LockedSprite;
        }

        // 4444444444444444444444444444444444444444444
        yield return new WaitForSeconds(0.5f);

        if (PlayerPrefs.HasKey("0"))
        {
            GameObject Card = Instantiate(AllCards[Internal.GetRandomValueFromRange_Int(0, AllCards.Length)], CardsPos[3].transform);
            Card.name = "CardScore";
            Card CardComponent = Card.AddComponent<Card>();
            Card.name = "NotCardScore";
        }
        else
        {
            GameObject Card = Instantiate(AllCards[Internal.GetRandomValueFromRange_Int(0, AllCards.Length)], CardsPos[3].transform);
            Card CardController = Card.AddComponent<Card>();
            CardController.enabled = false;
            Card.GetComponent<GrabCardMouse>().CanFlip = false;
            Card.GetComponent<SpriteRenderer>().sprite = LockedSprite;
        }
    }

    public void SetBookPrefs_OpenCard(string Card, bool Init)
    {
        if(PlayerPrefs.HasKey("Card_Start") && !Init)
        {
            PlayerPrefs.SetString("Card_" + Card, "Open");
        }
        else
        {
            PlayerPrefs.SetString("Card_Start", "Open");
        }
    }

    public bool[] GetBookPrefs_OpenCards()
    {
        SetBookPrefs_OpenCard("Init", true);
        bool[] Array = new bool[4];
        Array[0] = PlayerPrefs.HasKey("CardScore");;
        Array[1] = PlayerPrefs.HasKey("Card_Start");
        Array[2] = false;
        Array[3] = false;
        return Array;
    }
}
