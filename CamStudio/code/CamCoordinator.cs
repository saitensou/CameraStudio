using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamCoordinator : MonoBehaviour
{
    public Camera[] cameraList;

    public Camera mainCamera;

    public Camera previewActiveCamera;

    void Start()
    {
        if (previewActiveCamera == null)
        {
            previewActiveCamera = cameraList[0];
        }
    }

    void Update()
    {
        // handle swap key
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SwapPreviewAndMainCamera(previewActiveCamera, mainCamera, true);
        }

        // handle active click
        if (Input.GetMouseButtonUp(1))
        {
            SelectPreviewCamera(Input.mousePosition);
        }
    }

    void SelectPreviewCamera(Vector3 position)
    {
        Vector3 viewPortPoint = Camera.main.ScreenToViewportPoint(position);
        Debug.Log("viewport point: " + viewPortPoint);
        bool found = false;
        for (int i = 0; i < cameraList.Length; i++)
        {
            Rect tempRec = cameraList[i].rect;
            if (tempRec.Contains(viewPortPoint))
            {
                Debug.Log("found rect: " + tempRec);
                previewActiveCamera = cameraList[i];
                found = true;
            }
        }
        if (!found)
        {
            Debug.Log("Not Found port");
        }
    }

    void SwapPreviewAndMainCamera(
        Camera fromCamera,
        Camera toCamera,
        bool swithDisplay
    )
    {
        Rect fromRect = fromCamera.rect;
        Rect toRect = toCamera.rect;
        Debug.Log("Switiching camera: ");
        Debug.Log("preview camera: " + fromRect);
        Debug.Log("main camera: " + toRect);

        // expand from camera
        fromCamera.rect = toRect;

        // switich display
        if (swithDisplay)
        {
            int tempDisplay = fromCamera.targetDisplay;
            fromCamera.targetDisplay = toCamera.targetDisplay;
            toCamera.targetDisplay = tempDisplay;
        }

        // shrink to camera
        toCamera.rect = fromRect;
    }
}
