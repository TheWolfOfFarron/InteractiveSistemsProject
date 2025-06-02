using System.Collections;
using TMPro;
using UnityEngine;

public class Enemy_stats : MonoBehaviour
{

    [field: SerializeField] public int Hp { get; private set; }

    public TMP_Text healthText;

    [SerializeField]  public Player_Stats playerHealth;


    private void Update()
    {
        healthText.text= $"HP ENEMY: {Hp}";

        if (Turn.turn == false)
        {
          
            EnemyTakeTurn();

            Turn.turn = true;
            Turn.startTurn = true;
            playerHealth.TakeDamage(10);
        }
    }


    public void EnemyTakeTurn()
    {
        StartCoroutine(EnemyThinkingRoutine());
    }

    private IEnumerator EnemyThinkingRoutine()
    {
        Debug.Log("Enemy is thinking...");
        yield return new WaitForSeconds(1.5f); // Delay to simulate thinking
      
     
    }

    public void TakeDamage(int amount)
    {
        Hp -= amount;
        Debug.Log("Player takes " + amount + " damage! HP left: " + Hp);

        if (Hp <= 0)
        {
            Die();
        }
    }

    void Die()
    {

    }

}
