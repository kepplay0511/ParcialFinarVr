using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class Elevador : MonoBehaviour
{
    public XRLever elevador;

    public float speed;
 

    // Update is called once per frame
    void Update()
    {
        float udSpeed = speed * (elevador.value ? 1 : 0);
        
        Vector3 velocity = new Vector3(0, udSpeed, 0);

        transform.position += velocity * Time.deltaTime; ;
    }
}
