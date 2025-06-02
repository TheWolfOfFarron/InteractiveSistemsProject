using UnityEngine;

public class DealDamage : MonoBehaviour
{

    [SerializeField] private int damage;
    [SerializeField] private string Tag;


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("sa");
        if (other.CompareTag(Tag))
        {
            CharacterStats enemy = other.GetComponent<CharacterStats>();
            enemy.TakeDamage(damage);

            Debug.Log("damage");
             
        }
    }


}
