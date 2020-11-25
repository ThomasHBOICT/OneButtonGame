using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterShop : MonoBehaviour
{
    public UIController UI;
    // Start is called before the first frame update
    void Start()
    {
        UI = FindObjectOfType<UIController>();
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            UI.OpenShop();
        }
    }
}
