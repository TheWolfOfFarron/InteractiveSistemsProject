using UnityEngine;

public class HoverSystem : Singeleton<HoverSystem>
{
    [SerializeField] private CardView cardView;

    public void Show(Card card, Vector3 position)
    {
        cardView.gameObject.SetActive(true);
        cardView.setup(card);
        cardView.transform.position = position; 
    }
     
    public void Hide()
    {
        cardView?.gameObject.SetActive(false);  
    }
   


}
