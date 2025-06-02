using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/* This resorts combat for all characters. */

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{

    public float attackRate = 1f;
    private float attackCountdown = 0f;

    public event System.Action OnAttack;

    public TMP_Text healthBarPos;

    CharacterStats myStats;
    CharacterStats enemyStats;

    private Animator anim;


    void Start()
    {
        myStats = GetComponent<CharacterStats>();
        

        //HealthUIManager.instance.Create(healthBarPos, myStats);

        anim = GetComponent<Animator>();

    }



    void Update()
    {
        attackCountdown -= Time.deltaTime;

        if (healthBarPos != null)
        {
            healthBarPos.text = "HP:" +myStats.currentHealth.ToString();
        }

            if (attackCountdown <= 0f && Input.GetKeyDown(KeyCode.Mouse0))
        {
            this.enemyStats = enemyStats;
            attackCountdown = 1f / attackRate;
            Debug.Log("attaka");
            anim.SetTrigger("Attack");
  

            if (OnAttack != null)
            {
                OnAttack();
            }
        }

    }




 


}