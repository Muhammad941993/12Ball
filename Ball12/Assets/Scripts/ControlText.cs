using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlText : MonoBehaviour
{

    public GameObject Info;
    public GameObject Hists;
    public GameObject WonMassage;

    public GameObject[] text = new GameObject[3];
    bool started;
    // Start is called before the first frame update
    void Start()
    {
      //  Info.SetActive(true);
        text[0].SetActive(true);
      //  started = true;
    }

    // Update is called once per frame
    void Update()
    {
        HideInfoPanle();
    }



    void HideInfoPanle()
    {
        if (Input.GetMouseButtonDown(0))
        {
               foreach(GameObject x in text)
            {
                if (x.activeInHierarchy)
                {
                    x.SetActive(false);
                }
            }
        }
        
       
    }





}
