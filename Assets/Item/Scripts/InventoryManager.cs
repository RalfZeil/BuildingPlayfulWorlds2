using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    [SerializeField] private Slot[] slotsArray;
    [SerializeField] private TextMeshProUGUI attackDamageTMP;
    [SerializeField] private TextMeshProUGUI healthTMP;
    [SerializeField] private TextMeshProUGUI enemiesRemainingTMP;

    private int remainingEnemies;

    private void Start()
    {
        if(Instance == null) { Instance = this; }
        else { Debug.LogWarning("Instance of InventoryManager is already assigned"); }

        remainingEnemies = FindObjectOfType<EnemyAI>().enemies.Count;
        UpdateEnemies(null);
    }

    private void OnEnable()
    {
        EventManager<Item>.AddListener(EventType.OnItemPickup, PickupItem);
        EventManager<Unit>.AddListener(EventType.OnTakeDamage, UpdateHealth);
        EventManager<Unit>.AddListener(EventType.OnUnitDeath, UpdateEnemies);
    }

    private void OnDisable()
    {
        EventManager<Item>.RemoveListener(EventType.OnItemPickup, PickupItem);
        EventManager<Unit>.RemoveListener(EventType.OnTakeDamage, UpdateHealth);
        EventManager<Unit>.RemoveListener(EventType.OnUnitDeath, UpdateEnemies);
    }

    private void UpdateHealth(Unit unit)
    {
        if (unit.IsPlayerUnit())
        {
            healthTMP.text = "Health: " + unit.GetComponent<UnitHealthSystem>().GetHealth();
        }
    }

    private void UpdateEnemies(Unit unit)
    {
        if(unit != null)
        {
            if (!unit.IsPlayerUnit())
            {
                remainingEnemies--;

                if(remainingEnemies == 0)
                {
                    SceneManager.LoadScene(2);
                }

            }
        }
         enemiesRemainingTMP.text = "Enemies remaining: " + remainingEnemies;
    }

    public void PickupItem(Item item)
    {
        foreach(Slot slot in slotsArray)
        {
            if(slot.GetCurrentAssignedItem() == null)
            {
                //Slot is free
                slot.AssignItem(item);
                attackDamageTMP.text = "Attack damage: " + item.attackDamage;
                break;
            }
        }
    }
}
