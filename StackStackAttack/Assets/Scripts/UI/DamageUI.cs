using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
public class DamageUI : MonoBehaviour
{
    [SerializeField] private Image damageBar;
    [SerializeField] private int requiredDamage;
    [SerializeField] private TextMeshProUGUI damageText;
    [SerializeField] private Color initialColor;
    [SerializeField] private Color successColor;
    private void Start()
    {
        CardUI.OnAnyCardSelected += OnAnyCardSelected_UpdateDamage;
        CardStackManager.Instance.OnClearStack += CardStackManager_ClearStack;

        SetInitialUI();
    }

    private void CardStackManager_ClearStack(object sender, EventArgs e)
    {
        SetInitialUI();
    }

    private void OnAnyCardSelected_UpdateDamage(object sender, CardUI.OnAnyCardSelectedArgs e)
    {
        damageBar.fillAmount = GetNormalizedDamage();
        damageText.text = $"Damage - {MultiplierManager.Instance.GetRoundedDamage()} / {requiredDamage}";
        if(damageBar.fillAmount == 1)
        {
            damageBar.color = successColor;
        }
        else
        {
            damageBar.color = initialColor;
        }
    }

    private void OnDestroy()
    {
        CardUI.OnAnyCardSelected -= OnAnyCardSelected_UpdateDamage;
        CardStackManager.Instance.OnClearStack -= CardStackManager_ClearStack;
    }

    private float GetNormalizedDamage()
    {
        return  (float)MultiplierManager.Instance.GetRoundedDamage() / requiredDamage;
        
    }

    private void SetInitialUI()
    {
        damageBar.fillAmount = 0;
        damageText.text = $"Damage - {0} / {requiredDamage}";
    }

    public int GetRequiredDamage()
    {
        return requiredDamage;
    }

}
