using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
   Animator animator;
    bool isMainCamera = true;

    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            cameraChange();
        }
        
    }

    void cameraChange()
    {
        if (isMainCamera)
        {
            animator.Play("anaKamera");
        }
        else
        {
            animator.Play("ekKamera");
        }
        isMainCamera = !isMainCamera;
    }
}
