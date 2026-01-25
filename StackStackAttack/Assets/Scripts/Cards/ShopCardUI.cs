using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class ShopCardUI : MonoBehaviour
{

    public static event EventHandler<OnAnyCardBoughtEventArgs> OnAnyCardBought;

    public class OnAnyCardBoughtEventArgs : EventArgs
    {
        public int cardAmount;
        public BaseCard baseCard;
    }

    [SerializeField] private Image elementIcon;
    [SerializeField] private TextMeshProUGUI cardNameText;
    [SerializeField] private TextMeshProUGUI baseAttackDamageText;
    [SerializeField] private TextMeshProUGUI damageMultiplierText;
    [SerializeField] private TextMeshProUGUI cardAmountText;
    [SerializeField] private Image inactiveImage;


    private Button cardButton;

    private BaseCard baseCard;

    private void Awake()
    {
        cardButton = GetComponent<Button>();
    }

    private void Start()
    {
        cardButton.onClick.AddListener(() => 
        {
            if (CoinManager.Instance.TryBuyCard(baseCard.cardAmount))
            {
                CoinManager.Instance.BuySelectedCard(baseCard.cardAmount);
                OnAnyCardBought?.Invoke(this, new OnAnyCardBoughtEventArgs { cardAmount = baseCard.cardAmount, baseCard = this.baseCard }); 
            }
        });
    }

    public void UpdateCardVisuals(BaseCard baseCard)
    {
        this.baseCard = baseCard;
        elementIcon.sprite = baseCard.elementSprite;
        cardNameText.text = baseCard.cardName;
        cardAmountText.text = baseCard.cardAmount.ToString();
        baseAttackDamageText.text = baseCard.baseAttackPoints.ToString();
        damageMultiplierText.text = "x" + $"{baseCard.stackMultiplier}";

        CheckCardStatus();
    }

    private void CheckCardStatus()
    {
        if (!CoinManager.Instance.TryBuyCard(baseCard.cardAmount) || !(CardManager.Instance.IsActivePlayerCard(baseCard)))
        {
            cardButton.interactable = false;
            inactiveImage.gameObject.SetActive(true);
        }
        else
        {
            cardButton.interactable = true;
            inactiveImage.gameObject.SetActive(false);
        }
    }
}
