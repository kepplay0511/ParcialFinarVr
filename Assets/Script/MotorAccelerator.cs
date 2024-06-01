using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MotorAccelerator : MonoBehaviour
{
    public AudioSource audioSource;
    public float maxVolume = 1.0f; // Volumen m�ximo del audio
    public float rotationFactor = 0.1f; // Factor de rotaci�n para ajustar el volumen
    public float minRotation = 1.077f; // M�nima rotaci�n permitida en grados
    public float maxRotation = 60f; // M�xima rotaci�n permitida en grados
    public float loopStartTime = 0.4f; // Tiempo de inicio del bucle en segundos
    public float loopEndTime = 1.3f; // Tiempo de fin del bucle en segundos

    private Quaternion initialRotation;
    private Vector3 initialPosition;
    private XRGrabInteractable grabInteractable;

    private bool looping = false;
    private int loopStartSample;
    private int loopEndSample;

    private void Start()
    {
        initialRotation = transform.rotation;
        initialPosition = transform.position;
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.onSelectEntered.AddListener(OnGrab);
        grabInteractable.onSelectExited.AddListener(OnRelease);

        // Desactiva el componente AudioSource al inicio
        audioSource.Stop();
        audioSource.enabled = false;

        // Calcula el punto de inicio y fin del bucle en muestras
        loopStartSample = Mathf.FloorToInt(Mathf.Clamp(loopStartTime, 0f, (float)audioSource.clip.samples / audioSource.clip.frequency) * audioSource.clip.frequency);
        loopEndSample = Mathf.FloorToInt(Mathf.Clamp(loopEndTime, 0f, (float)audioSource.clip.samples / audioSource.clip.frequency) * audioSource.clip.frequency);
    }

    private void OnGrab(XRBaseInteractor interactor)
    {
        // Activa el componente AudioSource al ser agarrado
        audioSource.enabled = true;
        audioSource.Play();
        looping = true;
    }

    private void OnRelease(XRBaseInteractor interactor)
    {
        audioSource.Stop();
        audioSource.enabled = false;
        looping = false;

        transform.rotation = initialRotation;
        transform.position = initialPosition;
    }

    private void Update()
    {
        // Limita el �ngulo de rotaci�n en el eje Z dentro del rango permitido
        float rotationZ = Mathf.Clamp(transform.rotation.eulerAngles.z, minRotation, maxRotation);

        // Ajustar el volumen del audio seg�n la rotaci�n en el eje Z del rect�ngulo
        float volume = Mathf.Clamp01((rotationZ - minRotation) / (maxRotation - minRotation) * rotationFactor);
        audioSource.volume = volume * maxVolume;

        // Si estamos en modo de bucle y el audio alcanza el final del bucle, volvemos al inicio del bucle
        if (looping && audioSource.timeSamples >= loopEndSample)
        {
            audioSource.timeSamples = loopStartSample;
        }
    }
}

