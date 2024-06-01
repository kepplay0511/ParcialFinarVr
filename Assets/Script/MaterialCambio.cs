using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    public Renderer objectRenderer; // Referencia al Renderer del objeto cuyo material deseas cambiar
    public Material newMaterial; // El nuevo material que deseas asignar al objeto

    public void ChangeObjectMaterial()
    {
        if (objectRenderer != null && newMaterial != null)
        {
            // Asigna el nuevo material al objeto
            objectRenderer.material = newMaterial;
        }
        else
        {
            Debug.LogWarning("Object renderer or new material is not assigned!");
        }
    }
}
