using UnityEngine;
using UnityEngine.UI;
using System;
public class ClearStackHandler : MonoBehaviour
{
    private Button clearButton;
    public event EventHandler OnClearButtonClicked;

    private void Awake()
    {
        clearButton = GetComponent<Button>();
    }

    private void Start()
    {
        clearButton.onClick.AddListener(() =>
        {
            OnClearButtonClicked?.Invoke(this, EventArgs.Empty);
        });
    }
}
