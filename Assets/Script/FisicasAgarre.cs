using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FisicasAgarre : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private Transform originalParent;

    // Start is called before the first frame update
    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        originalParent = GetComponent<Transform>();
        grabInteractable.onSelectExited.AddListener(OnRelease);
        
    }

    private void OnRelease(XRBaseInteractor interactor)
    {
        if (originalParent != null)
        {
            transform.SetParent(originalParent);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.localScale = Vector3.one;

        }
        else
        {
            Debug.LogWarning("El objeto no tinene padre original");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
 }
