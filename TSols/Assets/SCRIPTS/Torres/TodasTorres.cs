using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TodasTorres : MonoBehaviour
{
    [SerializeField] private float TCoolDown;
    [SerializeField] private float TSpeed;
    [SerializeField] private float PSpeed;

    private float ListCheck;

    [HideInInspector] public List<GameObject> EnemysList;
    private enum TState
    {
        IDLE,
        AIM,
        Cooldown,
        FIRE,
    }
    private TState TowerState;
    void Start()
    {
        ListCheck = 20;
    }
    private void Update()
    {
       /*
        ListCheck -= Time.deltaTime;
        if (ListCheck >= 0)
        {
            ListCheck = 20;
            foreach(var item in EnemysList)
            {
                Debug.Log(item.ToString());
            }
        }
       */
    }

    /// <summary>
    /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
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
                StartCoroutine (AIM());
                break;
            case TState.Cooldown:
                StartCoroutine(Cooldown());
                break;
            case TState.FIRE:
                StartCoroutine(FIRE());
                break;
        }
    }
    private IEnumerator IDLE()
    {
        yield return null;
    }
    private IEnumerator AIM()
    {
        yield return null;
    }
    private IEnumerator Cooldown()
    {
        yield return null;
    }
    private IEnumerator FIRE()
    {
        yield return null;
    }

    /// <summary>
    /// /////////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    /// <param name="other"></param>

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ENEMY")
        {
            EnemysList.Add(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "ENEMY")
        {
            EnemysList.Remove(other.gameObject);
        }
    }

    private void Dead()
    {

    }
}
