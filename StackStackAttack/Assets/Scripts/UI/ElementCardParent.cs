using UnityEngine;
using System.Collections.Generic;
public class ElementCardParent : MonoBehaviour
{
    [SerializeField] private int elementId;
    [SerializeField] private Transform cardPrefab;

    private List<BaseCard> elementActiveCards;
    private void OnEnable()
    {
        elementActiveCards = CardManager.Instance.GetElementActiveCards(elementId);

        Debug.Log(elementActiveCards.Count);

        for (int i = 0; i < elementActiveCards.Count; i++) 
        {
            Transform newCard = Instantiate(cardPrefab, transform);
        }
            
    }


    private void OnDisable()
    {
        foreach(Transform elementCard in transform)
        {
            Destroy(gameObject);
        }

        elementActiveCards.Clear();
    }
}
