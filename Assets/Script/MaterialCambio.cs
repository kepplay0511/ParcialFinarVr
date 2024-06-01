using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    public Renderer[] objectRenderers; // Lista de Renderers de los objetos cuyo material deseas cambiar
    public Material newMaterial; // El nuevo material que deseas asignar a los objetos

    public void ChangeObjectsMaterial()
    {
        if (objectRenderers != null && objectRenderers.Length > 0 && newMaterial != null)
        {
            // Asigna el nuevo material a cada objeto en la lista
            foreach (Renderer renderer in objectRenderers)
            {
                renderer.material = newMaterial;
            }
        }
        else
        {
            Debug.LogWarning("Object renderers array or new material is not assigned!");
        }
    }
}
