using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="MainBalance")]
public class MainBalance : ScriptableObject
{
   

    public  GameObject FirstHistory;
    public  GameObject SecondHistory;
    public  GameObject ThirdHistory;

    public string CaseName;
    
 
    public  Vector3[] Balls = new Vector3[13];

    public int SpliteBalanceNumber;
    public int BalanceNumber; 

    public int[] BallInLeftHandNumber = new int[6];
    public int[] BallInRightHandNumber = new int[6];
    public int[] BallLeftInGround = new int[13];

    public bool Solved = false;

    public GameObject LeftBallCollect;
    public GameObject RightBallColect;

    public  MainBalance[] NextBalance;

    public BallState[] BallState;
   

    public int[] ReturnBallInLeftHand()
    {
        return BallInLeftHandNumber;
    }

    public int [] ReturnBallInRightHand()
    {
        return BallInRightHandNumber;
    }

    public int[] ReturnBallInGround()
    {
        return BallLeftInGround;
    }

    public Vector3 [] ReturnBall()
    {
        return Balls;
    }

    public MainBalance[] ReturnNextBalance()
    {
        return NextBalance;
    }


 


}
