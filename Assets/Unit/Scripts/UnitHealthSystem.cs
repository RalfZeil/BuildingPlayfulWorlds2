using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class UnitHealthSystem : MonoBehaviour
{

    [SerializeField] private int health;
    [SerializeField] private int maxHealth = 100;

    [SerializeField] private GameObject[] itemDrops;

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

    public int GetHealth()
    {
        return health;
    }

    private void Die()
    {
        EventManager<Unit>.RaiseEvent(EventType.OnUnitDeath, GetComponent<Unit>());

        if (!GetComponent<Unit>().IsPlayerUnit())
        {
            Instantiate(itemDrops[Random.Range(0, itemDrops.Length)], transform.position, Quaternion.identity);
        }

        GetComponent<UnitRagdollSpawner>().SpawnRagdoll();
        Destroy(gameObject);
    }

}
