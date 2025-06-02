using UnityEngine;
using UnityEngine.Splines.ExtrusionShapes;



interface IIntreactable
{
    public void Interact();
}


public class Interactions : MonoBehaviour
{
    
    public Transform interactionObject;
    public float range;

    public GameObject cursour;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Ray ray1 = new Ray(interactionObject.position, interactionObject.forward);

        if (Physics.Raycast(ray1, out RaycastHit hitInfo2, range))
            if (hitInfo2.collider.CompareTag("Chest"))
            {
                SpriteRenderer sr = cursour.GetComponent<SpriteRenderer>();
                sr.color = Color.red;
            }else
            {
                SpriteRenderer sr = cursour.GetComponent<SpriteRenderer>();
                sr.color = Color.white;
            }



                if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Interaction key pressed");

            Ray ray = new Ray(interactionObject.position, interactionObject.forward);

            if (Physics.Raycast(ray, out RaycastHit hitInfo, range))
            {
                Debug.Log("Ray hit: " + hitInfo.collider.gameObject.name);

                if (hitInfo.collider.CompareTag("Chest")) 
                {
                    Debug.Log("Chest detected");

                    if (hitInfo.collider.TryGetComponent(out IIntreactable interactable))
                    {
                        interactable.Interact();
                    }
                    else
                    {
                        Debug.LogWarning("No IIntreactable component on chest");
                    }
                }
            }
        }


    }
}
