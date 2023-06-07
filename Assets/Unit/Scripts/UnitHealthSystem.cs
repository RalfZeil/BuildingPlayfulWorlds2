using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class UnitHealthSystem : MonoBehaviour
{

    [SerializeField] private int health;
    [SerializeField] private int maxHealth = 100;

    private void Start()
    {
        health = maxHealth;
    }

    public void Damage(int damageAmount)
    {
        health -= damageAmount;

        if(health < 0)
        {
            health = 0;
        }

        if(health == 0)
        {
            Die();
        }
    }

    private void Die()
    {
        EventManager<Unit>.RaiseEvent(EventType.OnUnitDeath, GetComponent<Unit>());
    }
}
