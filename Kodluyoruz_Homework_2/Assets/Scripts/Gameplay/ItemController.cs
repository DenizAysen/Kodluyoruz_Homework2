using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    Rigidbody rb;


    private void OnEnable()
    {
        rb = GetComponent<Rigidbody>();

        CancelInvoke("Shut_Down");

        Invoke("Shut_Down", 4.0f);
    }

    private void OnDisable()
    {

        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    void Shut_Down()
    {
        gameObject.SetActive(false);
    }
}
