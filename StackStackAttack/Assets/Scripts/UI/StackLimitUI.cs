using UnityEngine;
using TMPro;
using System;
public class StackLimitUI : MonoBehaviour
{
    private TextMeshProUGUI stackLimitText;
    [SerializeField] private Player player;
    [SerializeField] private GameObject iconsAndParents;

    private int currentStack;

    private void Awake()
    {
        stackLimitText = GetComponent<TextMeshProUGUI>();
    }
    private void Start()
    {
        CardUI.OnAnyCardSelected += OnAnyCardSelected_IncreaseStackedCards;
        CardStackManager.Instance.OnClearStack += CardStackManager_OnClearStack;
        currentStack = 0;

        SetUIStatus();
    }

    private void CardStackManager_OnClearStack(object sender, EventArgs e)
    {
        iconsAndParents.SetActive(true);
        currentStack = 0;
        UpdateStackText();
    }

    private void SetUIStatus()
    {
        stackLimitText.text = $"Stacked Cards - {currentStack} / {player.GetStackLimit()}";
    }

    private void OnAnyCardSelected_IncreaseStackedCards(object sender, CardUI.OnAnyCardSelectedArgs e)
    {
        UpdateStackText();
    }

    private void UpdateStackText()
    {
        if (currentStack < player.GetStackLimit())
        {
            currentStack++;
            SetUIStatus();
        }
        else
        {
            iconsAndParents.SetActive(false);
        }
    }
}
