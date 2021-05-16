using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{

    private static GameAssets Instance;
    public static GameAssets GetInstance()
    {
        return Instance;
    }

    private void Awake()
    {
        Instance = this;

    }

   

}
