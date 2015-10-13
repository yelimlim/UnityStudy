using UnityEngine;
using System.Collections;

using System.Collections.Generic;

using System;

public class EnemyScript : MonoBehaviour 
{
    ENEMYSTATE enemyState = ENEMYSTATE.IDLE;

    delegate void StateFunc();
    Dictionary<ENEMYSTATE, Action> dicState = new Dictionary<ENEMYSTATE, Action>();

    float stateTime = 0.0f;
    public float idleStateMaxTime = 2.0f;

    Animation anim = null;

    Transform target = null;
    CharacterController characterController = null;

    public float moveSpeed = 5.0f;
    public float rotationSpeed = 10.0f;
    public float attackRange = 2.5f;

    public float attackStateMaxTime = 2.0f;

    int healthPoint = 5;

    void Awake()
    {
        anim = GetComponent<Animation>();
        InitSpider();
    }

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        characterController = GetComponent < CharacterController >();

        dicState[ENEMYSTATE.IDLE] = Idle;
        dicState[ENEMYSTATE.MOVE] = Move;
        dicState[ENEMYSTATE.ATTACK] = Attack;
        dicState[ENEMYSTATE.DAMAGE] = Damage;
        dicState[ENEMYSTATE.DEAD] = Dead;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            anim.Play("attack_Melee");
            anim.PlayQueued("iddle", QueueMode.CompleteOthers);
        }
        dicState[enemyState]();
    }

    void InitSpider()
    {
        enemyState = ENEMYSTATE.IDLE;
        anim.Play("iddle");
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name.Contains("Ball") == false)
        {
            return;
        }

        enemyState = ENEMYSTATE.DAMAGE;
    }

    void Idle()
    {
        stateTime += Time.deltaTime;
        if(stateTime > idleStateMaxTime)
        {
            stateTime = 0.0f;
            enemyState = ENEMYSTATE.MOVE;
        }
    }

    void Move()
    {
        anim.Play("walk");

        float distance = (target.position - transform.position).magnitude;
        if(distance < attackRange)
        {
            enemyState = ENEMYSTATE.ATTACK;
            stateTime = attackStateMaxTime;
        }
        else
        {
            Vector3 dir = target.position - transform.position;
            dir.y = 0.0f;
            dir.Normalize();
            characterController.SimpleMove(dir * moveSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), rotationSpeed * Time.deltaTime);
        }
    }
    void Attack()
    {
        stateTime += Time.deltaTime;
        float distance = (target.position - transform.position).magnitude;

        if(stateTime > attackStateMaxTime)
        {
            stateTime = 0.0f;
            anim.Play("attack_Melee");
            target.GetComponent<PlayerState>().DamageByEnemy();
            anim.PlayQueued("iddle", QueueMode.CompleteOthers);
        }

        if(distance >= attackRange)
        {
            stateTime = 0.0f;
            enemyState = ENEMYSTATE.IDLE;
        }
    }
    void Damage()
    {
        healthPoint -= 1;
        anim["damage"].speed = 0.5f;
        anim.Play("damage");
        anim.PlayQueued("iddle", QueueMode.CompleteOthers);

        stateTime = 0.0f;
        enemyState = ENEMYSTATE.IDLE;

        if(healthPoint <= 0)
        {
            enemyState = ENEMYSTATE.DEAD;
        }
    }
    void Dead()
    {
        GameObject.FindGameObjectWithTag("Manager").GetComponent<EnemyManager>().characterDead();
        Destroy(gameObject);
    }
}
