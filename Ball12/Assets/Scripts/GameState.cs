using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    public static bool TheGAmeIsOver;
    public GameObject TheMainBalance;

    public GameObject TwoCaseSplite;
    public GameObject TwoBCaseSplite;
    public GameObject ThreeCaseSplite;

    public ControlText controlText;
    public MainBalance TheFirstBalance;
    public CheckIfSolved CheckIfSolved;

    public static  MainBalance CurrentState;

    public StateTransition TransitionState;
    public StartButton BallsInSceen;
    public MoveObjectToPoint ResetBallsNumber;
    public static bool StartToChoice = false;

    public BallControl BallControlState;

    public Text[] CaseName = new Text[8];

    public BallState[] ChosenBalance = new BallState[3];

    public MainBalance[] AllBalance = new MainBalance[9];

    public GameObject[] History = new GameObject[2];

    

    public string secondBalanceName;
    // Start is called before the first frame update
    void Start()
    {
        CurrentState = TheFirstBalance;

        //  Set All Balance False 
        AllCaseUnSolved();
        // BlankBallInGround();
        TheGAmeIsOver = false;
     }

    // Update is called once per frame
    void Update()
    {
        ChoseNextStateFromSplite();
    }

   

    void AllCaseUnSolved()
    {
        foreach(MainBalance x in AllBalance)
        {
            x.Solved = false;
        }
    }


    // Chose The Naxt Sate In The Split Mode Balance 1 , 2 ,3
    void ChoseNextStateFromSplite()
    {
        // final Balance 3 No More 
        if (CurrentState.BalanceNumber == 2) return;

        if (StartToChoice == true)
        {
           
            if (Input.GetMouseButtonDown(0) && ItemSelect.ClickSelect() != null)
            {
                var ChoseNextState = ItemSelect.ClickSelect();

                if (ChoseNextState.CompareTag("NextBalance"))
                {
                    //Convert Balance Name ti int for chose

                    int x = int.Parse(ChoseNextState.name);

                    //Check if the Balance is solved not continue
                    if (CurrentState.NextBalance[x -1].Solved == true) return;

                    // Store Chosen Balance
                    TheChosenBalance(x - 1);

                    
                    //Compare Ball From Both Side
                    CompareBothSide();

                    //Save Second Balance Name
                    GetSecondBalanceName();

                    // Go To Next Balance 

                    CurrentState = CurrentState.NextBalance[x - 1];

                   
                    // Show History
                    ShowHistory();

                   

                    PrepareCurrentGameState();
                    ResetBallsNumber.ResetBallsNumbers();
                    StartToChoice = false;
                }
            }
        }
      
    }

    void GetSecondBalanceName()
    {
        if (CurrentState.BalanceNumber == 1)
        {
            secondBalanceName = CurrentState.CaseName;
        }
    }

  
    public  void ShowHistory()
    {
        if (CurrentState.BalanceNumber == 1)
        {
            History[0].SetActive(true);
          
        }
        else if (CurrentState.BalanceNumber == 2)
        {
            History[1].SetActive(true);
            History[1].GetComponentInChildren<Text>().text = secondBalanceName;
        }else if (CurrentState.BalanceNumber == 0)
        {
            
            History[0].SetActive(false);
           History[1].SetActive(false);
        }
    }

    void CompareBothSide()
    {
        //Start Compare From Balance 2
        if(CurrentState.BalanceNumber > 0)
        {
            BallControlState.ComparBallInBothPlate();
        }
    }

    // Hide Split Mode And Show MainBalance And Balls
  public void PrepareCurrentGameState()
    {
        TwoCaseSplite.SetActive(false);
        ThreeCaseSplite.SetActive(false);

        TheMainBalance.SetActive(true);
        CaseName[0].text = CurrentState.CaseName;

        BackBallToIdeal();
    }

    public void BackBallToIdeal()
    {
        for (int i = 1; i < 13; i++)
        {
            BallsInSceen.BallsPos[i].transform.position = BallsInSceen.BallsPos[i].GetComponent<Ball>().BackToBasePosition();
        }
    }


    // Get The Next Splite 2 or 3 SPlite
    // Called in start button
   public void ShowNextSplite()
    {
        // disable all sign
        CheckIfSolved.DisableAllSign();
        // MAke Check For Show 2 or 3 Splite In Case 2-B and 2-C
        if(CurrentState.BalanceNumber > 1)
        {
            //  BallControlState.CountNormallBall();
            CheckSpliteNumberSpecialCase();
        }


        if(CurrentState.SpliteBalanceNumber == 2  && CurrentState.BalanceNumber == 2)
        {
            // The final BAlance 2 Splite
            ShowTwoBSpliteCase();
            TransitionState.TwoCaseSB();
            CheckIfSolved.CheckTheCaseIsSolvedOrNotThird();
        }
        else if (CurrentState.SpliteBalanceNumber == 2 && CurrentState.BalanceNumber == 0)
        {
            ShowTwoeSpliteCase();
            TransitionState.TwoCaseS();
        } 
        else if (CurrentState.SpliteBalanceNumber == 3 && CurrentState.BalanceNumber == 2)
        {
            // The final BAlance 3 Splite
            ShowThreeSpliteCase();
            TransitionState.ThreeCaseS();
            CheckIfSolved.CheckTheCaseIsSolvedOrNotThird();

        }
        else if (CurrentState.SpliteBalanceNumber == 3 && CurrentState.BalanceNumber == 1)
        {
            ShowThreeSpliteCase();
            TransitionState.ThreeCaseS();
            CheckIfSolved.CheckWhiceCaseIsSlvedSecond();
        }

       
        CheckIfAllCacesAreSolved();
    }
    
   void CheckIfAllCacesAreSolved()
    {
        int i = 0;
        for(int x=3; x < AllBalance.Length; x++)
        {
            if(AllBalance[x].Solved == true)
            {
                i++;
            }
        }
        if(i == 6)
        {
            // Debug.Log("Very God");
            for(int x=0; x<3; x++)
            {
                AllBalance[x].Solved = true;
            }
            controlText.text[2].SetActive(true);
            TheGAmeIsOver = true;
        }
      
    }

    void CheckSpliteNumberSpecialCase()
    {

        if (BallControlState.CountNormallBall() <= 9)
        {
            CurrentState.SpliteBalanceNumber = 3;
        }
        else
        {
            CurrentState.SpliteBalanceNumber = 2;
        }
    }

    void ShowTwoeSpliteCase()
    {

        TheMainBalance.SetActive(false);
        TwoCaseSplite.SetActive(true);
        if (CurrentState.BalanceNumber < 2)
        {
            CaseName[1].text = CurrentState.NextBalance[0].CaseName;
            CaseName[2].text = CurrentState.NextBalance[1].CaseName;
        }
        else
        {
            CaseName[1].text = "";
            CaseName[2].text = "";
        }


    }

    void ShowTwoBSpliteCase()
    {

        TheMainBalance.SetActive(false);
        TwoBCaseSplite.SetActive(true);

    }


    void ShowThreeSpliteCase()
    {

        TheMainBalance.SetActive(false);
       ThreeCaseSplite.SetActive(true);
        if(CurrentState.BalanceNumber < 2)
        {
            CaseName[3].text = CurrentState.NextBalance[0].CaseName;
            CaseName[4].text = CurrentState.NextBalance[1].CaseName;
            CaseName[5].text = CurrentState.NextBalance[2].CaseName;
        }
        else
        {
            CaseName[3].text = "";
            CaseName[4].text = "";
            CaseName[5].text = "";
        }
       
        
    }


    // Store The Choice THe Player Take

    void TheChosenBalance(int i)
    {
        
        ChosenBalance[CurrentState.BalanceNumber] = CurrentState.BallState[i];
    }


   

  

  
}

