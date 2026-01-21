using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { private set; get; }

    private float startCountdownTimer = 3f;
    private bool isGameOver;
    public enum State
    {
        StartCountdown,
        GameStart,
        GameOver
    }

    private State state;
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There is more than one instance of GameManager - " + transform);
            Destroy(gameObject);
            return;
        }
        Instance = this;

        // Setting the initial game state
        isGameOver = false;
        state = State.StartCountdown;
    }

    private void Update()
    {
        switch (state)
        {
            case State.StartCountdown:
                startCountdownTimer -= Time.deltaTime;
                if(startCountdownTimer <= 0)
                {
                    state = State.GameStart;
                }
                break;
            case State.GameStart:
                if (isGameOver)
                {
                    state = State.GameOver;
                }
                break;
            case State.GameOver:
                break;
        }
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }

    public void SetIsGameOver(bool isGameOver)
    {
        this.isGameOver = isGameOver;
    }

}
