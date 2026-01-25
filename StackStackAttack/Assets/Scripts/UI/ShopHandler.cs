using UnityEngine;
using UnityEngine.UI;

public class ShopHandler : MonoBehaviour
{
    [SerializeField] private GameObject shopUI;
    private Button button;


    private void Awake()
    {
        button = GetComponent<Button>();
  
    }

    private void Start()
    {
        button.onClick.AddListener(() =>
        {
            shopUI.SetActive(true);

        });
    }

}
