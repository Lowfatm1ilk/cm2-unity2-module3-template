using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GuessTheNumberScript : MonoBehaviour
{
    public int smallestNumber = 0;
    public int largestNumber = 99;
    public TextMeshProUGUI hintsText;
    public TextMeshProUGUI guessText;

    private int currentNumber;

    private int numberOfGuesses;
    private int score;

    void Start()
    {
        currentNumber = GenerateRandomNumber();
        GenerateHints(currentNumber);
        numberOfGuesses = 0;
        score = 0;
    }

    public void ShowGameEnd()
    {
        guessText.text = "Game Over";
        hintsText.text = "";
        hintsText.text += "\n" + "Total Guesses: " + numberOfGuesses.ToString() + "\n";
        hintsText.text += "\n" + "Number of Correct Guesses: " + score.ToString() + "\n";
    }

    public int GenerateRandomNumber()
    {
        return Random.Range(smallestNumber, largestNumber+1);
    }

    public void CheckGuess(string guess)
    {
        numberOfGuesses++;
        guessText.text = "You guessed " + guess + "\n";

        // LESSON 3-1: Add code below.
        if (int.Parse(guess) == currentNumber)
        {
            score++;
            guessText.text = "good job you didn't fail";
            currentNumber = GenerateRandomNumber();
            GenerateHints(currentNumber);
        }
        else if(int.Parse(guess) > currentNumber)
        {
            guessText.text = "your guess is MASSIVE";
        }
        else
        {
            guessText.text = "your guess is tiny";
        }

    }

    public void GenerateHints(int chosenNumber)
    {
        string hints = "";

        // LESSON 3-1: Add code below.

        hintsText.text = hints;
        if (currentNumber % 2 == 0)
        {
            guessText.text = guessText.text+ "this number is even steven \n";
        }
        else
        {
            guessText.text = guessText.text + "this number is oDd ToDd \n";
        }

        if (currentNumber < 10)
        {
            guessText.text = guessText.text + "this number is smaller than the number of fillangies you have \n";
        }
        else
        {
            guessText.text = guessText.text + "this number is bigger than the number of toes you have \n";
        }

        if (currentNumber < 50)
        {
            guessText.text = guessText.text + "this number is bigger that half of 100 \n";
        }
        else
        {
            guessText.text = guessText.text + "this number is smaller that 5^2 * 2 \n";
        }

        if (currentNumber % 60 == 0)
        {
            guessText.text = guessText.text + "this number is dividable by 6*10 \n";
        }
        else
        {
            guessText.text = guessText.text + "this number is not 60";
        }


    }
}
