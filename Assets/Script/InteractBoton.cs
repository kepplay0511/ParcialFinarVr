using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class InteractBoton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<XRPushButton>().selectEntered.AddListener(e => DoorAction());
    }

    // Update is
    //
    //
    // called once per fram
    //
    //
    //
    // e


    public void DoorAction( )

    {
        Debug.Log("click");
    }

    void Update()
    {
        
        
    }
}
