using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse
{
    public static BallShadow Ball;

    public static Vector3 GetMousePos()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        return mousePos;
    }
}
