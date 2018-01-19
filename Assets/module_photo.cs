using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class module_photo : MonoBehaviour {
	public string get_fullname, get_weight, get_height, get_ages, get_body, get_gender, get_code;
	WebCamTexture webCamTexture;
	public RawImage rawimage;
	public string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
	public string code = "";

	void Start () {
		get_fullname = PlayerPrefs.GetString("fullname");
		get_weight = PlayerPrefs.GetString("weight");
		get_height = PlayerPrefs.GetString("height");
		get_ages = PlayerPrefs.GetString("ages");
		get_body = PlayerPrefs.GetString("body");
		get_gender = PlayerPrefs.GetString("gender");

		webCamTexture = new WebCamTexture();
        rawimage.texture = webCamTexture;
        rawimage.material.mainTexture = webCamTexture;
        GetComponent<Renderer>().material.mainTexture = webCamTexture;
        webCamTexture.Play();
        
	     for (int i = 0; i < 20; i++) {
	         int a = Random.Range(0, chars.Length);
	         code = code + chars[a];
	     }
	     
		Debug.Log(""+get_fullname+", "+get_gender+", "+code);
	}
	
	public void ShootCamera(){
    	StartCoroutine(TakePhoto());
    }

    IEnumerator TakePhoto()
    {
   		yield return new WaitForEndOfFrame();

        Texture2D photo = new Texture2D(webCamTexture.width, webCamTexture.height);
        photo.SetPixels(webCamTexture.GetPixels());
        photo.Apply();
        //Encode to a PNG
        byte[] bytes = photo.EncodeToPNG();
        //Write out the PNG. Of course you have to substitute your_path for something sensible
        File.WriteAllBytes("photos/"+code+".png", bytes);

        PlayerPrefs.SetString("code", ""+code);
    	StartCoroutine(LoadGameScene());
	}
	IEnumerator LoadGameScene() {
        yield return new WaitForSeconds(1);
        AsyncOperation async = SceneManager.LoadSceneAsync(3);
        while (!async.isDone) {
            yield return null;
        }
    }
}
