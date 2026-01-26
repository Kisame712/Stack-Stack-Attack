using UnityEngine;
using TMPro;

public class CoinsUI : MonoBehaviour
{
    private TextMeshProUGUI coinsUIText;

    private void Awake()
    {
        coinsUIText = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        ShopCardUI.OnAnyCardBought += ShopCardUI_OnAnyCardBought;
        UpdateCoinsUI();
    }

    private void OnDestroy()
    {
        ShopCardUI.OnAnyCardBought -= ShopCardUI_OnAnyCardBought;
    }

    private void ShopCardUI_OnAnyCardBought(object sender, ShopCardUI.OnAnyCardBoughtEventArgs e)
    {
        UpdateCoinsUI();
    }

    private void UpdateCoinsUI()
    {
        coinsUIText.text = $"Coins : {CoinManager.Instance.GetCurrentCoins().ToString()}";
    }

}
