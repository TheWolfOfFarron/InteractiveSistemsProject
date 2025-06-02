using UnityEngine;

public class Turn : MonoBehaviour
{
    public static bool turn = true;

    public static bool startTurn = true;



    public static CardView selectedCard;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

}
