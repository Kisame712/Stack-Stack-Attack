using UnityEngine;
using UnityEngine.UI;
using System;
public class AttackHandler : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
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
            OnActionButtonClicked?.Invoke(this, EventArgs.Empty);
            gameOverScreen.SetActive(true);
            GameManager.Instance.SetIsGameOver(true);
        });

    }

    private void OnDestroy()
    {
        attackButton.onClick.RemoveAllListeners();
    }
}
