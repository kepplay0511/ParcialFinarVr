using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlaySoundOnCollision : MonoBehaviour
{
    public AudioClip soundClip; // El archivo de sonido
    public GameObject objectToActivate; // El objeto que queremos activar/desactivar
    private AudioSource audioSource;
    public float loopStartTime = 2f; // Tiempo en segundos desde donde comenzará el loop
    private Coroutine loopCoroutine;

    void Start()
    {
        // Agrega un AudioSource al cubo si no tiene uno
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = soundClip;
        audioSource.playOnAwake = false; // Asegúrate de que no se reproduzca al inicio
        audioSource.enabled = false; // Desactiva el AudioSource inicialmente

        // Asegúrate de que el objeto esté desactivado al inicio
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(false);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Verifica si el objeto con el que colisiona es la llave
        if (collision.gameObject.CompareTag("Key"))
        {
            // Activa el AudioSource
            audioSource.enabled = true;
            // Comienza a reproducir el sonido
            audioSource.Play();
            // Activa el objeto
            if (objectToActivate != null)
            {
                objectToActivate.SetActive(true);
            }
            // Inicia la corrutina para manejar el loop del sonido
            loopCoroutine = StartCoroutine(LoopAudio());
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // Verifica si el objeto que deja de colisionar es la llave
        if (collision.gameObject.CompareTag("Key"))
        {
            // Detiene el sonido
            audioSource.Stop();
            // Detiene la corrutina si está corriendo
            if (loopCoroutine != null)
            {
                StopCoroutine(loopCoroutine);
                loopCoroutine = null;
            }
            // Desactiva el AudioSource
            audioSource.enabled = false;
            // Desactiva el objeto
            if (objectToActivate != null)
            {
                objectToActivate.SetActive(false);
            }
        }
    }

    IEnumerator LoopAudio()
    {
        // Espera hasta que el sonido alcance la parte final que queremos hacer loop
        yield return new WaitForSeconds(audioSource.clip.length - loopStartTime);

        // Habilita el loop del audio
        audioSource.loop = true;
        audioSource.time = loopStartTime;
        audioSource.Play();
    }
}
