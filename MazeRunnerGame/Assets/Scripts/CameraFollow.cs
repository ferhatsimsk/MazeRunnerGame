using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    void Start()
    {
        player = GameObject.Find("Player");
    }


    void Update()
    {
        transform.position = new Vector3(player.transform.position.x + 3, player.transform.position.y + 4, player.transform.position.z);
    }

    //public Transform target; // Takip edilecek hedef (Player)
    //public Transform secondCameraTransform; // �kinci kameran�n transform bile�eni

    //private Camera mainCamera; // Birinci kamera
    //private Camera secondCamera; // �kinci kamera

    //private void Start()
    //{
    //    mainCamera = GetComponent<Camera>(); // Birinci kameray� al
    //    secondCamera = secondCameraTransform.GetComponent<Camera>(); // �kinci kameray� al

    //    mainCamera.enabled = true; // Ba�lang��ta birinci kamera etkin olsun
    //    secondCamera.enabled = false; // Ba�lang��ta ikinci kamera devre d��� olsun
    //}

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.H))
    //    {
    //        mainCamera.enabled = !mainCamera.enabled; // Birinci kamera durumunu tersine �evir
    //        secondCamera.enabled = !secondCamera.enabled; // �kinci kamera durumunu tersine �evir

    //        if (secondCamera.enabled)
    //        {
    //            // �kinci kameran�n transform bile�enini ayarla
    //            secondCameraTransform.position = mainCamera.transform.position;
    //            secondCameraTransform.rotation = mainCamera.transform.rotation;
    //        }
    //    }
    //}
}
