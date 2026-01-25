using UnityEngine;
using TMPro;
using System;
public class StackLimitUI : MonoBehaviour
{
    private TextMeshProUGUI stackLimitText;
    [SerializeField] private Player player;
    [SerializeField] private GameObject iconsAndParents;

    private int currentStackCount;
    private int playerStackCount;
    private void Awake()
    {
        currentStackCount = 0;
        stackLimitText = GetComponent<TextMeshProUGUI>();
        playerStackCount = player.GetStackLimit();
    }
    private void Start()
    {
        CardUI.OnAnyCardSelected += OnAnyCardSelected_IncreaseStackedCards;
        CardStackManager.Instance.OnClearStack += CardStackManager_OnClearStack;

        SetUIStatus();
    }

    private void CardStackManager_OnClearStack(object sender, EventArgs e)
    {
        iconsAndParents.SetActive(true);
        ClearStackText();
    }

    private void SetUIStatus()
    {
        stackLimitText.text = $"Stacked Cards - {currentStackCount} / {playerStackCount}";
    }

    private void OnAnyCardSelected_IncreaseStackedCards(object sender, CardUI.OnAnyCardSelectedArgs e)
    {
        UpdateStackText();
    }

    private void UpdateStackText()
    {
        currentStackCount++;
        if(currentStackCount >= player.GetStackLimit())
        {
            iconsAndParents.SetActive(false);
        }
        SetUIStatus();
    }

    private void ClearStackText()
    {
        currentStackCount = 0;
        stackLimitText.text = $"Stacked Cards - {currentStackCount} / {playerStackCount}";
    }
}
