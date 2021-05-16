using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShotHandler : MonoBehaviour
{
    private static ScreenShotHandler Instance;

    private Camera myCamera;
    private bool TakeScreenNextFram;

   public CanvasRenderer first;
  //  public Sprite Sprite;

    //int screenNum = 0;
    //int supersize = 1/2;

    private void Awake()
    {
        Instance = this;
        myCamera = gameObject.GetComponent<Camera>();
    }


    private void OnPostRender()
    {
        if (TakeScreenNextFram)
        {
            TakeScreenNextFram = false;

            RenderTexture renderTexture = myCamera.targetTexture;

            Texture2D renderResult = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
            Rect rect = new Rect(0, 0, renderTexture.width, renderTexture.height);
            renderResult.ReadPixels(rect,0,0);
            renderResult.Apply();

            first.SetTexture(renderTexture);
           // first.SetTexture = Sprite.Create(renderResult, new Rect(0, 0, renderResult.width, renderResult.height), new Vector2(0.5f, 0.5f), 100.0f);
            //byte[] byteArray = renderResult.EncodeToPNG();
            //System.IO.File.WriteAllBytes(Application.dataPath + "/CameraScreenShot.png", byteArray);
            Debug.Log("Done");

           // RenderTexture.ReleaseTemporary(renderTexture);
            myCamera.targetTexture = null;
        }
    }

    private void TakeScreenShot(int w, int h)
    {
        myCamera.targetTexture = RenderTexture.GetTemporary(w, h, 16);
        TakeScreenNextFram = true;
    }



    public static void TakeScreenShots(int w,int h)
    {
        Instance.TakeScreenShot(w, h);
    }



  
}
