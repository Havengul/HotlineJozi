﻿using UnityEngine;

public class PopUpMenu : MonoBehaviour {
	
	
	private void OnGUI()
	{
		//GUI.Box(,"Loader Menu");
    
		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(20,40,80,20), "Level 1")) {
			Application.LoadLevel(1);
		}
    
		// Make the second button.
		if(GUI.Button(new Rect(20,70,80,20), "Level 2")) {
			Application.Quit();
		}
	}
}
