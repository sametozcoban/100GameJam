using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControl : MonoBehaviour
{
    [SerializeField] private int bossHealth = 10;
    [SerializeField] private int bossSpeed = 6;
    [SerializeField] private int bossDamage = 1;

    public Transform[] patrolPoints ;  // Belirli alanlarda gidip gelmek için noktalar
    public float gizmoSphereRadius = 0.2f;
    
    private int currentPatrolIndex = 0;


    void Start()
    {
        transform.position = patrolPoints[currentPatrolIndex].transform.position;
    }

    void Update()
    {
        if (bossHealth == 0)
        {
            //dead;
        }
        if (currentPatrolIndex <= patrolPoints.Length - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position,
                patrolPoints[currentPatrolIndex].transform.position, bossSpeed);
            if (transform.position == patrolPoints[currentPatrolIndex].transform.position)
            {
                currentPatrolIndex += 1;
            }

            if (currentPatrolIndex == patrolPoints.Length)
            {
                currentPatrolIndex = 0;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            bossHealth -= 1;
        }
    }

    void OnDrawGizmos()
    {
        // Gizmo olarak belirtilen alanları göster
        Gizmos.color = Color.green;
        foreach (Transform point in patrolPoints)
        {
            Gizmos.DrawSphere(point.position, gizmoSphereRadius);
        }
    }
}
