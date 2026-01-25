using UnityEngine;

[CreateAssetMenu(fileName = "NewBaseCard", menuName = "BaseCard")]
public class BaseCard : ScriptableObject
{
    public string elementName;
    public int elementId;
    public string cardName;
    // Damage done by an individual isolated card
    public int baseAttackPoints;

    // Mapping will be a array of lists per element => card[elementId][cardIndex]
    public int cardIndex;

    // A global stackMultiplier will be multiplied with this number if the stack has connection/synergy with the last stacked card
    public float stackMultiplier;

    // Add a sprite for every element to reprent the card type
    public Sprite elementSprite;

    // Card amount to buy cards from shop
    public int cardAmount;
}
