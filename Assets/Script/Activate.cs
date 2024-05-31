using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateOnCollision : MonoBehaviour
{
    public GameObject objectToActivate1;
    public GameObject objectToActivate2;

    private void OnCollisionEnter(Collision collision)
    {
        // Verificar si el objeto con el que colisionamos tiene la etiqueta "Mano"
        if (collision.gameObject.CompareTag("Key"))
        {
            // Activar los dos objetos
            if (objectToActivate1 != null)
            {
                objectToActivate1.SetActive(true);
            }

            if (objectToActivate2 != null)
            {
                objectToActivate2.SetActive(true);
            }
        }
    }
}
