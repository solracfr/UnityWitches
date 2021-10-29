using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// attribute that requires Enemy.cs to be present whenever this script is present
// whenever you attach this script to a GameObject, Enemy.cs will pop up as well
// if you try to delete Enemy.cs first from a GameObject, error message will appear
[RequireComponent(typeof(Enemy))] 
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    [Tooltip("Adds amount to maxHitPoints when enemy dies.")]
    [SerializeField] int difficultyRamp = 1;
    int currentHitPoints = 0;
    Enemy enemy;
    // Start is called before the first frame update
    void OnEnable()
    {
        currentHitPoints = maxHitPoints;
    }

    void Start()
    {
        enemy = GetComponent<Enemy>(); // this works because Enemy.cs is also attached to this object
    }

    void OnParticleCollision(GameObject other) 
    {
        ProcessHit();
        
    }

    void ProcessHit()
    {
        currentHitPoints--;

        if (currentHitPoints <= 0)
        {
            gameObject.SetActive(false);
            maxHitPoints += difficultyRamp; // enemies get more health each time they die
            enemy.RewardGold();
        }
            
    }
}
