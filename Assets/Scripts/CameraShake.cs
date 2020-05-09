using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Transform cameraTransform;

    private float shakeTime = 0f;

    public float shakeSize;

    public float shakeFade;

    Vector3 cameraPosition;

   
    void Awake()
    {
        if (cameraTransform == null)
        {
            cameraTransform = GetComponent<Transform>();
        }
    }

    void OnEnable()
    {
        cameraPosition = cameraTransform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (shakeTime > 0)
        {
            cameraTransform.localPosition = cameraPosition + Random.insideUnitSphere * shakeSize;

            shakeTime -= Time.deltaTime * shakeFade;
        }

        else
        {
            shakeTime = 0f;
            cameraTransform.localPosition = cameraPosition;
        }
    }

    public void Shake()
    {
        shakeTime = 1.0f;
    }
}
