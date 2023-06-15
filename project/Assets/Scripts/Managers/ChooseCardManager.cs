using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;

public class ChooseCardManager : MonoBehaviour
{
    public GameObject[] PlaceForCard;
    public GameObject BaseCard;
    public static bool StartChooseFlag = false;

    public void StartChoose()
    {
        StartChooseFlag = true;
        StartCoroutine(SpawnNewCards(SceneManager.GetActiveScene().name));
    }

    public IEnumerator SpawnNewCards(string SceneName)
    {   
        Desk.CardsCount = 5;
        yield return new WaitForSeconds(0.5f);

        if (SceneName == "Level_0")
        {
            // CardScore
            GameObject Card = Instantiate(BaseCard, PlaceForCard[0].transform);
            Card.name = "CardScore";
            Card CardComponent = Card.AddComponent<Card>();
            Card.GetComponent<SpriteRenderer>().sortingLayerName = "LoseWinUI";
        }

        if (SceneName == "Level_1_1" || SceneName == "Level_1_2")
        {
            // CardWhile
            GameObject Card = Instantiate(BaseCard, PlaceForCard[0].transform);
            Card.name = "CardWhile";
            Card CardComponent = Card.AddComponent<Card>();
            Card.GetComponent<SpriteRenderer>().sortingLayerName = "LoseWinUI";
        }
        
        yield return new WaitForSeconds(0.5f); 
    }
}
