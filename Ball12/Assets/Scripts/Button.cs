using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{

    public GameObject[] ActiveBalance = new GameObject[4];
    public MainBalance[] mainBalances = new MainBalance[3];

    public GameState gameState;
    public CheckIfSolved CheckIfSolved;
    public MoveObjectToPoint MoveObjectToPoint;
 


    public void BackToBalance()
    {
        HideCurrentSplite();
        ActiveBalance[0].SetActive(true);
        if(GameState.CurrentState.BalanceNumber == 0)
        {
            //  gameState.BackBallToIdeal();
            gameState.PrepareCurrentGameState();
            MoveObjectToPoint.ResetBallsNumbers();
        }

    }



    public void ResetTheGame()
    {
        SceneManager.LoadScene("SampleScene");
       
    }


    public void GoToBalanceOne()
    {
        GameState.CurrentState = mainBalances[0];
        HideCurrentSplite();
        gameState.ShowNextSplite();
        gameState.ShowHistory();
        CheckIfSolved.CheckTheCaseIsSolvedOrNotFirst();
    }

    public void GoToBalanceTwo()
    {
       
        if (gameState.secondBalanceName == "Case-1")
        {
            GameState.CurrentState = mainBalances[1];
            HideCurrentSplite();
            gameState.ShowNextSplite();
        }
        else
        {
            GameState.CurrentState = mainBalances[2];
            HideCurrentSplite();
            gameState.ShowNextSplite();
        }
        CheckIfSolved.CheckWhiceCaseIsSlvedSecond();
    }


    void HideCurrentSplite()
    {
        foreach (GameObject x in ActiveBalance)
        {
            if (x.activeInHierarchy)
            {
                x.SetActive(false);
            }
        }
    }
}
