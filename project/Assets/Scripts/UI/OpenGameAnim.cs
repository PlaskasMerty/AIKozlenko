using System.Collections;
using UnityEngine;

public class  OpenGameAnim : MonoBehaviour
{
    public GameObject KV_UP;
    public GameObject KV_DOWN;
    public GameObject UP_Vector;
    public GameObject DOWN_Vector;
    private bool Open = false;

    public float TimeToOff = 5.0f;
    public float TimeToOpen = 1.0f;
    public float Speed = 1.0f;

    private void Update()
    {
        if (Open)
        {
            KV_UP.transform.position    = Vector2.Lerp(KV_UP.transform.position    , UP_Vector.transform.position  , Time.deltaTime * Speed);
            KV_DOWN.transform.position  = Vector2.Lerp(KV_DOWN.transform.position  , DOWN_Vector.transform.position, Time.deltaTime * Speed);
        }
    }

    private void Start()
    {
        StartCoroutine(Off());
    }

    private IEnumerator Off()
    {
        yield return new WaitForSeconds(TimeToOpen);
        Open = true;
        yield return new WaitForSeconds(TimeToOff);
        this.GetComponent<OpenGameAnim>().enabled = false;
    }
}