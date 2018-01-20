using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class module_main : MonoBehaviour {
	public InputField input_fullname, input_weight, input_height, input_ages, input_body;
	private TouchScreenKeyboard keyboard;

	

	public void openKeyboard(){
		keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
	}

	public void submit_data(){
		PlayerPrefs.SetString("fullname", ""+input_fullname.text);
		PlayerPrefs.SetString("weight", ""+input_weight.text);
		PlayerPrefs.SetString("height", ""+input_height.text);
		PlayerPrefs.SetString("ages", ""+input_ages.text);
		PlayerPrefs.SetString("body", ""+input_body.text);
		StartCoroutine(LoadGameScene()); 
	}
	IEnumerator LoadGameScene() {
        yield return new WaitForSeconds(1);
        AsyncOperation async = SceneManager.LoadSceneAsync(1);
        while (!async.isDone) {
            yield return null;
        }
    }

}
