using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class module_gender : MonoBehaviour {
	public string gender, choose_gender;
	public Image fm_img, m_img;
	public string get_fullname, get_weight, get_height, get_ages, get_body, get_gender;

	void Start () {
		get_fullname = PlayerPrefs.GetString("fullname");
		get_weight = PlayerPrefs.GetString("weight");
		get_height = PlayerPrefs.GetString("height");
		get_ages = PlayerPrefs.GetString("ages");
		get_body = PlayerPrefs.GetString("body");

		Debug.Log(get_fullname);

		fm_img.GetComponent<Image>();
  		m_img.GetComponent<Image>();
	}

	public void fm_select(){
			gender = "Female";
			m_img.color = new Color32(255,255,255,35);
			fm_img.color = new Color32(255,255,255,255);
	}
	public void m_select(){
			gender = "Male";
			fm_img.color = new Color32(255,255,255,35);
			m_img.color = new Color32(255,255,255,255);

	}
	
	void Update () {
		if(gender == "Female"){
			choose_gender = "Female";
		}else{
			choose_gender = "Male";
		}
		//Debug.Log(choose_gender);
	}

	public void SelectGender(){
		PlayerPrefs.SetString("gender", ""+gender);
		StartCoroutine(LoadGameScene());
	}
	IEnumerator LoadGameScene() {
        yield return new WaitForSeconds(1);
        AsyncOperation async = SceneManager.LoadSceneAsync(2);
        while (!async.isDone) {
            yield return null;
        }
    }
}
