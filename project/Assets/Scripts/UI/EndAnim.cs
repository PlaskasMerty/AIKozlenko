using UnityEngine;

public class  EndAnim : MonoBehaviour
{
    public bool Close = false;
    public GameObject Left;
    public GameObject Right;
    public GameObject RightVector2;
    public GameObject LeftVector2;

    private void Update()
    {
        if (Close)
        {
            Right.transform.position = Vector2.Lerp(Right.transform.position , RightVector2.transform.position  , Time.deltaTime * 1.25f);
            Left.transform.position  = Vector2.Lerp(Left.transform.position  , LeftVector2.transform.position   , Time.deltaTime * 1.25f);
        }
    }
    public void StartClose()
    {
        Close = true;
    }
}