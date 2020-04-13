using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ZXing;
using Vuforia;

public class QrRead : MonoBehaviour
{
    // Start is called before the first frame update
    
    IBarcodeReader barcodeReader = new BarcodeReader();


    void Start()
    {

        StartCoroutine(loop());
    }
    IEnumerator loop()
    {

        while (0 == 0)
        {
	    //how many seconds to att the camera reader --- default 0.333(3 times per second)
            yield return new WaitForSeconds(0.333f);

            
            try
            {
                
                //Convert camera vulforia
                CameraDevice.Instance.SetFrameFormat(PIXEL_FORMAT.GRAYSCALE, true);
                print("pixels :" + CameraDevice.Instance.GetCameraImage(PIXEL_FORMAT.GRAYSCALE).Pixels.Length);

                var result = barcodeReader.Decode(CameraDevice.Instance.GetCameraImage(PIXEL_FORMAT.GRAYSCALE).Pixels, CameraDevice.Instance.GetCameraImage(PIXEL_FORMAT.GRAYSCALE).Width, CameraDevice.Instance.GetCameraImage(PIXEL_FORMAT.GRAYSCALE).Height, RGBLuminanceSource.BitmapFormat.Gray8);
           	
		//Qr's code result

		print(result);	
            }
            catch (Exception ex)
            {

                Debug.LogWarning(ex.Message);

            }
            

        }



    }

}
