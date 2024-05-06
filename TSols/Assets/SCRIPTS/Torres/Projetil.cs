using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil : MonoBehaviour
{
    private Vector3 WatingPos;
    [SerializeField] private Rigidbody rb;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Tower")
        {
            transform.position = WatingPos;
            rb.velocity = new Vector3(0, 0, 0);
        }
    }

    public void ProjectileWatingPos(Vector3 WatingPosition)
    {
        WatingPos = WatingPosition;
    }

    public void MoveProjectil(Transform pos, float PForce)
    {
        rb.velocity = new Vector3(0, 0, 0);
        float NF = PForce + 100;
        transform.rotation = new Quaternion(pos.rotation.x, pos.rotation.y, pos.rotation.z, pos.rotation.w);
        transform.position = new Vector3(pos.position.x, pos.position.y, pos.position.z);
        rb.AddForce(transform.forward * NF, ForceMode.Force);
    }

}
