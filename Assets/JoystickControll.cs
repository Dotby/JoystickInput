using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class JoystickControll : MonoBehaviour {

	public Text _debText = null;
	string[] _controllers;
	bool _connected = false;

	// Use this for initialization
	void Start () {
		if (_debText == null) {
			_debText = GameObject.Find("DebText").GetComponent<Text>();
		}

		StartCoroutine (CheckJoustick());
	}
	
	// Update is called once per frame
	void Update () {
		string _tmp = "[Joystick input test]";

		_tmp += "\nJoustick: ";
		_tmp += (_connected) ? _controllers[0] : " not connected."; 

		_tmp += "\nHorizontal: " + Input.GetAxis("Horizontal");
		_tmp += "\nVertical: " + Input.GetAxis("Vertical");

		_debText.text = _tmp;
	}

	IEnumerator CheckJoustick(){
		while (true) {
			_controllers = Input.GetJoystickNames();
			if (!_connected && _controllers.Length > 0){
				_connected = true;
			}
			else if (_connected && _controllers.Length == 0){
				_connected = false;
			}

			yield return new WaitForSeconds(1.0f);
		}
	}
}
