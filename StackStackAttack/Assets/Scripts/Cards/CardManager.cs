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
        // populating the map with all possible cards
        allCardMap = new Dictionary<int, List<BaseCard>>();
        List<BaseCard> tempList = new List<BaseCard>();

        // index 0 - fireCards
        foreach(BaseCard baseCard in fireCards)
        {
            tempList.Add(baseCard);
        }
        allCardMap.Add(0, tempList);
        tempList.Clear();

        // index 1 - waterCards
        foreach (BaseCard baseCard in waterCards)
        {
            tempList.Add(baseCard);
        }
        allCardMap.Add(1, tempList);
        tempList.Clear();

        // index 2 - lightningCards
        foreach (BaseCard baseCard in lightningCards)
        {
            tempList.Add(baseCard);
        }
        allCardMap.Add(2, tempList);
        tempList.Clear();

        // index 3 - earthCards
        foreach (BaseCard baseCard in earthCards)
        {
            tempList.Add(baseCard);
        }
        allCardMap.Add(3, tempList);
        tempList.Clear();

        // index 4 - windCards
        foreach (BaseCard baseCard in windCards)
        {
            tempList.Add(baseCard);
        }
        allCardMap.Add(4, tempList);
        tempList.Clear();
    }

    private void Start()
    {
        activePlayerCards = Player.Instance.GetPlayerCards();
    }

}
