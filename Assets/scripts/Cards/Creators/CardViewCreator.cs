using DG.Tweening;
using UnityEngine;

public class CardViewCreator : Singeleton<CardViewCreator>
{
    [SerializeField] private CardView cardViewPrefab;

    public CardView createCardView(Card card,Vector3 position, Quaternion rotation)
    {
        CardView cardView = Instantiate(cardViewPrefab, position, rotation);
        cardView.transform.localScale = Vector3.zero;
        cardView.transform.DOScale(Vector3.one, 0.01f);
        cardView.setup(card);
        return cardView;
    }

}
