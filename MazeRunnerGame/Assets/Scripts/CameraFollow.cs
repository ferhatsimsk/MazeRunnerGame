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
    //public Transform secondCameraTransform; // Ýkinci kameranýn transform bileþeni

    //private Camera mainCamera; // Birinci kamera
    //private Camera secondCamera; // Ýkinci kamera

    //private void Start()
    //{
    //    mainCamera = GetComponent<Camera>(); // Birinci kamerayý al
    //    secondCamera = secondCameraTransform.GetComponent<Camera>(); // Ýkinci kamerayý al

    //    mainCamera.enabled = true; // Baþlangýçta birinci kamera etkin olsun
    //    secondCamera.enabled = false; // Baþlangýçta ikinci kamera devre dýþý olsun
    //}

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.H))
    //    {
    //        mainCamera.enabled = !mainCamera.enabled; // Birinci kamera durumunu tersine çevir
    //        secondCamera.enabled = !secondCamera.enabled; // Ýkinci kamera durumunu tersine çevir

    //        if (secondCamera.enabled)
    //        {
    //            // Ýkinci kameranýn transform bileþenini ayarla
    //            secondCameraTransform.position = mainCamera.transform.position;
    //            secondCameraTransform.rotation = mainCamera.transform.rotation;
    //        }
    //    }
    //}
}
