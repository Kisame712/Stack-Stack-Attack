using UnityEngine;
using System.Collections.Generic;
public class ElementCardParent : MonoBehaviour
{
    [SerializeField] private int elementId;
    [SerializeField] private Transform cardPrefab;

    private List<BaseCard> elementActiveCards;

    private void Awake()
    {
        elementActiveCards = new List<BaseCard>();
    }

    private void OnEnable()
    {
        PopulateParent();
    }

    private void Start()
    {
        ShopCardUI.OnAnyCardBought += ShopCardUI_OnAnyCardBought;
    }

    private void ShopCardUI_OnAnyCardBought(object sender, ShopCardUI.OnAnyCardBoughtEventArgs e)
    {
        if(elementId == e.baseCard.elementId)
        {
            AddNewCard(e.baseCard);
        }
    }

    private void OnDestroy()
    {
        ShopCardUI.OnAnyCardBought -= ShopCardUI_OnAnyCardBought;
    }


    private void PopulateParent()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        elementActiveCards = CardManager.Instance.GetElementActiveCards(elementId);

        for (int i = 0; i < elementActiveCards.Count; i++)
        {
            Transform newCard = Instantiate(cardPrefab, transform);
            CardUI cardUI = newCard.GetComponent<CardUI>();
            cardUI.UpdateCardVisuals(elementActiveCards[i]);
        }
    }


    private void AddNewCard(BaseCard baseCard)
    {
        Transform newCard = Instantiate(cardPrefab, transform);
        CardUI cardUI = newCard.GetComponent<CardUI>();
        cardUI.UpdateCardVisuals(baseCard);

    }
}
