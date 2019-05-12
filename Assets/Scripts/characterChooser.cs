using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterChooser : MonoBehaviour {

	public GameObject[] playerModes;
	public GameObject[] uiButtons;
	public GameObject[] gameRigs;
	public GameObject[] cameras;

	private GameObject activeMode;
	private Vector3 targetPosition;

	void Start() {
		targetPosition = new Vector3(0, 0, 0);
		switchMode(1);
	}

	void FixedUpdate() {
		if (activeMode != null) {
			targetPosition = activeMode.GetComponent<Transform>().localPosition;
		}
	}

	public void switchMode(int choice) {
		for (int i = 0; i < playerModes.Length; i++) {
			playerModes[i].SetActive(false);
			gameRigs[i].SetActive(false);
			cameras[i].SetActive(false);
			uiButtons[i].SetActive(true);
		}
		playerModes[choice - 1].SetActive(true);
		playerModes[choice - 1].transform.localPosition = targetPosition;
		cameras[choice - 1].transform.localPosition = targetPosition;
		activeMode = playerModes[choice - 1];

		gameRigs[choice - 1].SetActive(true);
		cameras[choice - 1].SetActive(true);
		uiButtons[choice - 1].SetActive(false);
	}
}
