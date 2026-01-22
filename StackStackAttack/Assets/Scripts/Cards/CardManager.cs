using UnityEngine;
using System.Collections.Generic;
public class CardManager : MonoBehaviour
{
    public static CardManager Instance { private set; get; }

    // Reference to all possible cards
    [SerializeField] private List<BaseCard> fireCards;
    [SerializeField] private List<BaseCard> waterCards;
    [SerializeField] private List<BaseCard> earthCards;
    [SerializeField] private List<BaseCard> lightningCards;
    [SerializeField] private List<BaseCard> windCards;

    [SerializeField] private Dictionary<int, List<BaseCard>> allCardMap;
    [SerializeField] private Player player;

    private List<BaseCard> activePlayerCards;
    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("There is more than one Instance of CardManager - " + transform);
            Destroy(gameObject);
            return;
        }
        Instance = this;

        activePlayerCards = player.GetPlayerCards();
        // populating the map with all possible cards
        allCardMap = new Dictionary<int, List<BaseCard>>();
        List<BaseCard> tempList = new List<BaseCard>();

        tempList = fireCards;
        allCardMap[0] = tempList;

        tempList = waterCards;
        allCardMap[1] = tempList;

        tempList = lightningCards;
        allCardMap[2] = tempList;


        tempList = earthCards;
        allCardMap[3] = tempList;


        tempList = windCards;
        allCardMap[4] = tempList;


        for(int i = 0; i< 5; i++)
        {
            foreach(BaseCard baseCard in allCardMap[i])
            {
                Debug.Log(baseCard.elementId + " " + baseCard.cardIndex + " " + baseCard.cardName);
            }
        }
       

    }

    private void Start()
    {
        activePlayerCards = player.GetPlayerCards();
    }


    public List<BaseCard> GetElementActiveCards(int elementId)
    {
        if(elementId >= 5)
        {
            return null;
        }
        List<BaseCard> activeElementCardList = new List<BaseCard>();

        foreach(BaseCard baseCard in allCardMap[elementId])
        {
            if (activePlayerCards.Contains(baseCard))
            {
                activeElementCardList.Add(baseCard);
            }
        }

        return activeElementCardList;
    }
}
