using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{
    public Animator ani;

    public void Pickup()
    {
        ani.SetTrigger("pickup");
        Destroy(gameObject, 0.25f);
    }
}
