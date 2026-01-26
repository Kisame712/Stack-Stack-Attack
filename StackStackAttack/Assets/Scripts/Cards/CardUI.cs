using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class CardUI : MonoBehaviour
{
    public static event EventHandler<OnAnyCardSelectedArgs> OnAnyCardSelected;

    public class OnAnyCardSelectedArgs : EventArgs
    {
        public BaseCard baseCard;
    }

    [SerializeField] private Image elementIcon;
    [SerializeField] private TextMeshProUGUI cardNameText;
    [SerializeField] private TextMeshProUGUI baseAttackDamageText;
    [SerializeField] private TextMeshProUGUI damageMultiplierText;

    private Button cardButton;

    private BaseCard baseCard;

    private void Awake()
    {
        cardButton = GetComponent<Button>();
    }

    private void Start()
    {
        cardButton.onClick.AddListener(() =>
        {
            OnAnyCardSelected?.Invoke(this, new OnAnyCardSelectedArgs { baseCard = this.baseCard });
        });
    }

    private void OnDestroy()
    {
        cardButton.onClick.RemoveAllListeners();
    }

    public void UpdateCardVisuals(BaseCard baseCard)
    {
        this.baseCard = baseCard;
        elementIcon.sprite = baseCard.elementSprite;
        cardNameText.text = baseCard.cardName;
        baseAttackDamageText.text = baseCard.baseAttackPoints.ToString();
        damageMultiplierText.text = "x" + $"{baseCard.stackMultiplier}";
    }
    
}
