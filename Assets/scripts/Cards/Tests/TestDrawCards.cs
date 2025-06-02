using UnityEngine;

public class TestDrawCards : MonoBehaviour
{

    [SerializeField] private HandView handView;
    [SerializeField] private CardData cardData;


    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {

            if (handView == null)
            {
                Debug.LogError("handView is null! Did you forget to assign it in the Inspector?");
                return;
            }
            else
            {

                Debug.LogError("handView is  not null! Did you forget to assign it in the Inspector?");
            }
            Card card = new(cardData);
            CardView cardView = CardViewCreator.Instance.createCardView(card,transform.position, Quaternion.identity);

           

            StartCoroutine(handView.addCard(cardView));
            Debug.Log("adaugat");
        }
    }
}
