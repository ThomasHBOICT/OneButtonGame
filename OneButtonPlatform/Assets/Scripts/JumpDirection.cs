using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDirection : MonoBehaviour
{
    public bool tickerRightSide = true;

    int flipDirection = 45;
    private Transform tf;
    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
    }

    public void FlipDirection()
    {
        flipDirection *= -1;
        tf.localRotation = Quaternion.Euler(0, 0, flipDirection);
        tickerRightSide = !tickerRightSide;
    }
}
