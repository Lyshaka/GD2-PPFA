using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIMenu : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI textScore;


	public static void LoadScene(string sceneName)
	{
		SceneManager.LoadSceneAsync(sceneName);
	}

	public static void Quit()
	{
		Debug.Log("Adieu");
		Application.Quit();
	}

	private void Start()
	{
		if (textScore != null)
		{
			textScore.text = "Score : " + (int)ScoreManager.score;
		}
	}
}
