using UnityEngine;

public class Card : MonoBehaviour
{

    private readonly CardData data;

    public string title => data.Title;
    public string description => data.Description;

    public Sprite Image => data.Image;

    public Card(CardData cardData)
    {
        data = cardData; 
    }
 


}
