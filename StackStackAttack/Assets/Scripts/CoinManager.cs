using UnityEngine;
using System;
public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance { private set; get; }

    private int currentCoins;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There is more than one instance of CoinManager");
            Destroy(gameObject);
            return;
        }

        Instance = this;

        LoadCoins();
        
    }

    private void LoadCoins()
    {
        currentCoins = PlayerPrefs.GetInt("currentCoins", 0);
    }

    public void SaveCoins()
    {
        PlayerPrefs.SetInt("currentCoins", currentCoins);
    }

    public bool TryBuyCard(int cardAmount)
    {
        if(cardAmount > currentCoins)
        {
            return false;
        }

        return true;
    }
    
    public void BuySelectedCard(int cardAmount)
    {
        currentCoins -= cardAmount;

        SaveCoins();
    }

    public int GetCurrentCoins()
    {
        return currentCoins;
    }

    public void AddCoins(int earnedCoins)
    {
        currentCoins += earnedCoins;
    }
}
