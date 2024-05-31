using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FisicasAgarre : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private Transform originalParent;

    public float returnSpeed = 1.0f; // Velocidad a la que el objeto regresa a su posición original

    // Start is called before the first frame update
    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        originalParent = transform.parent;
        originalPosition = transform.localPosition;
        originalRotation = transform.localRotation;

        grabInteractable.onSelectExited.AddListener(OnRelease);
    }

    private void OnRelease(XRBaseInteractor interactor)
    {
        StartCoroutine(ReturnToOriginalPosition());
    }

    private IEnumerator ReturnToOriginalPosition()
    {
        yield return new WaitForEndOfFrame(); // Espera un frame para asegurar que la física se haya aplicado

        float elapsedTime = 0.0f;
        Vector3 startPosition = transform.localPosition;
        Quaternion startRotation = transform.localRotation;

        while (elapsedTime < 1.0f)
        {
            transform.localPosition = Vector3.Lerp(startPosition, originalPosition, elapsedTime * returnSpeed);
            transform.localRotation = Quaternion.Lerp(startRotation, originalRotation, elapsedTime * returnSpeed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = originalPosition;
        transform.localRotation = originalRotation;
        transform.SetParent(originalParent);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
