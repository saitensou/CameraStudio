using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualCamCoordinator : MonoBehaviour
{
    public GameObject[] cameraList;

    private int currentCamera;

    // Start is called before the first frame update
    void Start()
    {
        currentCamera = 0;
        int i = 0;
        for (; i < cameraList.Length; i++)
        {
            if (i > 0)
            {
                cameraList[i - 1].gameObject.SetActive(false);
            }
            cameraList[i].gameObject.SetActive(true);
        }

        if (cameraList.Length > 0)
        {
            cameraList[i - 1].gameObject.SetActive(false);
            cameraList[0].gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            currentCamera++;
            if (currentCamera < cameraList.Length)
            {
                cameraList[currentCamera - 1].gameObject.SetActive(false);
                cameraList[currentCamera].gameObject.SetActive(true);
            }
            else
            {
                //cameraList[currentCamera - 1].gameObject.SetActive(false);
                currentCamera = 0;
                cameraList[currentCamera].gameObject.SetActive(true);
            }
        }
    }
}
