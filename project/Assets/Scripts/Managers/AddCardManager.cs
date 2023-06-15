using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCardManager : MonoBehaviour
{
    private Vector3 EndScale;
    private bool Choosed = false;

    void Start()
    {
        EndScale = transform.localScale;
        GetComponent<GrabCardMouse>().enabled = Choosed;
    }

    void Update()
    {
        transform.localScale = Vector2.Lerp(transform.localScale, EndScale, Time.deltaTime * 3);
    }

    private void OnMouseUp()
    {
        if (Choosed)
        {
            EndScale *= 2.0f;
        }
        else
        {
            EndScale *= 0.5f;
        }
        Choosed = !Choosed;
    }
}
