using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimControl : MonoBehaviour
{

    //public Animator MainBalanceAnim;

   // public Animator SpliteTwoB1Anim;
    public Animator SpliteTwoB2Anim;


    public Animator SpliteThreeB2Anim;
    public Animator SpliteThreeB3Anim;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }





    //public void MBRHandHeavy()
    //{
    //    MainBalanceAnim.SetBool("RhandHeavy", true);
    //}

    //public void MBLHandHeavy()
    //{
    //    MainBalanceAnim.SetBool("LHandHeavy", true);
    //}

  
    public void STwoBOneAnimEnable()
    {
        //SpliteTwoB2Anim.SetBool("BallsFallFinished",true);

        SpliteTwoB2Anim.enabled = true;
    }

    public void STwoBOneAnimDisable()
    {
        SpliteTwoB2Anim.enabled = false;
    }


    public void SThreeAllAnimEnable()
    {
        //SpliteThreeB2Anim.SetBool("SplitThreeBTwo",true);
        //SpliteThreeB3Anim.SetBool("SpliteThreeBThree",true);

        SpliteThreeB2Anim.enabled = true;
        SpliteThreeB3Anim.enabled = true;
    }


    public void SThreeAllAnimDisable()
    {
        SpliteThreeB2Anim.enabled = false;
        SpliteThreeB3Anim.enabled = false;
    }



}
