using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectToPoint : MonoBehaviour
{

    public Transform RBallPoint;
    public Transform LBallPoint;

  public  int MaxBallInRightH = 0;
    public int MaxBallInLeftH = 0;
    // Start is called before the first frame update
    void Start()
    {
        ResetBallsNumbers();
    }

    // Update is called once per frame
    void Update()
    {
        SelectTheBall();
    }
   

    // Move Balls From Ideal Position To R || L Plate Or Get it Back From Plate To Ideal
    void SelectTheBall()
    {
        if (Input.GetMouseButtonDown(0) && ItemSelect.ClickSelect() != null)
        {
            var Ball = ItemSelect.ClickSelect();

            if (Ball.CompareTag("Ball"))
            {
                if (ChoseItem.RPlateB == true && ChoseItem.LPlateB == false && MaxBallInRightH < 4)
                {

                    if (Ball.transform.position.y < -2)
                    {
                        MaxBallInRightH += 1;
                    }
                    else
                    {
                        MaxBallInRightH += 1;
                        MaxBallInLeftH -= 1;
                    }

                    Ball.GetComponent<Rigidbody2D>().freezeRotation = false;
                    Ball.transform.position = RBallPoint.position;
                   

                }
                else if (ChoseItem.RPlateB == false && ChoseItem.LPlateB == true && MaxBallInLeftH < 4)
                {

                    if (Ball.transform.position.y < -2)
                    {
                        MaxBallInLeftH += 1;
                    }
                    else
                    {
                        MaxBallInLeftH += 1;
                        MaxBallInRightH -= 1;
                    }

                    Ball.GetComponent<Rigidbody2D>().freezeRotation = false;
                    Ball.transform.position = LBallPoint.position;

                   
                }
                else if (ChoseItem.RPlateB == false && ChoseItem.LPlateB == false)
                {
                    if (Ball.transform.position.x > 0 && Ball.transform.position.y > -2)
                    {
                        MaxBallInRightH -= 1;
                    }
                    else if (Ball.transform.position.x < 0 && Ball.transform.position.y > -2)
                    {
                        MaxBallInLeftH -= 1;
                    }

                    Ball.GetComponent<Rigidbody2D>().freezeRotation = true;
                    Ball.transform.position = Ball.GetComponent<Ball>().BackToBasePosition();

                   
                }
                else return;
            }
        }
    }


    // Rest Balls Number In Plates 
   public void ResetBallsNumbers()
    {
        MaxBallInRightH = 0;
        MaxBallInLeftH = 0;
    }
}
