using UnityEngine;
using System.Collections;

public class SelectionScript : MonoBehaviour
{
		private bool isRotating = false;
		private Quaternion targetRotation;
		private float t = 0f;
		private int currentCharacter = 0;
		private int numCharacters = 2;
		private float startMouseX;
		private float releaseMouseX;
		private string[] characterInfos = new string[2] 
		{
			"Mikey:\n\nAge: 19\n\nWeapon: Assault Paintball Rifle\n\nFire Rate: 0.8", 
			"Rachel:\n\nAge: 18\n\nWeapon: Sniper Paintball Rifle\n\nFire Rate: 0.5"
		};


		// Use this for initialization
		void Start ()
		{
		}

		void OnGUI ()
		{
				GUI.Box (new Rect (Screen.width * 0.5f, 10, Screen.width * 0.5f, Screen.height - 20), characterInfos [currentCharacter]);
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (Input.GetKeyDown (KeyCode.LeftArrow) && !isRotating) {
						isRotating = true;
						targetRotation = transform.rotation * Quaternion.Euler (0, 180f, 0);
						currentCharacter++;

						if (currentCharacter == numCharacters) {
								currentCharacter = 0;
						}
				}

				if (Input.GetMouseButtonDown (0) && !isRotating) {
						startMouseX = Input.mousePosition.x;
				}
				
				if (Input.GetMouseButtonUp (0) && !isRotating) {
						if (Input.mousePosition.x > startMouseX) {
								isRotating = true;
								targetRotation = transform.rotation * Quaternion.Euler (0, 180f, 0);
								currentCharacter++;
				
								if (currentCharacter == numCharacters) {
										currentCharacter = 0;
								}
						} else if (Input.mousePosition.x < startMouseX) {
								isRotating = true;
								targetRotation = transform.rotation * Quaternion.Euler (0, -180f, 0);
								currentCharacter--;
				
								if (currentCharacter < 0) {
										currentCharacter = numCharacters - 1;
								}
						}
				}

				if (isRotating) {
						transform.rotation = Quaternion.Lerp (transform.rotation, targetRotation, t);
						if (t < 1f) { // while t below the end limit...
								// increment it at the desired rate every update:
								t += Time.deltaTime;
						} else {
								isRotating = false;
								t = 0.0f;
						}
				}


		}

		
}
