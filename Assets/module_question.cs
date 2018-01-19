using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class module_question : MonoBehaviour {
	public string get_fullname, get_weight, get_height, get_ages, get_body, get_gender, get_code, filePath;
	public GameObject fm_pic, m_pic, m_hair, fm_hair;
	public Text fullname, _question, _answer1, _answer2, _answer3, _answer4;
	public Image an1, an2, an3, an4;
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

		an1 = GetComponent<Image>();
	    an2 = GetComponent<Image>();
		an3 = GetComponent<Image>();
		an4 = GetComponent<Image>();
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

	public void take_choice_1(){
		an1.color = new Color32(255,0,0,255);
		an2.color = new Color32(255,255,255,255);
		an3.color = new Color32(255,255,255,255);
		an4.color = new Color32(255,255,255,255);
	}
	public void take_choice_2(){
		an2.color = new Color32(255,255,255,255);
		an1.color = new Color32(255,255,255,255);
		an3.color = new Color32(255,255,255,255);
		an4.color = new Color32(255,255,255,255);
	}
	public void take_choice_3(){
		an3.color = new Color32(255,0,0,255);
		an2.color = new Color32(255,255,255,255);
		an1.color = new Color32(255,255,255,255);
		an4.color = new Color32(255,255,255,255);
	}
	public void take_choice_4(){
		an4.color = new Color32(255,0,0,255);
		an2.color = new Color32(255,255,255,255);
		an3.color = new Color32(255,255,255,255);
		an1.color = new Color32(255,255,255,255);
	}

	public void PlayAR(){
		StartCoroutine(LoadGameScene());
	}
	IEnumerator LoadGameScene() {
        yield return new WaitForSeconds(1);
        AsyncOperation async = SceneManager.LoadSceneAsync(5);
        while (!async.isDone) {
            yield return null;
        }
    }
}
