using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class JoystickControll : MonoBehaviour {

	public Text _debText = null;
	string[] _controllers;
	bool _connected = false;
	bool _iosFound = false;
	
	void Start () {
		if (_debText == null) {
			_debText = GameObject.Find("DebText").GetComponent<Text>();
		}

		StartCoroutine (CheckJoustick());
	}

	public void FoundIOSJoystick(){
		_iosFound = true;
	}

	public void LostiOSJoystick(){
		_iosFound = true;
	}

	void Update () {
		string _tmp = "[Joystick input test]";

		_tmp += "\nJoustick: ";
		if (!_connected){
			_tmp += " not connected."; 
		}else{
			_tmp += _controllers[0];
		}

		_tmp += "\niOS J: " + _iosFound.ToString();

		_tmp += "\nVertival: " + Input.GetAxis("Horizontal");
		_tmp += "\nHorizontal: " + Input.GetAxis("Vertical");

		_debText.text = _tmp;
	}

	IEnumerator CheckJoustick(){
		while (true) {
			_controllers = Input.GetJoystickNames();

			if (!_connected && _controllers.Length > 0){
				_connected = true;
			}
			else if (_connected == true && _controllers.Length == 0){
				_connected = false;
			}

			yield return new WaitForSeconds(1.0f);
		}
	}
}
