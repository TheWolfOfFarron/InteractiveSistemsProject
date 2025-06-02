using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;
using DG.Tweening;

public class HandView : MonoBehaviour
{
    [SerializeField] private SplineContainer splineContainer;
    private readonly List<CardView> cards = new();

    [Header("Card Positioning Settings")]
    [SerializeField] private float handDistanceFromCamera = 2.5f; // Distance in front of the camera
    [SerializeField] private float verticalOffset = 0.5f;         // Offset above bottom center of screen
    [SerializeField] private float angleSpread = 30f;             // Fan spread angle

    public IEnumerator addCard(CardView card)
    {
        cards.Add(card);
        yield return UpdateCardPosition(0.15f);
    }

    public IEnumerator removeCard(CardView card)
    {
        Debug.LogError(card.ToString());
     

        cards.Remove(card);

        // Optionally destroy or deactivate card here
        Destroy(card); 

        yield return UpdateCardPosition(0.15f);
    }


    public IEnumerator UpdateCardPosition(float duration)
    {
        if (cards.Count == 0)
            yield break;

        Camera cam = Camera.main;
        if (cam == null)
        {
            Debug.LogError("No MainCamera found!");
            yield break;
        }

        float angleStep = (cards.Count > 1) ? angleSpread / (cards.Count - 1) : 0f;

        for (int i = 0; i < cards.Count; i++)
        {
            float angle = -angleSpread / 2f + angleStep * i;

            Vector3 offset = cam.transform.forward * handDistanceFromCamera
                           + cam.transform.right * Mathf.Sin(angle * Mathf.Deg2Rad) * handDistanceFromCamera
                           + cam.transform.up * verticalOffset;

            Vector3 targetPos = cam.transform.position + offset;

            Quaternion lookRotation = Quaternion.LookRotation(cam.transform.position - targetPos, Vector3.up);
            Quaternion fanTilt = Quaternion.Euler(0, 0, angle * 0.7f);
            Quaternion finalRotation = lookRotation * fanTilt;

            cards[i].transform.DOMove(targetPos, duration).SetEase(Ease.OutCubic);
            cards[i].transform.DORotate(finalRotation.eulerAngles, duration).SetEase(Ease.OutCubic);
        }

        yield return new WaitForSeconds(duration);
    }

    void LateUpdate()
    {
        PositionHandAtCameraBottom();
    }

    void PositionHandAtCameraBottom()
    {
        Camera cam = Camera.main;
        if (cam == null) return;

        Vector3 bottomCenter = cam.ViewportToWorldPoint(new Vector3(0.5f, 0f, handDistanceFromCamera));
        transform.position = bottomCenter + cam.transform.up * verticalOffset;
    }
}
