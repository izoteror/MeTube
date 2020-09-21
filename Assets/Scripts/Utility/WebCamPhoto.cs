using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;

public class WebCamPhoto : MonoBehaviour
{
    [SerializeField] private RawImage _videoDetector;
    private Texture _defaultTexture;
    private RawImage _videoScreen;
    private WebCamTexture _webCamTexture;
    private AspectRatioFitter _fitter;
    private bool _camAvaliable;

    void Start()
    {
        _videoScreen = this.GetComponent<RawImage>();
        _fitter = this.GetComponent<AspectRatioFitter>();
        
       
      

        if (GlobalSettings.globalsettings.Devices.Length != 0)
        {
            _camAvaliable = true;
            foreach(WebCamDevice device in GlobalSettings.globalsettings.Devices)
            {
                _webCamTexture = new WebCamTexture(device.name, Screen.width, Screen.height);
            }
            _webCamTexture.Play();
            _videoScreen.texture = _webCamTexture;
        }
        else
        {
            
            _camAvaliable = false;
            return;
        }
        
    }

    public void TakeSnapshot()
    {
       
            StartCoroutine(TakePhoto());
    }

    IEnumerator TakePhoto()  
    {
        yield return new WaitForEndOfFrame();
        Texture2D photoTex = new Texture2D(_webCamTexture.width, _webCamTexture.height);
        photoTex.SetPixels(_webCamTexture.GetPixels());
        photoTex.Apply();
        Sprite photo = Sprite.Create(photoTex, new Rect(0, 0, photoTex.width, photoTex.height), new Vector2(0.5f, 0.5f));

        CreateVideoMain.GetDataFromThemeST.CurrentVideoImage = photo;

        _videoDetector.texture = photo.texture;
    }


    private void FixedUpdate()
    {
      if (!_camAvaliable)
          return;
        float scaleY = _webCamTexture.videoVerticallyMirrored ? 1 : -1;
        _videoScreen.rectTransform.localScale = new Vector3(1f,scaleY,1f);
        _fitter.aspectRatio = (float)_webCamTexture.width/(float)_webCamTexture.height;
        int orient = -_webCamTexture.videoRotationAngle;
        _videoScreen.rectTransform.localEulerAngles = new Vector3(0,0,orient);

    }

}
