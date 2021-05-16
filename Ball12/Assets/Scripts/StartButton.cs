using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
  //  public GameObject Transition;
    public MainBalance TheFirst;
    public StateTransition Transition;
    public GameState State;
    public BallControl BallStateControl;
    public ControlText controlText;
  //  public CheckIfSolved CheckIfSolved;

    int x = 0;
    int y = 0;
    int z = 0;
 
    public  GameObject[] BallsPos;

    //public int[] BallsInGroundB1;
    //public int[] BallsInGroundB2;
    //public int[] BallsInGroundB3;
    public int[] BallsInGround = new int[13];

    // Start is called before the first frame update

    void Start()
    {
        BlanckBallsPos();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void StartButtonScale()
    {
        if (GameState.TheGAmeIsOver) return;
        CopyBallsInGround();
       
        // Blanck Balls Vector3 Pos
        BlanckBallsPos();
        
        // Get The Ball In R & L Scale

        StoreBallsPosition();
       
        SaveBallsInGroundAndCheckIfChanged();
        if (CheckBallsInGroundIfZeroOROdd()) return;

       

        //  Store Ball State
        if (GameState.CurrentState.BalanceNumber < 2)
        {
            BallStateControl.BallsBoolStateBalanceNumber();
        }


        //Show Splite Cases depend on Balance Number
        // and Check If the Current State Is solved

        State.ShowNextSplite();


       
    }

   void CopyBallsInGround()
    {
        for(int x = 0; x < 12; x++)
        {
            var Temp = GameState.CurrentState.ReturnBallInGround();
            BallsInGround[x] = Temp[x];
        }
    }
    


    // Blanck Balls Vector3 Pos and Left & right Hands
    void BlanckBallsPos()
    {
        
        for ( int i=0; i <12; i++)
        {
            GameState.CurrentState.Balls[i] = new Vector3(0, 0, 0);
            GameState.CurrentState.BallLeftInGround[i] = 0;
        }

        for (int i = 0; i < 6; i++)
        {
            GameState.CurrentState.BallInLeftHandNumber[i] = 0;
            GameState.CurrentState.BallInRightHandNumber[i] = 0;
        }

    }



   // Store Balls Position and Ball In R & L Hand And It's numbers
    void StoreBallsPosition()
    {
        // X & Y For count Ball In L & R Hands
        x = 0;
        y = 0;
        z = 0;

        for (int i = 1; i < BallsPos.Length; i++)
        {
            GameState.CurrentState.Balls[i] = BallsPos[i].transform.position;


            if (BallsPos[i].transform.position.x > 0 && BallsPos[i].transform.position.y > -2)
            {
                GameState.CurrentState.BallInRightHandNumber[x] = i;
                //  GameState.CurrentState.BRHands.Add(i);
                //  GameState.CurrentState.BallInRightHand[x] = BallsPos[i].transform.position;
                x++;
            }
            else if (BallsPos[i].transform.position.x < 0 && BallsPos[i].transform.position.y > -2)
            {
                GameState.CurrentState.BallInLeftHandNumber[y] = i;
                //  GameState.CurrentState.BLHands.Add(i);
                //  GameState.CurrentState.BallInLeftHand[y] = BallsPos[i].transform.position;
                y++;
            }
            else
            {
                GameState.CurrentState.BallLeftInGround[z] = i;
                z++;
            }


        }
    }

    //public void StoreBallsPosition()
    //{
    //    // X & Y For count Ball In L & R Hands
    //    x = 0;
    //    y = 0;
    //    z = 0;

    //    for (int i = 1; i < BallsPos.Length; i++)
    //    {
    //        GameState.CurrentState.Balls[i] = BallsPos[i].transform.position;


    //        if (BallsPos[i].transform.position.x > 0 && BallsPos[i].transform.position.y > -2)
    //        {
    //            GameState.CurrentState.BallInRightHandNumber[x] = i;
    //            x++;
    //        }
    //        else if (BallsPos[i].transform.position.x < 0 && BallsPos[i].transform.position.y > -2)
    //        {
    //            GameState.CurrentState.BallInLeftHandNumber[y] = i;              
    //            y++;
    //        }
    //        else
    //        {
    //            BallsInGround[z] = i;
    //            z++;
    //        }

           
    //    }
    //   // Save Balls In Ground
    //    SaveBallsInGroundAndCheckIfChanged(BallsInGround);
    //    GameState.CurrentState.BallLeftInGround = BallsInGround;

    //}


    public bool CheckBallsInGroundIfZeroOROdd()
    {
        int g = 0;
        int l = 0;
        int r = 0;

        for (int z = 0; z < 12; z++)
        {
            if (GameState.CurrentState.BallLeftInGround[z] != 0)
            {
                g++;
            }
        }
        for (int z = 0; z < 6; z++)
        {
            if (GameState.CurrentState.BallInLeftHandNumber[z] != 0)
            {
                l++;
            }
            if (GameState.CurrentState.BallInRightHandNumber[z] != 0)
            {
                r++;
            }
        }

        if (GameState.CurrentState.BalanceNumber == 2 && g > 8)
        {
            return false;
        }
        if (l == r && r >= 1)
        {
            return false;
        }

        // Show Massage Not Wast Your Balance
        controlText.text[1].SetActive(true);
        // Debug.Log("Dont Wast Your Balance");
       
        return true;

    }

    void SaveBallsInGroundAndCheckIfChanged()
    {
        if (GameState.CurrentState.BalanceNumber == 0)
        {
           
            CheckIfBallsInPlateChanged();
            
        }
        if (GameState.CurrentState.BalanceNumber == 1)
        {
            if (GameState.CurrentState.CaseName == "Case-1")
            {
               
                CheckIfBallsInPlateChanged();
            }
            else
            {
               
                CheckIfBallsInPlateChanged();
             
            }
        }
       
    }


     void CheckIfBallsInPlateChanged()
     {

         if (BallsInGround[0] == 0) return;

       
        for (int z = 0; z < 12; z++)
        {

            if (BallsInGround[z] != GameState.CurrentState.BallLeftInGround[z])
            {
                UnSolveNextBalance();
                break;
            }
                
        }
     }

    void UnSolveNextBalance()
    {
      
        int y = GameState.CurrentState.NextBalance.Length;
        for (int x = 0; x < y; x++)
        {
            GameState.CurrentState.NextBalance[x].Solved = false;
        }
       // Debug.Log("Next State Un Solved");
       
    }
}
