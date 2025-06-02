using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
/* Base class that player and enemies can derive from to include stats. */

public class CharacterStats : MonoBehaviour
{

    // Health
    public int maxHealth = 100;
    public int currentHealth { get; private set; }

    public Stat damage;
    public Stat armor;

    public TMP_Text text;

    // Set current health to max health
    // when starting the game.
    void Awake()
    {
        currentHealth = maxHealth;
    }

    // Damage the character
    public void TakeDamage(int damage)
    {
        // Subtract the armor value
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        // Damage the character
        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");

        // If health reaches zero
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