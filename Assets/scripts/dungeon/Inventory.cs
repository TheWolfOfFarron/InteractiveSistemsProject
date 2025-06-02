using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private int money;

    public  TMP_Text hpText;
    private void Start()
    {
        money = 0;
    }

    private void Update()
    {
        hpText.text = "Money: " + money.ToString();
    }

    public void addMoney(int x)
    {   
        money += x;
    }

    public int getMoney()
    {
        return money; 
    }

}
