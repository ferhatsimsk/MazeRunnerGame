using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondCameraFollow : MonoBehaviour
{
    public Transform target; // Takip edilecek hedef (Player)

    public float smoothSpeed = 0.125f; // Kamera takibinin yumu�akl���
    public Vector3 offset; // Hedefe g�re kamera pozisyonunun ofset de�eri

    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset; // Hedefin pozisyonuna ofset eklenir
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // Takip pozisyonu yumu�at�l�r

        transform.position = smoothedPosition; // Kameran�n pozisyonu g�ncellenir
    }
}
