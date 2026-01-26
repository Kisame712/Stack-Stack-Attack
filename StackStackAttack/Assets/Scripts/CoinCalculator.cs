using UnityEngine;
using System;

public class CoinCalculator : MonoBehaviour
{

    public static CoinCalculator Instance { private set; get; }

    [SerializeField] private DamageUI damageUI;

    private int calculatedCoins;

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("There is more than one Instance of CoinCalculator" + transform);
            Destroy(gameObject);
            return;
        }
        Instance = this;
        calculatedCoins = 0;
    }

    private void Start()
    {
        AttackHandler.OnActionButtonClicked += AttackHandler_OnActionButtonClicked;
    }

    private void AttackHandler_OnActionButtonClicked(object sender, EventArgs e)
    {
        CalculateCoins();
        CoinManager.Instance.AddCoins(calculatedCoins);
        CoinManager.Instance.SaveCoins();
    }

    private void OnDestroy()
    {
        AttackHandler.OnActionButtonClicked -= AttackHandler_OnActionButtonClicked;
    }

    private void CalculateCoins()
    {
        int difference = MultiplierManager.Instance.GetRoundedDamage() - damageUI.GetRequiredDamage();
        if(difference < 0)
        {
            calculatedCoins = 0;
        }
        else
        {
            calculatedCoins = difference / 5;
        }
    }

    public int GetCalculatedCoins()
    {
        return calculatedCoins;
    }
}
