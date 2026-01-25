using UnityEngine;
using System.Collections.Generic;
using System;
public class Player : MonoBehaviour
{
    [SerializeField] private List<BaseCard> playerCards;
    [SerializeField] private int stackLimit;

    private void Start()
    {
        ShopCardUI.OnAnyCardBought += ShopCardUI_OnAnyCardBought;
    }

    private void ShopCardUI_OnAnyCardBought(object sender, ShopCardUI.OnAnyCardBoughtEventArgs e)
    {
        if (!playerCards.Contains(e.baseCard))
        {
            playerCards.Add(e.baseCard);

        }
    }

    public List<BaseCard> GetPlayerCards()
    {
        return playerCards;
    }

    public int GetStackLimit()
    {
        return stackLimit;
    }
}
