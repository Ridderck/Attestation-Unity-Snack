
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public Controls Controls;
    public Canvas Canvas;
    private GameObject _loseScreen;
    private GameObject _winScreen;


    private void Start()
    {
        GameObject LoseScreen = Canvas.transform.GetChild(0).gameObject;
        GameObject WinScreen = Canvas.transform.GetChild(1).gameObject;
        _loseScreen = LoseScreen;
        _winScreen = WinScreen;
    }
    public enum State
    {
        Playing,
        Won,
        Loss,
    }

    public State CurrentState { get; private set; }
    public void OnPlayerDied()
    {
        if (CurrentState != State.Playing) return;

        CurrentState = State.Loss;
        Controls.enabled = false;
        _loseScreen.SetActive(true);
        Debug.Log("Game Over!");

    }
    public void DecreaseLevelIndex()
    {
        LevelIndex--;
    }
    public void OnPlayerReachedFinish()
    {
        if (CurrentState != State.Playing) return;

        CurrentState = State.Won;
        Controls.enabled = false;
        LevelIndex++;
        _winScreen.SetActive (true);
        Debug.Log("You Won!");
    }

    public int LevelIndex
    {
        get => PlayerPrefs.GetInt(LevelIndexKey, 0);
        private set
        {
            PlayerPrefs.SetInt(LevelIndexKey, value);
            PlayerPrefs.Save();
        }
    }

    private const string LevelIndexKey = "LevelIndex";
    

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
