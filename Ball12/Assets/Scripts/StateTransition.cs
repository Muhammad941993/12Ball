using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateTransition : MonoBehaviour
{
  
  


    public GameObject RPTSpliteB1;
    public GameObject RPTSpliteB2;

    public GameObject LPTSpliteB1;
    public GameObject LPTSpliteB2;


    public GameObject[] B11Balls;
    public GameObject[] B12Balls;

    //////////////////
    ///

    public GameObject RPTSpliteBB1;
    public GameObject RPTSpliteBB2;

    public GameObject LPTSpliteBB1;
    public GameObject LPTSpliteBB2;


    public GameObject[] TwoBB11Balls;
    public GameObject[] TwobB12Balls;

    /// <summary>
    /// ////////////////////////////////////////
    /// </summary>

    public GameObject RPThreeSpliteB1;
    public GameObject RPThreeSpliteB2;
    public GameObject RPThreeSpliteB3;

    public GameObject LPThreeSpliteB1;
    public GameObject LPThreeSpliteB2;
    public GameObject LPThreeSpliteB3;


   
    public GameObject[] B21Balls;
    public GameObject[] B22Balls;
    public GameObject[] B23Balls;


    int[] BallsInRight;
    int[] BallsInLeft;


 


    public void ThreeCaseS()
    {
        HideAllBallsThreeCase();
        SetBallsInThreeSplite();
    }
    public void TwoCaseS()
    {
        HideAllBallsTwoeCase();
        SetBallsInTwoSplite();
    }

    public void TwoCaseSB()
    {
        HideAllBallsTwoCaseB();
        SetBallsInTwoSpliteB();
    }

    


    void HideAllBallsTwoeCase()
    {
        for(int i=0; i<12; i++)
        {
            B11Balls[i].SetActive(false);
            B12Balls[i].SetActive(false);
        }
    }
    void HideAllBallsThreeCase()
    {
        for (int i = 0; i < 12; i++)
        {
            B21Balls[i].SetActive(false);
            B22Balls[i].SetActive(false);
            B23Balls[i].SetActive(false);

        }
    }



    void HideAllBallsTwoCaseB()
    {
        for (int i = 0; i < 12; i++)
        {
            TwoBB11Balls[i].SetActive(false);
            TwobB12Balls[i].SetActive(false);
        }
    }


    // Set Balls In Sceen
    public void SetBallsInTwoSplite()
    {
      StartCoroutine(MoveBallToRightPlateInTwo());
      StartCoroutine(MoveBallToLefttPlateInTwo());

        //Play B2 Anim
      StartCoroutine(PlaySpliteBalanceTwoAnim());
    }


    //Set Balls In Split 3
    public void SetBallsInThreeSplite()
    {
      StartCoroutine(MoveBallToRighttPlateInThree());
      StartCoroutine(MoveBallToLeftttPlateInThree());

        //Play All Anim In Splite 3

      StartCoroutine(PlaySpliteThreeAllAnim());
    }


    void SetBallsInTwoSpliteB()
    {
        StartCoroutine(MoveBallToRightPlateInTwoB());
        StartCoroutine(MoveBallToLefttPlateInTwoB());

        StartCoroutine(PlaySpliteBalanceTwoBAnim());
    }




    // In Two Case Splite Balls In Right Plate
    IEnumerator MoveBallToRightPlateInTwo()
    {

        BallsInRight = GameState.CurrentState.ReturnBallInRightHand();


        for (int i = 0; i < BallsInRight.Length; i++)
        {
            if (BallsInRight[i] == 0) break;

            B11Balls[BallsInRight[i]-1].transform.position = RPTSpliteB1.transform.position;
            B12Balls[BallsInRight[i]-1].transform.position = RPTSpliteB2.transform.position;

            B11Balls[BallsInRight[i]-1].SetActive(true);
            B12Balls[BallsInRight[i]-1].SetActive(true);

            yield return new WaitForSeconds(0.5f);
        }


    }
    // In Two Case Splite Balls In Left Plate
    IEnumerator MoveBallToLefttPlateInTwo()
    {
       
        BallsInLeft = GameState.CurrentState.ReturnBallInLeftHand();

        for (int i = 0; i < BallsInLeft.Length; i++)
        {
            if (BallsInLeft[i] == 0) break;

            B11Balls[BallsInLeft[i]-1].transform.position = LPTSpliteB1.transform.position;
            B12Balls[BallsInLeft[i]-1].transform.position = LPTSpliteB2.transform.position;

            B11Balls[BallsInLeft[i]-1].SetActive(true);
            B12Balls[BallsInLeft[i]-1].SetActive(true);

            yield return new WaitForSeconds(0.5f);
        }


    }


    // In Two B Case Splite Balls In Right Plate
    IEnumerator MoveBallToRightPlateInTwoB()
    {

        BallsInRight = GameState.CurrentState.ReturnBallInRightHand();


        for (int i = 0; i < BallsInRight.Length; i++)
        {
            if (BallsInRight[i] == 0) break;

            TwoBB11Balls[BallsInRight[i] - 1].transform.position = RPTSpliteBB1.transform.position;
            TwobB12Balls[BallsInRight[i] - 1].transform.position = RPTSpliteBB2.transform.position;

            TwoBB11Balls[BallsInRight[i] - 1].SetActive(true);
            TwobB12Balls[BallsInRight[i] - 1].SetActive(true);

            yield return new WaitForSeconds(0.5f);
        }


    }
    // In Two B Case Splite Balls In Left Plate
    IEnumerator MoveBallToLefttPlateInTwoB()
    {

        BallsInLeft = GameState.CurrentState.ReturnBallInLeftHand();

        for (int i = 0; i < BallsInLeft.Length; i++)
        {
            if (BallsInLeft[i] == 0) break;

            TwoBB11Balls[BallsInLeft[i] - 1].transform.position = LPTSpliteBB1.transform.position;
            TwobB12Balls[BallsInLeft[i] - 1].transform.position = LPTSpliteBB2.transform.position;

            TwoBB11Balls[BallsInLeft[i] - 1].SetActive(true);
            TwobB12Balls[BallsInLeft[i] - 1].SetActive(true);

            yield return new WaitForSeconds(0.5f);
        }


    }


    // In Three Case Splite Balls In Right Plate
    IEnumerator MoveBallToRighttPlateInThree()
    {
        BallsInRight = GameState.CurrentState.ReturnBallInRightHand();

        for (int i = 0; i < BallsInRight.Length; i++)
        {
            if (BallsInRight[i] == 0) break;

            B21Balls[BallsInRight[i] - 1].transform.position = RPThreeSpliteB1.transform.position;
            B22Balls[BallsInRight[i] - 1].transform.position = RPThreeSpliteB2.transform.position;
            B23Balls[BallsInRight[i] - 1].transform.position = RPThreeSpliteB3.transform.position;

            B21Balls[BallsInRight[i] - 1].SetActive(true);
            B22Balls[BallsInRight[i] - 1].SetActive(true);
            B23Balls[BallsInRight[i] - 1].SetActive(true);

             yield return new WaitForSeconds(0.5f);
        }

     

    }


    // In Three Case Splite Balls In Left Plate
    IEnumerator MoveBallToLeftttPlateInThree()
    { 
       

        BallsInLeft = GameState.CurrentState.ReturnBallInLeftHand();
        for (int i = 0; i < BallsInLeft.Length; i++)
        {
            if (BallsInLeft[i] == 0) break;

                B21Balls[BallsInLeft[i] - 1].transform.position = LPThreeSpliteB1.transform.position;
                B22Balls[BallsInLeft[i] - 1].transform.position = LPThreeSpliteB2.transform.position;
                B23Balls[BallsInLeft[i] - 1].transform.position = LPThreeSpliteB3.transform.position;

                B21Balls[BallsInLeft[i] - 1].SetActive(true);
                B22Balls[BallsInLeft[i] - 1].SetActive(true);
                B23Balls[BallsInLeft[i] - 1].SetActive(true);

            yield return new WaitForSeconds(0.5f);
        }
        
    }


   


    // Play Animation For Two Splite Balance Number 2 After Balls Falls Done
    IEnumerator PlaySpliteBalanceTwoAnim()
    {
        yield return new WaitForSeconds(3);
     //   Anim.STwoBOneAnimEnable();

        GameState.StartToChoice = true;
     
    }
    IEnumerator PlaySpliteBalanceTwoBAnim()
    {
        yield return new WaitForSeconds(3);
        //   Anim.STwoBOneAnimEnable();

        GameState.StartToChoice = true;

    }

    IEnumerator PlaySpliteThreeAllAnim()
    {
        yield return new WaitForSeconds(3);
     //   Anim.SThreeAllAnimEnable();

        GameState.StartToChoice = true;
       
    }

}
