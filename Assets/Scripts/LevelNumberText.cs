using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelNumberText : MonoBehaviour
{
    public Text TextWinScreen;
    public Text Text;
    public Game Game;

    private void Start()
    {
        Text.text = "Level " + (Game.LevelIndex + 1).ToString();
        TextWinScreen.text = "Level " + (Game.LevelIndex + 1) + " Completed!".ToString();
    }
}
