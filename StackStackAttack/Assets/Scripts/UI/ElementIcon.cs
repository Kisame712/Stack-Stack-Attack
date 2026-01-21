using UnityEngine;
using UnityEngine.UI;
public class ElementIcon : MonoBehaviour
{
    

    [SerializeField] private GameObject elementCardParent;
    private bool isParentActive = false;

    private Button iconButton;

    private void Awake()
    {
        iconButton = GetComponent<Button>();
    }

    private void Start()
    {
        iconButton.onClick.AddListener(() =>
        {
            elementCardParent.SetActive(!isParentActive);
            isParentActive = !isParentActive;
        });
    }

}
