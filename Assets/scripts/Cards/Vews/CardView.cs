using TMPro;
using UnityEngine;

public class CardView : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private TMP_Text title;
    [SerializeField] private TMP_Text description;
    [SerializeField] private SpriteRenderer icon;
    [SerializeField] private GameObject wrapper;
    [SerializeField] private Turn turn;


    public Card Card {  get; private set; }

    public void setup(Card card)
    {
        Card = card;
        title.text = card.title;
        description.text = card.description;
        icon.sprite= card.Image;
    }

    private void OnMouseEnter()
    {
        
        wrapper.SetActive(false);
 
        Vector3 pos = new(21.771f, 2.795f, -36.48836f);
        HoverSystem.Instance.Show(Card, pos);
        Turn.selectedCard = this;
    }

    private void OnMouseExit()
    {
        
        HoverSystem.Instance.Hide();
        wrapper.SetActive(true);
        Turn.selectedCard = null;
    }

}
