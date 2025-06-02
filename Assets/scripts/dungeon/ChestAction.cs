using UnityEngine;

public class ChestAction : MonoBehaviour, IIntreactable
{
    [SerializeField] public int money;

    [SerializeField] public Inventory stats;


    public void Interact()
    {
        stats.addMoney(money);  
        Destroy(gameObject);
    }
}
