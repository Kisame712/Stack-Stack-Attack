using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
public class DamageUI : MonoBehaviour
{
    [SerializeField] private Image damageBar;
    [SerializeField] private float requiredDamage;
    [SerializeField] private TextMeshProUGUI damageText;
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
    }

    private float GetNormalizedDamage()
    {
        return MultiplierManager.Instance.GetRoundedDamage() / requiredDamage;
    }

    private void SetInitialUI()
    {
        damageBar.fillAmount = 0;
        damageText.text = $"Damage - {0} / {requiredDamage}";
    }
}
