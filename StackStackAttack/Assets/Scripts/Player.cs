using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    public static Player Instance { private set; get; }
    [SerializeField] private List<BaseCard> playerCards;
    [SerializeField] private int stackLimit;

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("There is more than one instance of Player - " + transform);
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    public List<BaseCard> GetPlayerCards()
    {
        return playerCards;
    }

    public int GetStackLimit()
    {
        return stackLimit;
    }
}
