using UnityEngine;

public class  OpenAnim : MonoBehaviour
{
    public GameObject Left;
    public GameObject Right;
    public GameObject RightVector2;
    public GameObject LeftVector2;

    private void Update()
    {
        Right.transform.position = Vector2.Lerp(Right.transform.position , RightVector2.transform.position  , Time.deltaTime * 1.25f);
        Left.transform.position  = Vector2.Lerp(Left.transform.position  , LeftVector2.transform.position   , Time.deltaTime * 1.25f);
        
    }
}