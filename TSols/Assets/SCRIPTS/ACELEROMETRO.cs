using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACELEROMETRO : MonoBehaviour
{
    [SerializeField] Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        print(Input.acceleration);
        
    }
    private void FixedUpdate()
    {
        Vector3 dir = new Vector3(Input.acceleration.x, Input.acceleration.y, -Input.acceleration.z);
        rb.AddForce(dir * 10);
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Entrar codigo para a Vibração do cell (Heptic Feedback)
    }
}
