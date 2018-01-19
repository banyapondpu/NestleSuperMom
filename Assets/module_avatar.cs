using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class module_avatar : MonoBehaviour {
	public string get_fullname, get_weight, get_height, get_ages, get_body, get_gender, get_code, filePath;
	public GameObject fm_pic, m_pic, m_hair, fm_hair;
	public Text fullname, value_weight, value_height, value_body, value_ages;
	Texture2D myTexture;
	
	void Start () {
		get_fullname = PlayerPrefs.GetString("fullname");
		get_weight = PlayerPrefs.GetString("weight");
		get_height = PlayerPrefs.GetString("height");
		get_ages = PlayerPrefs.GetString("ages");
		get_body = PlayerPrefs.GetString("body");
		get_gender = PlayerPrefs.GetString("gender");
		get_code = PlayerPrefs.GetString("code");
		Debug.Log("photos/"+get_code+".png");
		myTexture = null;
	    byte[] fileData;
	 	filePath = "photos/"+get_code+".png";
	    if (File.Exists(filePath))     {
	         Debug.Log("get");
	         fileData = File.ReadAllBytes(filePath);
	         myTexture = new Texture2D(2, 2);
	         myTexture.LoadImage(fileData);
	         GameObject rawImage = GameObject.Find ("RawImage");
			 rawImage.GetComponent<RawImage> ().texture = myTexture;
	    }
	    fullname.GetComponent<Text>().text = ""+get_fullname;
	    value_weight.GetComponent<Text>().text = ""+get_weight;
	    value_height.GetComponent<Text>().text = ""+get_height;
	    value_body.GetComponent<Text>().text = ""+get_body;
		value_ages.GetComponent<Text>().text = ""+get_ages;
	}
	
	void Update () {
		if(get_gender == "Female"){
			fm_pic.SetActive(true);
			fm_hair.SetActive(true);
			m_pic.SetActive(false);
			m_hair.SetActive(false);
		}else{
			fm_pic.SetActive(false);
			fm_hair.SetActive(false);
			m_pic.SetActive(true);
			m_hair.SetActive(true);
		}
	}

	public void PlayQuest(){
		StartCoroutine(LoadGameScene());
	}
	IEnumerator LoadGameScene() {
        yield return new WaitForSeconds(1);
        AsyncOperation async = SceneManager.LoadSceneAsync(4);
        while (!async.isDone) {
            yield return null;
        }
    }
}
