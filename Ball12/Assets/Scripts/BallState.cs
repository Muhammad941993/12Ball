using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BallState")]

public class BallState : ScriptableObject
{

    public bool[] Ideal = new bool[13];
    public bool[] MayBeHeavy = new bool[13];
    public bool[] MaybeLow = new bool[13];
    public bool[] Normal = new bool[13];
  
   

    public bool[] ReturnMayBeHeavy()
    {
        return MayBeHeavy;
    }

    public bool[] ReturnMayBeLow()
    {
        return MaybeLow;
    }

    public bool[] ReturnNormal()
    {
        return Normal;
    }

  

}
