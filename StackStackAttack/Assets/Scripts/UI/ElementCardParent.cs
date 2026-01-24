using UnityEngine;
using System.Collections.Generic;
public class ElementCardParent : MonoBehaviour
{
    [SerializeField] private int elementId;
    [SerializeField] private Transform cardPrefab;

    private List<BaseCard> elementActiveCards;

    private void Awake()
    {
        PopulateParent();
    }

    private void OnEnable()
    {
        foreach (Transform elementCard in transform)
        {
            elementCard.gameObject.SetActive(true);
        }

    }

    private void OnDisable()
    {
        foreach(Transform elementCard in transform)
        {
            elementCard.gameObject.SetActive(false);
        }
    }

    private void PopulateParent()
    {
        elementActiveCards = CardManager.Instance.GetElementActiveCards(elementId);

        for (int i = 0; i < elementActiveCards.Count; i++)
        {
            Transform newCard = Instantiate(cardPrefab, transform);
            CardUI cardUI = newCard.GetComponent<CardUI>();
            cardUI.UpdateCardVisuals(elementActiveCards[i]);
        }
    }
}
