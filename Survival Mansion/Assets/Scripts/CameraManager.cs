using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {
    public Camera minimap, gameCamera;
    public bool camSwitch = true;
    public int cameraMoveSpeed = 20;

    [SerializeField] private int maxTop, maxBottom, maxRight, maxLeft;


    private void Update()
    {
        if (Input.GetButtonDown("map"))
        {
            camSwitch = !camSwitch;
            gameCamera.gameObject.SetActive(camSwitch);
            minimap.gameObject.SetActive(!camSwitch);
        }
        if (!camSwitch)
        {
            if (Input.GetKey("w"))
            {
                if (minimap.transform.position.y < maxTop)
                {
                    minimap.transform.Translate(0, cameraMoveSpeed, 0);
                }
            }
            if (Input.GetKey("a"))
            {
                if (minimap.transform.position.x > maxLeft)
                {
                    minimap.transform.Translate(-cameraMoveSpeed, 0, 0);
                }
            }
            if (Input.GetKey("s"))
            {
                if (minimap.transform.position.y > maxBottom)
                {
                    minimap.transform.Translate(0, -cameraMoveSpeed, 0);
                }
            }
            if (Input.GetKey("d"))
            {
                if (minimap.transform.position.x < maxRight)
                {
                    minimap.transform.Translate(cameraMoveSpeed, 0, 0);
                }
            }
        }
    }

}

