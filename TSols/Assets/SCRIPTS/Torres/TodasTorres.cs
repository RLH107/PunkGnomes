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
        yield return null;
        while (EnemysTransforms.Count == 0)
        {
            yield return new WaitForEndOfFrame();
        }
        TowerStateSwitch(TState.AIM);
    }
    private IEnumerator AIM()
    {
        yield return null;
        //Selects a target From List and Aims twords it
        while (EnemysTransforms.Count > 0)
        {
            Transform target = EnemysTransforms[0];
            Vector3 targetDirection = target.position - transform.position;

            Quaternion RotateTo = Quaternion.LookRotation(targetDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, RotateTo, TSpeed);

            float angle = Quaternion.Angle(transform.rotation, RotateTo);
            if (angle < AngleBeforeFire)
            {
                Fire();
            }
            yield return new WaitForEndOfFrame();
        }
        if (EnemysTransforms.Count == 0)
        {
            TowerStateSwitch(TState.IDLE);
        }

    }

    /// <summary>
    /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    /// <param name="other"></param>

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ENEMY")
        {
            EnemysTransforms.Add(other.transform);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "ENEMY")
        {
            EnemysTransforms.Remove(other.transform);
        }
    }

    private void Fire()
    {
        if (FCooldown <= 0)
        {
            ProjetilScript = ProjetilsScripts[NPorjectile];

            ProjetilScript.MoveProjectil(ProjectileSootPosition, PForce);

            NPorjectile++;
            if (NPorjectile >= ProjetilsScripts.Count)
            {
                NPorjectile = 0;
            }

            FCooldown = TCoolDown;
        }
        FCooldown = FCooldown - Time.deltaTime;
    }

    public void MoveTower(Vector3 moveTo)
    {
        transform.position = moveTo;
    }

    private void Dead()
    {

    }
}
