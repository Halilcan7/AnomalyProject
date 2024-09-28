using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    //sol,sağ,arkaya giderken animasyon değişikliği yapılacak ve karakterin hızı yavaşlayacak

    private Rigidbody rg;
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float lowspeed = 3f;
    private Camera Cam;
    public float sens = 3f;
    private float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cam = Camera.main;
        rg = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Walking();
        Mouse();
    }
    void Mouse()
    {
        float mouseX = Input.GetAxis("Mouse X") * sens;
        float mouseY = Input.GetAxis("Mouse Y") * sens;

        transform.Rotate(Vector3.up * mouseX);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        Cam.transform.localRotation = Quaternion.Euler(xRotation,0f,0f);
    }
    void Walking()
    {
        if(Input.GetKey(KeyCode.W))
        {
           rg.velocity = transform.forward * speed;
        }
        if(Input.GetKey(KeyCode.S))
        {
           rg.velocity = -transform.forward * lowspeed;
        }
        if(Input.GetKey(KeyCode.A))
        {
           rg.velocity = -transform.right * lowspeed;
        }
        if(Input.GetKey(KeyCode.D))
        {
           rg.velocity = transform.right * speed;
        }
    }
}
