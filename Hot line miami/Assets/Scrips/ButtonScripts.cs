using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScripts : MonoBehaviour {

	public void StartTheGame()
	{
		SceneManager.LoadScene(+ 1);
	}

	public void QuitTheGame()
	{
		Application.Quit();
	}

	private void RestartTheGame()
	{
		SceneManager.LoadScene(0);
	}
}
