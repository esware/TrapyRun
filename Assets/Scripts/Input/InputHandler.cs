using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : Singleton<InputHandler>
{
    public float positionX;
    public float rotationY;
    public bool isStart = false;

    private void Update()
    {
        MobileInput();
    }

    void MobileInput()
    {
        var MousePosition = Input.mousePosition;
        MousePosition.x -= Screen.width / 2;

        if (Input.GetMouseButton(0))
        {
            isStart = true;

            rotationY = Mathf.Clamp(MousePosition.x, -30f, 30f);

            if (MousePosition.x < 0)
            {
                positionX = -1f;
            }
            else if (MousePosition.x > 0)
            {
                positionX = 1f;
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            positionX = 0;
            rotationY = 0;
        }
    }
}
