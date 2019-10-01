using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    
    public int correctAnswers; //How many correct answers have user given;
    public int askedQuestions;//Total of asked questions
    [SerializeField]GameObject[] victoryGameobject;
    [SerializeField] private TextMeshProUGUI[] finalScore;//Final score for all levels
    
    private void Update()
    {
        //show the player his score, how many correct answer per total questions and assign 
        //it to all score but only the right one will be shown
        foreach (var VARIABLE in finalScore)
        {
            VARIABLE.text = correctAnswers + "/" + askedQuestions;
        }
        showVictoryScreen();
        dontShowVictoryScreen();
    }

    private void dontShowVictoryScreen()
    {
        //here it don't show the victory screen if player doesn't answer all the questions right
        if (correctAnswers != askedQuestions)
        {
            foreach (var victory in victoryGameobject)
            {
                victory.SetActive(false);
            }
        }
    }

    private void showVictoryScreen()
    {
        //here it shows the victory screen if player answer all the questions right
        if (correctAnswers == askedQuestions)
            foreach (var victory in victoryGameobject)
            {
                victory.SetActive(true);
            }
    }

    public void correctAnswer() 
    {
        //here I assigned to unity UI a method if player press the correct answer
        //if user press right we give them one point and increase asked question count
        correctAnswers++;
        askedQuestions++;
    }

    public void wrongAnswer()
    {
        //here I assigned to unity UI a method if player press the wrong answer
        //if user press the wrong answer, it only increase asked question count
        askedQuestions++;
    }

    public void resetScore()
    {
        //Here I reset score when we press return to main menu or retry
        correctAnswers=0;
        askedQuestions=0;
    }

    public void quitGame()
    {
        //Here I assign code for the exit button in bottom center of monitor
        Application.Quit();
    }
}
