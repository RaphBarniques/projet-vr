using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Dongle : MonoBehaviour
{/*
    public XRSocketInteractor xrSocket;
    // Start is called before the first frame update
    void Start()
    {
        xrSocket = GetComponent<XRSocketInteractor>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReturnToSocket()
    {   

        if (xrSocket && xrSocket.selectTarget == null)
        {
            // Check if the object is not already in another socket
            if (!IsInSocket())
            {
                // Move the object to the XR socket's position
                transform.position = xrSocket.selectTarget.position;
            }
        }
        
    }

    bool IsInSocket()
    {
        // Check if the object is a child of any XRSocketInteractor
        XRSocketInteractor[] sockets = FindObjectsOfType<XRSocketInteractor>();
        foreach (var socket in sockets)
        {
            if (socket != xrSocket && socket.selectTarget == transform)
            {
                return true;
            }
        }
        return false;
    }
*/}
