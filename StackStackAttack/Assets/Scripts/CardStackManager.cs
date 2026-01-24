using UnityEngine;
using System;
using System.Collections.Generic;

public class CardStackManager : MonoBehaviour
{
    public static CardStackManager Instance { private set; get; }

    public event EventHandler OnClearStack;
    private List<BaseCard> currentStackCards;

    [SerializeField] private ClearStackHandler clearStackHandler;
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There is more than one instance of CardStackManager - " + transform);
            Destroy(gameObject);
            return;
        }
        Instance = this;

        currentStackCards = new List<BaseCard>();
    }
    private void Start()
    {
        CardUI.OnAnyCardSelected += OnAnyCardSelected_AddToStack;
        clearStackHandler.OnClearButtonClicked += OnClearButtonClicked_ClearStack;
    }


    private void OnAnyCardSelected_AddToStack(object sender, CardUI.OnAnyCardSelectedArgs e)
    {
        currentStackCards.Add(e.baseCard);
    }

    private void OnClearButtonClicked_ClearStack(object sender, EventArgs e)
    {
        ClearStack();
    }
    
    
    private void ClearStack()
    {
        currentStackCards.Clear();
        OnClearStack?.Invoke(this, EventArgs.Empty);
    }
}
