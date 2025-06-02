using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class CharacterStats : MonoBehaviour
{


    public int maxHealth = 100;
    public int currentHealth { get; private set; }

    public Stat damage;
    public Stat armor;

    public TMP_Text text;


    void Awake()
    {
        currentHealth = maxHealth;
    }

    
    public void TakeDamage(int damage)
    {
       
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

      
        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");

    
        if (currentHealth <= 0)
        {
            if (gameObject.CompareTag("Player"))
            {
                GameOver();
            }else
            {
                Die();
            }
          
        }
    }


    public IEnumerator GameOver()
    {
        text.text = " Game Over";
        text.gameObject.SetActive(true); // Show
        yield return new WaitForSeconds(3); // Wait
        text.gameObject.SetActive(false); // Hide
        SceneManager.LoadScene("Menu");
    }

    public virtual void Die()
    {

        EntityManager.entities--;

        Destroy(gameObject);

        Debug.Log(transform.name + " died.");
    }

}