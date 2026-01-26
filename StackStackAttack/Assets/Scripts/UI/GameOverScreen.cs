using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI damageRequiredText;
    [SerializeField] private TextMeshProUGUI damageDoneText;
    [SerializeField] private TextMeshProUGUI coinsReceivedText;

    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Button retryButton;
    [SerializeField] private Button nextLevelButton;
    [SerializeField] private DamageUI damageUI;

    private void OnEnable()
    {
        damageRequiredText.text = $"Damage Required : {damageUI.GetRequiredDamage().ToString()}";
        damageDoneText.text = $"Damage Done : {MultiplierManager.Instance.GetRoundedDamage().ToString()}";
        coinsReceivedText.text = $"Coins Received : {CoinCalculator.Instance.GetCalculatedCoins()}";

        if (MultiplierManager.Instance.GetRoundedDamage() < damageUI.GetRequiredDamage())
        {
            nextLevelButton.gameObject.SetActive(false);

            retryButton.onClick.AddListener(() =>
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            });

            mainMenuButton.onClick.AddListener(() =>
            {
                SceneManager.LoadScene("MainMenu");
            });

        }

        else
        {
            nextLevelButton.onClick.AddListener(() =>
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            });

            retryButton.onClick.AddListener(() =>
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            });

            mainMenuButton.onClick.AddListener(() =>
            {
                SceneManager.LoadScene("MainMenu");
            });
        }

    }

}
