using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil : MonoBehaviour
{
    Inimigo_Base Inimigo_BaseScript;
    private Vector3 WatingPos;
    [SerializeField] private float Demege;
    [SerializeField] private Rigidbody rb;
    private EnemyTags EnemyTags_Script;

    private void Start()
    {
        EnemyTags_Script = GameObject.Find("LevelMeneger").GetComponent<EnemyTags>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Tower")
        {
            transform.position = WatingPos;
            rb.velocity = new Vector3(0, 0, 0);



            for (int i = 0; i < EnemyTags_Script.ReturnEnemyTags_Length(); i++)
            {
                if (other.gameObject.tag == EnemyTags_Script.ReturnEnemyTags(i))
                {
                    Inimigo_BaseScript = other.GetComponent<Inimigo_Base>();
                    Inimigo_BaseScript.TakeDamege(Demege);
                }
            }
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
