using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 10;
    [Tooltip("Adds difficultyRamp to maxHitPoints after enemy dies")]
    [SerializeField] int difficultyRamp = 1;
    int currentHitPoints = 0;

    Enemy enemy;
    
    void Start() 
    {
        enemy = GetComponent<Enemy>();
    }
    void OnEnable()
    {
        currentHitPoints = maxHitPoints;
    }
    void OnParticleCollision(GameObject other) 
    {
        currentHitPoints--;
        if(currentHitPoints < 1)
        {
            maxHitPoints += difficultyRamp;
            gameObject.SetActive(false);
            enemy.RewardGold();
        }
    }
    
}
