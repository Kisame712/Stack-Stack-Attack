using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
public class ShopUI : MonoBehaviour
{
    [Header("Basic")]
    [SerializeField] private Button backButton;
    [SerializeField] private Player player;
    [SerializeField] private Transform shopCardPrefab;

    [Header("Element parents")]
    [SerializeField] private Transform fireCards;
    [SerializeField] private Transform waterCards;
    [SerializeField] private Transform lightningCards;
    [SerializeField] private Transform earthCards;
    [SerializeField] private Transform windCards;

    private List<BaseCard> activePlayerCards;
    private Dictionary<int, List<BaseCard>> allCardMap;

    private void Awake()
    {
        allCardMap = CardManager.Instance.GetAllCardMap();
        activePlayerCards = player.GetPlayerCards();

        // FireCards
        foreach (BaseCard baseCard in allCardMap[0])
        {
            if (!activePlayerCards.Contains(baseCard))
            {
                Transform shopCard = Instantiate(shopCardPrefab, fireCards);
                ShopCardUI shopCardUIComponent = shopCard.GetComponent<ShopCardUI>();
                shopCardUIComponent.UpdateCardVisuals(baseCard);

            }
        }

        // WaterCards
        foreach (BaseCard baseCard in allCardMap[1])
        {
            if (!activePlayerCards.Contains(baseCard))
            {
                Transform shopCard = Instantiate(shopCardPrefab, waterCards);
                ShopCardUI shopCardUIComponent = shopCard.GetComponent<ShopCardUI>();
                shopCardUIComponent.UpdateCardVisuals(baseCard);

            }
        }


        // LightningCards
        foreach (BaseCard baseCard in allCardMap[2])
        {
            if (!activePlayerCards.Contains(baseCard))
            {
                Transform shopCard = Instantiate(shopCardPrefab, lightningCards);
                ShopCardUI shopCardUIComponent = shopCard.GetComponent<ShopCardUI>();
                shopCardUIComponent.UpdateCardVisuals(baseCard);

            }
        }


        // EarthCards
        foreach (BaseCard baseCard in allCardMap[3])
        {
            if (!activePlayerCards.Contains(baseCard))
            {
                Transform shopCard = Instantiate(shopCardPrefab, earthCards);
                ShopCardUI shopCardUIComponent = shopCard.GetComponent<ShopCardUI>();
                shopCardUIComponent.UpdateCardVisuals(baseCard);

            }
        }


        // WindCards
        foreach (BaseCard baseCard in allCardMap[4])
        {
            if (!activePlayerCards.Contains(baseCard))
            {
                Transform shopCard = Instantiate(shopCardPrefab, windCards);
                ShopCardUI shopCardUIComponent = shopCard.GetComponent<ShopCardUI>();
                shopCardUIComponent.UpdateCardVisuals(baseCard);

            }
        }
    }

    private void Start()
    {
        backButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
    }

}
