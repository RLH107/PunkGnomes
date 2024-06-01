using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TodasTorres : MonoBehaviour
{
    [SerializeField] private float TCoolDown;
    [SerializeField] private float TSpeed;
    [SerializeField] private float PForce;

    [SerializeField] private float AngleBeforeFire;

    [SerializeField] private int NumberOfProjectiles;
    [SerializeField] private GameObject Projectile;
    [SerializeField] private Transform ProjectileSootPosition;

    Projetil ProjetilScript;

    [HideInInspector] public List<Projetil> ProjetilsScripts;
    [HideInInspector] public List<Transform> EnemysTransforms;

    private EnemyTags EnemyTags_Script;


    private bool Active;
    private int NPorjectile;
    private float FCooldown;
    private enum TState
    {
        IDLE,
        AIM,
        Cooldown,
        FIRE,
    }
    private TState TowerState;

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    private void Start()
    {
        FCooldown = TCoolDown;
        NPorjectile = 0;
        Active = false;
        EnemyTags_Script = GameObject.Find("LevelMeneger").GetComponent<EnemyTags>();
        for (int i = NumberOfProjectiles; i > 0; i--)
        {
            GameObject gameObject;
            gameObject = Instantiate(Projectile, new Vector3(transform.position.x + -10, transform.position.y + -20 + i * 5, transform.position.z - 10), Quaternion.identity);

            ProjetilScript = gameObject.GetComponent<Projetil>();
            ProjetilsScripts.Add(ProjetilScript);
            ProjetilScript.ProjectileWatingPos(new Vector3(transform.position.x + -10, transform.position.y + -20 + i * 5, transform.position.z - 10));
        }
        TowerStateSwitch(TState.IDLE);
    }

    /// <summary>
    /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    /// <param name="T_state"></param>

    private void TowerStateSwitch(TState T_state)
    {
        TowerState = T_state;
        switch (TowerState)
        {
            case TState.IDLE:
                StartCoroutine(IDLE());
                break;
            case TState.AIM:
                StartCoroutine(AIM());
                break;
        }
    }
    private IEnumerator IDLE()
    {
        if (EnemysTransforms.Count >= 0 && Active == false)
        {
            Active = true;
            TowerStateSwitch(TState.AIM);
        }
        yield return null;
    }
    //Tower Aims At TargetEnemy
    private IEnumerator AIM()
    {
        yield return null;
        //Selects the first target From List and Aims twords it
        while (EnemysTransforms.Count > 0)
        {
            Transform target = EnemysTransforms[0];
            Vector3 targetDirection = target.position - transform.position;

            Quaternion RotateTo = Quaternion.LookRotation(targetDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, RotateTo, TSpeed);

            float angle = Quaternion.Angle(transform.rotation, RotateTo);
            if (angle < AngleBeforeFire)
            {
                //Fires Projectile
                Fire();
            }
            yield return new WaitForFixedUpdate();
        }
        if (EnemysTransforms.Count == 0 && Active == true)
        {
            Active = false;
            TowerStateSwitch(TState.IDLE);
        }

    }

    /// <summary>
    /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    /// <param name="other"></param>


    // ADD /////////// Adds to Target List
    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < EnemyTags_Script.ReturnEnemyTags_Length(); i++)
        {
            if (other.gameObject.tag == EnemyTags_Script.ReturnEnemyTags(i))
            {
                EnemysTransforms.Add(other.transform);
            }
        }



        /*
        if (other.gameObject.tag == "ENEMY")
        {
            EnemysTransforms.Add(other.transform);
        }
        */
    }

    // REMOVE ///////////////// Removes From Target List
    private void OnTriggerExit(Collider other)
    {
        for (int i = 0; i < EnemyTags_Script.ReturnEnemyTags_Length(); i++)
        {
            if (other.gameObject.tag == EnemyTags_Script.ReturnEnemyTags(i))
            {
                EnemysTransforms.Remove(other.transform);
            }
        }




        /*
        if (other.gameObject.tag == "ENEMY")
        {
            EnemysTransforms.Remove(other.transform);
        }
        */
    }

    private void Fire()
    {
        //Takes Time out of cooldown
        FCooldown = FCooldown - Time.deltaTime;

        //Is cooldown UP?
        if (FCooldown <= 0)
        {
            //Gets Script From List
            ProjetilScript = ProjetilsScripts[NPorjectile];

            //Calles Function From Projectile Script
            ProjetilScript.MoveProjectil(ProjectileSootPosition, PForce);

            //Next Projectile
            NPorjectile++;

            //Stops Next Projectile From Being NULL
            if (NPorjectile >= ProjetilsScripts.Count)
            {
                NPorjectile = 0;
            }

            //Resets Cooldown
            FCooldown = TCoolDown;
        }
    }

    //Moves Tower To New Position
    public void MoveTower(Vector3 moveTo)
    {
        transform.position = moveTo;
    }

    //Maybe?
    private void Dead()
    {

    }
}
