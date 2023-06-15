using UnityEngine;

public class Desk : MonoBehaviour
{
    public static Transform DeskTransform;

    public static int CardsCount = 0;

    public static GameObject[] CardsOnDesk;

    public static BoxCollider2D BC2D;

    private void Start()
    {
        DeskTransform   = transform;
        BC2D            = GetComponent<BoxCollider2D>();
        CardsOnDesk     = GameObject.FindGameObjectsWithTag("CardOnDesk");
        CardsCount      = 0;
    }

    public static void SetCardOnDesk(GameObject Card)
    {
        int ManaCost = Card.GetComponent<Card>().CardController.ManaCost;
        GrabCardMouse CardGrabCardMouse = Card.GetComponent<GrabCardMouse>();
        
        if (TurnManager.MP >= ManaCost)
        {
            Card.tag = "CardOnDesk";
            CardsCount++;
            CardGrabCardMouse.EndScale /= 1.1f;
            CardGrabCardMouse.FromDesk = true;
            UpdateDesk();
            TurnManager.MP_Manager(0, ManaCost);
        }
    }

    public static void UpdateDesk()
    {   
        CardsOnDesk = GameObject.FindGameObjectsWithTag("CardOnDesk");
        if (CardsOnDesk.Length > 0) 
        {
            Vector2[] PossiblePlace = CreatePossiblePlace(CardsCount);
            for (int i = 0; i < PossiblePlace.Length; i++)
            {
                CardsOnDesk[i].GetComponent<GrabCardMouse>().StartPose = PossiblePlace[i];
            }
        } 
    }

    public static Vector2[] CreatePossiblePlace(int CardsCount, float step = 1.5f)
    {
        Vector2[] Vec = new Vector2[CardsCount];

        if (CardsCount > 1)
        {
            if (CardsCount % 2 == 0)
            {
                int m = -CardsCount / 2;
                float[] array = new float[CardsCount];
                for (int i = 0; i < array.Length / 2; i++)
                {
                    array[i] = step * m++;
                    Vec[i] = new Vector2(array[i], DeskTransform.position.y);

                    if (array[i] + 1 == 0) { m++; }
                }
                for (int i = array.Length / 2; i < array.Length; i++)
                {
                    array[i] = step * m++;
                    Vec[i] = new Vector2(array[i], DeskTransform.position.y);
                }
            }
            else
            {
                int m = -CardsCount / 2;
                int n = CardsCount / 2;

                float[] array = new float[n - m + 1];
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = step * m++;
                    Vec[i] = new Vector2(array[i], DeskTransform.position.y);
                }
            }
        }
        else
        {
            Vec[0] = new Vector2(0.0f, DeskTransform.position.y);
        }
        return Vec;
    }
}




