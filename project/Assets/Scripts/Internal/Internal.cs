using System.Collections.Generic;
using UnityEngine;
public class Internal : MonoBehaviour
{
    public static string[] GetArrayOfAllCardTypes_String()
    {
        List<string> List = new List<string>();
        PlayerPrefs.SetString("CardStart", "CardStart");
        if (PlayerPrefs.HasKey("CardStart")) { List.Add("CardStart"); }
        if (PlayerPrefs.HasKey("CardScore")) { List.Add("CardScore"); }
        if (PlayerPrefs.HasKey("CardWhile")) { List.Add("CardWhile"); }
        return List.ToArray();
    }
    public static int GetRandomValueFromRange_Int(int Min, int Max)
    {
        System.Random rnd = new System.Random();
        return rnd.Next(Min, Max);
    }
    public static Dictionary<string, Sprite> GetDictionaryOfAllCardCovers_Dictionary()
    {
        Dictionary<string, Sprite> Dictionary = new Dictionary<string, Sprite>();
        Dictionary.Add("CoverCardStart" , Resources.Load<Sprite>("CoverCardStart"));
        Dictionary.Add("CoverCardPrefs" , Resources.Load<Sprite>("CoverCardPrefs"));
        Dictionary.Add("CoverCardWhile" , Resources.Load<Sprite>("CoverCardWhile"));
        Dictionary.Add("CCPI" , Resources.Load<Sprite>("CCPI"));
        Dictionary.Add("CCSI" , Resources.Load<Sprite>("CCSI"));
        Dictionary.Add("CCWI" , Resources.Load<Sprite>("CCWI"));
        return Dictionary;
    }
    public static GameObject[] GetArrayOfCardsOnTable()
    {   
        GameObject[] CardsOnDesk = GameObject.FindGameObjectsWithTag("CardOnDesk");
        GameObject temp;
        for (int i = 0; i < CardsOnDesk.Length; i++)
        {
            for (int j = i + 1; j < CardsOnDesk.Length; j++)
            {
                if (CardsOnDesk[i].transform.position.x > CardsOnDesk[j].transform.position.x)
                {
                    temp = CardsOnDesk[i];
                    CardsOnDesk[i] = CardsOnDesk[j];
                    CardsOnDesk[j] = temp;
                }                   
            }            
        } return CardsOnDesk;
    }
    public static GameObject[] GetArrayOfCardsNotOnTable()
    {   
        GameObject[] CardsOnDesk = GameObject.FindGameObjectsWithTag("Card");
        GameObject temp;
        for (int i = 0; i < CardsOnDesk.Length; i++)
        {
            for (int j = i + 1; j < CardsOnDesk.Length; j++)
            {
                if (CardsOnDesk[i].transform.position.x > CardsOnDesk[j].transform.position.x)
                {
                    temp = CardsOnDesk[i];
                    CardsOnDesk[i] = CardsOnDesk[j];
                    CardsOnDesk[j] = temp;
                }                   
            }            
        } return CardsOnDesk;
    }
    public static GameObject[] FindObjectsByLayer(int layer)
    {
        List<GameObject> validTransforms = new List<GameObject>();
        Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].gameObject.layer == layer)
            {
                validTransforms.Add(objs[i].gameObject);
            }
        }
        return validTransforms.ToArray();
    }
}

