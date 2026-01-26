using UnityEngine;
using UnityEngine.UI;
using System;
public class AttackHandler : MonoBehaviour
{
    public static event EventHandler OnActionButtonClicked;
    private Button attackButton;

    private void Awake()
    {
        attackButton = GetComponent<Button>();
    }

    private void Start()
    {
        attackButton.onClick.AddListener(() =>
        {
            GameManager.Instance.SetIsGameOver(true);
            OnActionButtonClicked?.Invoke(this, EventArgs.Empty);
        });

    }
}
