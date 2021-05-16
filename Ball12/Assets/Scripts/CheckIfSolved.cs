using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfSolved : MonoBehaviour
{
    public BallControl BallStateControl;
    public ControlText controlText;
    public GameObject[] solvedSign = new GameObject[8];

    public GameObject[] unSolvedSign = new GameObject[8];


    // Start is called before the first frame update
    void Start()
    {
        DisableAllSign();
    }



    // Update is called once per frame
    void Update()
    {

    }

  public  void DisableAllSign()
    {
        for(int x=0; x < solvedSign.Length; x++)
        {
            solvedSign[x].SetActive(false);
            unSolvedSign[x].SetActive(false);
        }
    }

  
    public void CheckTheCaseIsSolvedOrNotFirst()
    {
        DisableAllSign();

        if (GameState.CurrentState.BalanceNumber == 0)
        {
            if (GameState.CurrentState.NextBalance[0].Solved == true)
            {
                

                solvedSign[1].SetActive(true);
            }
            if(GameState.CurrentState.NextBalance[1].Solved == true)
            {
                

                solvedSign[2].SetActive(true);
            }
            if (GameState.CurrentState.NextBalance[0].Solved == true &&
                GameState.CurrentState.NextBalance[1].Solved == true)
            {
                GameState.CurrentState.Solved = true;
                solvedSign[0].SetActive(true);
                // Show WIn Massage
                //Debug.Log("YOU WON");
                GameState.TheGAmeIsOver = true;
                controlText.text[2].SetActive(true);
            }

        }
        
        
    }

   

   public void CheckWhiceCaseIsSlvedSecond()
    {
        DisableAllSign();

        if (GameState.CurrentState.NextBalance[0].Solved == true )
        {
            solvedSign[3].SetActive(true);
        }
       
         if (GameState.CurrentState.NextBalance[1].Solved == true )
        {
            solvedSign[4].SetActive(true);
        }
       
         if ( GameState.CurrentState.NextBalance[2].Solved == true)
        {
            solvedSign[5].SetActive(true);
        }
       
         if (GameState.CurrentState.NextBalance[0].Solved == true &&
            GameState.CurrentState.NextBalance[1].Solved == true &&
            GameState.CurrentState.NextBalance[2].Solved == true)
        {
            GameState.CurrentState.Solved = true;
        }

    }


    //public void TheCaseIsSolvedFirst()
    //{
    //    if (GameState.CurrentState.Solved == true)
    //    {
    //        solvedSign[0].SetActive(true);
    //    }
    //    else
    //    {
    //        solvedSign[0].SetActive(false);
    //    }
    //}

    //public void TheCaseIsSolvedSecond()
    //{
    //    if (GameState.CurrentState.Solved == true)
    //    {
    //        solvedSign[1].SetActive(true);
    //        solvedSign[2].SetActive(true);
    //    }
    //    else
    //    {
    //        solvedSign[1].SetActive(false);
    //        solvedSign[2].SetActive(false);
    //    }
    //}




    // for final balance Normal and special case

    public void CheckTheCaseIsSolvedOrNotThird()
    {
        DisableAllSign();
        GameState.CurrentState.Solved = BallStateControl.CheckBallsInFinalBalance();
        if (GameState.CurrentState.SpliteBalanceNumber == 3)
        {
            // Show The Sign if solved
            if (GameState.CurrentState.Solved == true)
            {
                TheCaseIsSolvedThird();
            }
            else
            {
                TheCaseUnSolvedThird();
            }



        }
        else
        {

            if (GameState.CurrentState.Solved == true)
            {
                TheCaseIsSolvedThirdSC();
            }
            else
            {
                TheCaseUnSolvedThirdSC();
            }


        }


    }

  
    public void TheCaseIsSolvedThirdSC()
    {
        if (GameState.CurrentState.Solved == true)
        {
            solvedSign[6].SetActive(true);
            solvedSign[7].SetActive(true);
        }
        else
        {
            solvedSign[6].SetActive(false);
            solvedSign[7].SetActive(false);
        }
    }
    public void TheCaseIsSolvedThird()
    {
        if(GameState.CurrentState.Solved == true)
        {
            solvedSign[3].SetActive(true);
            solvedSign[4].SetActive(true);
            solvedSign[5].SetActive(true);
        }
        else
        {
            solvedSign[3].SetActive(false);
            solvedSign[4].SetActive(false);
            solvedSign[5].SetActive(false);
        }
       
    }


    public void TheCaseUnSolvedThird()
    {
        if (GameState.CurrentState.Solved == false)
        {
            unSolvedSign[3].SetActive(true);
            unSolvedSign[4].SetActive(true);
            unSolvedSign[5].SetActive(true);
        }
        else
        {
            unSolvedSign[3].SetActive(false);
            unSolvedSign[4].SetActive(false);
            unSolvedSign[5].SetActive(false);
        }

    }

    public void TheCaseUnSolvedThirdSC()
    {
        if (GameState.CurrentState.Solved == false)
        {
            unSolvedSign[6].SetActive(true);
            unSolvedSign[7].SetActive(true);
        }
        else
        {
            unSolvedSign[6].SetActive(false);
            unSolvedSign[7].SetActive(false);
        }

    }

}
