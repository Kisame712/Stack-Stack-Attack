using UnityEngine;
using System.Collections.Generic;
using System;
public class MultiplierManager : MonoBehaviour
{
    public static MultiplierManager Instance { private set; get; }

    private float currentMultiplier;
    private BaseCard previousCard;

    private float damage;

    /* Synergy combinations
    
    Mini combos - 
    1. Earth -> Fire  (3, 0)
    2. Earth -> Water (3, 1)
    3. Fire -> Wind   (0, 4)
    4. Wind -> Water  (4, 1)
    5. Lightning -> Fire (2, 0)
    6. Water -> Lightning (1, 2)
    
    NOTE : We can pretty much skip these as state wise checking will cover all of them
    Max combos -
    1. Earth -> Fire -> Wind
    2. Earth -> Water -> Lightning
    3. Lightning -> Fire -> Wind
    4. Wind -> Water -> Lightning

    */
    
    private struct Synergy
    {
        public int previous;
        public int current;
    }

    private List<Synergy> synergyList;

    private void Awake()
    {

        if (Instance != null)
        {
            Debug.LogError("There is more than one instance of MultiplierManager - " + transform);
            Destroy(gameObject);
            return;
        }
        Instance = this;

        synergyList = new List<Synergy>();

        SetInitialMultiplierStatus();

        // Populating the synergy list, DO NOT TOUCH
        synergyList.Add(new Synergy { previous = 3, current = 0 });
        synergyList.Add(new Synergy { previous = 3, current = 1 });
        synergyList.Add(new Synergy { previous = 0, current = 4 });
        synergyList.Add(new Synergy { previous = 4, current = 1 });
        synergyList.Add(new Synergy { previous = 2, current = 0 });
        synergyList.Add(new Synergy { previous = 1, current = 2 });

    }

    private void Start()
    {
        CardUI.OnAnyCardSelected += OnAnyCardSelected_MultiplierStateChanger;
        CardStackManager.Instance.OnClearStack += CardStackManager_OnClearStack;
    }

    private void CardStackManager_OnClearStack(object sender, EventArgs e)
    {
        SetInitialMultiplierStatus();
      
    }

    private enum State
    {
        Zero,
        One,
        Two,
    }

    private State state;

    private void OnAnyCardSelected_MultiplierStateChanger(object sender, CardUI.OnAnyCardSelectedArgs e)
    {
        MultiplierStateChanger(e.baseCard);
    }
    private void MultiplierStateChanger(BaseCard currentSelectedCard)
    {
        if(currentSelectedCard == null)
        {
            return;
        }

        switch (state)
        {
            case State.Zero:
                // 0 cards in stack for synergy, auto set to state one
                currentMultiplier = currentSelectedCard.stackMultiplier;
                previousCard = currentSelectedCard;
                AddDamage(currentSelectedCard);
                state = State.One;
                break;
            case State.One:
                // 1 card in stack for synergy
                Synergy possibleSynergy = new Synergy {previous = previousCard.elementId, current = currentSelectedCard.elementId };
                if (synergyList.Contains(possibleSynergy))
                {
                    Debug.Log("Synergy found!");
                    // Cards can stack one more time. we move to state two 
                    currentMultiplier = previousCard.stackMultiplier * currentSelectedCard.stackMultiplier;
                    previousCard = currentSelectedCard;
                    AddDamage(currentSelectedCard);
                    state = State.Two;
                }
                else
                {
                    // No synergy found, multiplier is reset and state is reset to one again
                    previousCard = currentSelectedCard;
                    currentMultiplier = currentSelectedCard.stackMultiplier;
                    AddDamage(currentSelectedCard);
                    state = State.One;
                }
                break;
            case State.Two:
                // 2 cards in stack for synergy
                possibleSynergy = new Synergy { previous = previousCard.elementId, current = currentSelectedCard.elementId };
                if (synergyList.Contains(possibleSynergy))
                {
                    // Max synergy achieved, still moving to state three for cleanup
                    currentMultiplier = currentMultiplier * currentSelectedCard.stackMultiplier;
                    previousCard = currentSelectedCard;
                    AddDamage(currentSelectedCard);
                    state = State.Zero;
                    SetInitialMultiplierStatus();
                }
                else
                {
                    // No synergy found, multiplier is reset and state is reset to one again
                    previousCard = currentSelectedCard;
                    currentMultiplier = currentSelectedCard.stackMultiplier;
                    AddDamage(currentSelectedCard);
                    state = State.One;
                }
                break;
        }
        Debug.Log("current mulitplier = " + currentMultiplier);
    }

    private void AddDamage(BaseCard currentSelectedCard)
    {
        if(currentSelectedCard == null)
        {
            return;
        }
        if(state == State.Zero)
        {
            damage = currentSelectedCard.baseAttackPoints;
        }
        else
        {
            damage += currentSelectedCard.baseAttackPoints * currentMultiplier;
        }
    }

    public int GetRoundedDamage()
    {
        return Mathf.RoundToInt(damage);
    }

    public float GetCurrentMultiplier()
    {
        return currentMultiplier;
    }

    private void SetInitialMultiplierStatus()
    {
        currentMultiplier = 1f;
        damage = 0;
        previousCard = null;
        state = State.Zero;
    }
}
