using DG.Tweening;
using TMPro;
using UnityEngine;

public class StartCinema : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created






    void Start()
    {
        Camera mainCam = Camera.main;

        Vector3 targetPosition = new Vector3(56f, 2.5f, -63f);
        Vector3 targetRotation = new Vector3(0f, -90f, 0f); // Euler angles

        // Move the camera smoothly
        mainCam.transform.DOMove(targetPosition, 2f).SetEase(Ease.InOutSine);

        // Rotate the camera smoothly
        mainCam.transform.DORotate(targetRotation, 2f).SetEase(Ease.InOutSine);

    }

    
}
