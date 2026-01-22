using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    [SerializeField] private List<BaseCard> playerCards;
    [SerializeField] private int stackLimit;

    public List<BaseCard> GetPlayerCards()
    {
        return playerCards;
    }

    public int GetStackLimit()
    {
        return stackLimit;
    }
}
