using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float EnemySpeed = 3.0f; 
    public float chaseSpeed = 5.0f;  
    public float EnemyRadius = 10.0f; 
    public float chaseRadius = 5.0f; 

    private Transform player;
    private Vector3 EnemyPoint;
    private bool isChasing = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        SetRandomPatrolPoint();
    }

    void Update()
    {
        if (isChasing)
        { 
            ChasePlayer();
        }
        else
        {
            
            Enemy3();
        }

        
        if (Vector3.Distance(transform.position, player.position) < chaseRadius)
        {
            isChasing = true;
        }
        else
        {
            isChasing = false;
        }
    }

    void Enemy3()
    {
        
        transform.Translate((EnemyPoint - transform.position).normalized * EnemySpeed * Time.deltaTime);

        
        if (Vector3.Distance(transform.position, EnemyPoint) < 0.2f)
        {
            SetRandomPatrolPoint();
        }
    }

    void ChasePlayer()
    {
        
        transform.Translate((player.position - transform.position).normalized * chaseSpeed * Time.deltaTime);
    }

    void SetRandomPatrolPoint()
    {
        
        EnemyPoint = new Vector3(Random.Range(-EnemyRadius, EnemyRadius), 0f, Random.Range(-EnemyRadius, EnemyRadius));
    }
}
