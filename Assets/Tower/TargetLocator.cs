using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    Transform target;
    [SerializeField] float range = 15f;
    [SerializeField] ParticleSystem projectileParticles;
    [SerializeField] Transform weapon;
    
    void Update()
    {
        FindClosestEnemy();
        AimWeapon();
    }

    void FindClosestEnemy()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach(var enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if(distance < maxDistance)
            {
                closestTarget = enemy.transform;
                maxDistance = distance;
            }
        }
        target = closestTarget;
    }

    void AimWeapon()
    {
        float targetDistance = Vector3.Distance(transform.position, target.transform.position);
        bool attack = targetDistance <= range;
        Attack(attack);
        weapon.LookAt(target);
    }
    void Attack(bool active)
    {
        var emission = projectileParticles.emission;
        emission.enabled = active;
    }
}
