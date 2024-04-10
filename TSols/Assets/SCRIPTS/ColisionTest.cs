using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionTest : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Sphere")
        {
            Debug.Log(collision.gameObject);
        }
    }
}
