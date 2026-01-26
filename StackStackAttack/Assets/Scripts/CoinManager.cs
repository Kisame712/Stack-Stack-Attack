using UnityEngine;

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
        DontDestroyOnLoad(gameObject);

        LoadCoins();
        
    }

    private void LoadCoins()
    {
        currentCoins = PlayerPrefs.GetInt("currentCoins", 0);
    }

    private void SaveCoins()
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
}
