using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class DollyCameraCoordinator : MonoBehaviour
{
    public float pathPosition = 0.0f;

    public float speed = 0.1f;

    public float buffer = 2f;

    private CinemachineVirtualCamera Dolly;

    private CinemachineTrackedDolly DollyPath;

    private bool isAcending = true;

    // Start is called before the first frame update
    void Start()
    {
        Dolly =
            gameObject.GetComponent(typeof (CinemachineVirtualCamera)) as
            CinemachineVirtualCamera;

        if (Dolly)
        {
            Debug.Log("dolly found ");
            DollyPath =
                Dolly.GetCinemachineComponent<CinemachineTrackedDolly>();
        }
        else
        {
            Debug.Log("dolly not found ");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (DollyPath)
        {
            if (isAcending)
            {
                if (pathPosition <= 1 + buffer)
                {
                    pathPosition += speed;
                    DollyPath.m_PathPosition = pathPosition;
                }
                else
                {
                    isAcending = false;
                }
            }
            else
            {
                if (pathPosition >= -(1 + buffer))
                {
                    pathPosition -= speed;
                    DollyPath.m_PathPosition = pathPosition;
                }
                else
                {
                    isAcending = true;
                }
            }
        }
    }
}
