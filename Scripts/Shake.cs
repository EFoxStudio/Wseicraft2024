using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    private Transform camTransform;
    private Vector3 originalPosition;

    public float shakeDuration = 0.5f;
    public float shakeAmount = 0.1f;
    public float decreaseFactor = 1.0f;

    void Start()
    {
        camTransform = GetComponent<Transform>();
        originalPosition = camTransform.localPosition;
    }

    void Update()
    {
        //ShakeCam();
        if (shakeDuration > 0)
        {
            Debug.Log("SHAKEEEE");
            camTransform.localPosition = originalPosition + Random.insideUnitSphere * shakeAmount;

            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shakeDuration = 0f;
            camTransform.localPosition = originalPosition;
        }
    }

    public void ShakeCam(float force)
    {
        shakeAmount = force;
        Debug.Log("SHAKEEEE2");
        shakeDuration = 0.5f;
    }
}
