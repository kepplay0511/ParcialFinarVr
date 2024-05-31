using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class EncenderObjetoAlTocar : MonoBehaviour
{
    public GameObject objetoParaEncender; // Objeto que se encenderá al tocar
    private XRGrabInteractable grabInteractable;

    // Start is called before the first frame update
    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();

        if (grabInteractable != null)
        {
            grabInteractable.onHoverEntered.AddListener(OnHandTouch);
        }
        else
        {
            Debug.LogWarning("XRGrabInteractable no encontrado en el objeto");
        }

        if (objetoParaEncender != null)
        {
            objetoParaEncender.SetActive(false); // Asegúrate de que el objeto esté inicialmente desactivado
        }
        else
        {
            Debug.LogWarning("El objeto para encender no ha sido asignado");
        }
    }

    private void OnHandTouch(XRBaseInteractor interactor)
    {
        if (objetoParaEncender != null)
        {
            objetoParaEncender.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDestroy()
    {
        if (grabInteractable != null)
        {
            grabInteractable.onHoverEntered.RemoveListener(OnHandTouch);
        }
    }
}
