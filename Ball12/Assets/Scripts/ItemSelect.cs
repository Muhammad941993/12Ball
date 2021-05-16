using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelect : MonoBehaviour
{
   

    // Update is called once per frame
    void Update()
    {
        ClickSelect();
    }




    public static GameObject ClickSelect()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Converting Mouse Pos to 2D (vector2) World Pos
            Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);

            if (hit)
            {
                return hit.transform.gameObject;
            }
            else return null;
        }
        else return null;

    }
}
