using UnityEngine;
using System.Collections.Generic;
public class CardManager : MonoBehaviour
{
    // Reference to all possible cards
    [SerializeField] private List<BaseCard> fireCards;
    [SerializeField] private List<BaseCard> waterCards;
    [SerializeField] private List<BaseCard> earthCards;
    [SerializeField] private List<BaseCard> lightningCards;
    [SerializeField] private List<BaseCard> windCards;

    [SerializeField] private Dictionary<int, List<BaseCard>> allCardMap;

    private List<BaseCard> activePlayerCards;
    private void Awake()
    {
        // index 0 - fireCards
        foreach(BaseCard baseCard in fireCards)
        {
            allCardMap[0].Add(baseCard);
        }

        // index 1 - waterCards
        foreach (BaseCard baseCard in waterCards)
        {
            allCardMap[1].Add(baseCard);
        }

        // index 2 - lightningCards
        foreach (BaseCard baseCard in lightningCards)
        {
            allCardMap[2].Add(baseCard);
        }

        // index 3 - earthCards
        foreach (BaseCard baseCard in earthCards)
        {
            allCardMap[3].Add(baseCard);
        }

        // index 4 - windCards
        foreach (BaseCard baseCard in windCards)
        {
            allCardMap[4].Add(baseCard);
        }
    }

    private void Start()
    {
        activePlayerCards = Player.Instance.GetPlayerCards();
    }

}
