using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Stats : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public Enemy_stats enemy;

    public HandView handView;

    private bool safeStart=true;

    public TMP_Text healthText;

    void Start()
    {
        currentHealth = maxHealth;

        for(int i = 0; i < 3; i++)
        {

            CardData cardData = Resources.Load<CardData>("Cards/FireBall");

            Card card = new(cardData);
            CardView cardView = CardViewCreator.Instance.createCardView(card, transform.position, Quaternion.identity);
            StartCoroutine(handView.addCard(cardView));
        }
    }


    private void Update()
    {

        healthText.text = $"Your HP: {currentHealth}";

        if (Turn.turn == true)
        {
            if(Turn.startTurn == true && safeStart==true)
            {
                safeStart = false;
                // de adaugat mai multe carti daca e timp

                CardData cardData = Resources.Load<CardData>("Cards/FireBall");

                Card card = new(cardData);
                CardView cardView = CardViewCreator.Instance.createCardView(card, transform.position, Quaternion.identity);
                StartCoroutine(handView.addCard(cardView));
                Turn.startTurn = false;

                Debug.LogError("carte noua");


            }

            if(Turn.startTurn == false)
            {
                safeStart=true;
            }

            if (Input.GetKeyDown(KeyCode.E)) {
                if (Turn.selectedCard != null)
                {
                    //DACA MAI E TIMP ADAUGAM CARTIILE
                    enemy.TakeDamage(1);

                    Turn.turn = false;
                    Debug.LogError("yftgujkl");
                    StartCoroutine(handView.removeCard(Turn.selectedCard));



                    Debug.LogError("nextTurn");

                }
                Debug.LogError("E");
            
            }
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log("Player takes " + amount + " damage! HP left: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player has been defeated!");
        SceneManager.LoadScene("DemoArena");
    }

}
