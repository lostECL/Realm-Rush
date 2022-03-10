using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))] 
public class EnemyHealth : MonoBehaviour
{
    int maxHitPoints = 2;
    [Tooltip("Adds amount to max hitpoints when enemy dies")]
    [SerializeField] int difficultyRamp = 1;
    int currentHitPoints = 0;
    
    Enemy enemy;
    void OnEnable()
    {
        currentHitPoints = maxHitPoints;
    }

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }
    void OnParticleCollision(GameObject other) 
    {
        ProccessHit();
    }

    void ProccessHit()
    {
        currentHitPoints--;

        if(currentHitPoints <= 0)
        {
            gameObject.SetActive(false);
            maxHitPoints += difficultyRamp;
            enemy.RewardGold();
        }
    }
}
