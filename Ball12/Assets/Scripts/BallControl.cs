using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallControl : MonoBehaviour
{

   public GameState GameState;

    public int NormallBall = 0;

    public int IdealBallLeft = 0;
    public int IdeallBallRight = 0;

    public int NormalBallLeft = 0;
    public int NormalBallRight = 0;

    public int MaybeHeavyBallLeft = 0;
    public int MaybeHeavyBallRight = 0;

    public int MaybeLowBallRight = 0;
    public int MaybeLowBallLeft = 0;

    private void Start()
    {
        
    }





    public void BallsBoolStateBalanceNumber()
    {

        BlankCurrentBallState();
        StoreBallsStateBalance();
    }

    public void BlankCurrentBallState()
    {
        int l = GameState.CurrentState.BallState.Length;


        for (int z = 0; z < l; z++)
        {

            for (int i = 0; i < 13; i++)
            {
                GameState.CurrentState.BallState[z].Ideal[i] = false;
                GameState.CurrentState.BallState[z].Normal[i] = false;
                GameState.CurrentState.BallState[z].MaybeLow[i] = false;
                GameState.CurrentState.BallState[z].MayBeHeavy[i] = false;

            }
           
        }

    }




    public void StoreBallsStateBalance()
    {
        int l = GameState.CurrentState.BallState.Length;

        BallStateBalnceOneLeft(l);

        BallStateBalanceOneRight(l);

        BallStateBalanceOneGround(l);
      
    }

    void BallStateBalnceOneLeft(int l)
    {
        int[] BallsBoolLeft = GameState.CurrentState.ReturnBallInLeftHand();


        // GameState.CurrentState.BallState[0].NormalBall = BallsBoolLeft;

        for (int x = 0; x < 6; x++)
        {
            if (BallsBoolLeft[x] == 0) return;

            GameState.CurrentState.BallState[0].Normal[BallsBoolLeft[x]] = true ;
            GameState.CurrentState.BallState[1].MaybeLow[BallsBoolLeft[x]] = true ;
            if (l == 3)
            {
                GameState.CurrentState.BallState[2].MayBeHeavy[BallsBoolLeft[x]] = true;
            }

        }
    }

    void BallStateBalanceOneRight(int l)
    {
        int[] BallsBoolRight = GameState.CurrentState.ReturnBallInRightHand();


        for (int x = 0; x < 6; x++)
        {
            if (BallsBoolRight[x] == 0) return;


            GameState.CurrentState.BallState[0].Normal[BallsBoolRight[x]] = true;
            GameState.CurrentState.BallState[1].MayBeHeavy[BallsBoolRight[x]] = true;
            if (l == 3)
            {
                GameState.CurrentState.BallState[2].MaybeLow[BallsBoolRight[x]] = true;
            }

        }
    }

    void BallStateBalanceOneGround(int l)
    {

        int[] BallsBoolGround = GameState.CurrentState.ReturnBallInGround();

        for (int x = 0; x < 13; x++)
        {
            if (BallsBoolGround[x] == 0) return;

            GameState.CurrentState.BallState[0].Ideal[BallsBoolGround[x]] = true ;
            GameState.CurrentState.BallState[1].Normal[BallsBoolGround[x]] =true ;
            if (l == 3)
            {
                GameState.CurrentState.BallState[2].Normal[BallsBoolGround[x]] = true;
            }

        }
    }







   public void ComparBallInBothPlate()
   {
        int z= GameState.CurrentState.BalanceNumber;
        for (int x = 1; x < 13; x++)
        {
            if (GameState.ChosenBalance[z-1].Normal[x] == true)
            {
                GameState.ChosenBalance[z].Normal[x] = true;
                GameState.ChosenBalance[z].MayBeHeavy[x] = false;
                GameState.ChosenBalance[z].MaybeLow[x] = false;
                GameState.ChosenBalance[z].Ideal[x] = false;

            }
            else if (GameState.ChosenBalance[z - 1].MayBeHeavy[x] == true && GameState.ChosenBalance[z].MaybeLow[x] == true)
            {
                GameState.ChosenBalance[z].Normal[x] = true;
                GameState.ChosenBalance[z].Ideal[x] = false;
                GameState.ChosenBalance[z ].MayBeHeavy[x] = false;
                GameState.ChosenBalance[z].MaybeLow[x] = false;
            }
            else if (GameState.ChosenBalance[z - 1].MaybeLow[x] == true && GameState.ChosenBalance[z].MayBeHeavy[x] == true)
            {
                GameState.ChosenBalance[z ].Normal[x] = true;
                GameState.ChosenBalance[z ].Ideal[x] = false;
                GameState.ChosenBalance[z ].MayBeHeavy[x] = false;
                GameState.ChosenBalance[z ].MaybeLow[x] = false;
            }
            else if (GameState.ChosenBalance[z - 1].MaybeLow[x] == true && GameState.ChosenBalance[z ].Normal[x] == true)
            {
                GameState.ChosenBalance[z ].Normal[x] = true;
                GameState.ChosenBalance[z ].Ideal[x] = false;
                GameState.ChosenBalance[z ].MayBeHeavy[x] = false;
                GameState.ChosenBalance[z ].MaybeLow[x] = false;
            }
            else if (GameState.ChosenBalance[z - 1].MayBeHeavy[x] == true && GameState.ChosenBalance[z].Normal[x] == true)
            {
                GameState.ChosenBalance[z ].Normal[x] = true;
                GameState.ChosenBalance[z ].Ideal[x] = false;
                GameState.ChosenBalance[z ].MayBeHeavy[x] = false;
                GameState.ChosenBalance[z ].MaybeLow[x] = false;
            }


        }
   }






   
    // Count THe Normal Ball Number before Balance 3
    public int CountNormallBall()
    {
        NormallBall = 0;
     
       var normalBall  = GameState.ChosenBalance[GameState.CurrentState.BalanceNumber - 1].Normal;

        for (int x = 1; x < 13; x++)
        {
            if(normalBall[x] == true)
            {
                NormallBall++;
            }
        }

        return NormallBall;

    }

   

   public bool CheckBallsInFinalBalance()
    {
       
        if (CountNormallBall() >= 9)
        {

            var LeftBall = GameState.CurrentState.ReturnBallInLeftHand();
            var RightHand = GameState.CurrentState.ReturnBallInRightHand();

            // Check If we Have Only One Ball In Both Side 
            // And They Are Not Normal

            if (LeftBall[1] == 0 && RightHand[1] == 0)
            {
                if (GameState.ChosenBalance[GameState.CurrentState.BalanceNumber - 1].Normal[LeftBall[0]] == false &&
                    GameState.ChosenBalance[GameState.CurrentState.BalanceNumber - 1].Normal[RightHand[0]] == false)
                {

                   // GameState.CurrentState.Solved = true;

                    return true;
                }
                else if (GameState.CurrentState.SpliteBalanceNumber == 2 && GameState.CurrentState.BalanceNumber == 2)
                {
                    if (GameState.ChosenBalance[GameState.CurrentState.BalanceNumber - 1].Normal[LeftBall[0]] == false &&
                   GameState.ChosenBalance[GameState.CurrentState.BalanceNumber - 1].Normal[RightHand[0]] == true)
                    {
                        return true;
                    }
                    else if (GameState.ChosenBalance[GameState.CurrentState.BalanceNumber - 1].Normal[LeftBall[0]] == true &&
                   GameState.ChosenBalance[GameState.CurrentState.BalanceNumber - 1].Normal[RightHand[0]] == false)
                    {
                        return true;
                    }
                }
            }

        }
        return false;
    }





}
