using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoseItem : MonoBehaviour
{

    // Chose 2 item by select or deSelect it Debend on ItemSelect RayCast
    // Move Item From Place To Another

    public static bool RPlateB;
    public static bool LPlateB;
    //   public static bool UsedBallB;

 
    public  GameObject RBall;
 
    public  GameObject LBall;


    void Start()
    {
      

    }

    // Update is called once per frame
    void Update()
    {
        SelectThePlate();
    }



    // Select The Balance Plate R || L to Put The Ball In it
    void SelectThePlate()
    {
        if (Input.GetMouseButtonDown(0) && ItemSelect.ClickSelect() != null)
        {
            var Plate = ItemSelect.ClickSelect();

            if (Plate.CompareTag("RPlate"))
            {
                RPlateB = true;
                LPlateB = false;
                // UsedBallB = false;
               
                if (RBall.activeInHierarchy) { RPlateB = false; }

                RBall.SetActive(true);
                LBall.SetActive(false);
                // UsedBa.SetActive(false);

                if (RPlateB == false) { RBall.SetActive(false); }
            }
            if (Plate.CompareTag("LPlate"))
            {
                RPlateB = false;
                LPlateB = true;
                // UsedBallB = false;
                if (LBall.activeInHierarchy) { LPlateB = false; }

                RBall.SetActive(false);
                LBall.SetActive(true);
                // UsedBa.SetActive(false);

                if (LPlateB == false) { LBall.SetActive(false); }
            }


        }
        else return;

    }

   

 
  
}
