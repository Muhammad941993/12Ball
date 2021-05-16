using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    Vector3 BallPosition;

   

    // Start is called before the first frame update
    void Start()
    {
     
        BallPosition = this.transform.position;
       
    }

    // Update is called once per frame
    void Update()
    {
       
        StartCoroutine(ResetBallRotation());
    }


    public Vector3 BackToBasePosition()
    {
        this.transform.rotation = new Quaternion(0, 0, 0, 0);
        return BallPosition;
    }


   


    IEnumerator ResetBallRotation()
    {
        while (true)
        {
            this.transform.rotation = new Quaternion(0, 0, 0, 0);
            yield return new WaitForSeconds(5f);
        }
            

       
    }




}
