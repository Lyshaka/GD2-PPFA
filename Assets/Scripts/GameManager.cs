using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	[SerializeField] private float roadLength = 0f;
	[SerializeField] private float currentLength;
	[SerializeField] private Image blackImage;


	private bool milestone = false;

	public void AddRoadLength(float value)
	{
		milestone = false;
		if ((int)(roadLength / 100) != (int)((roadLength + value) / 100))
		{
			milestone = true;
		}
		roadLength += value;
	}

	public float GetCurrentLength()
	{
		return currentLength;
	}

	public void SetCurrentLength(float value)
	{
		currentLength = value;
	}

	public bool ReachedMilestone()
	{
		return milestone;
	}

	public int GetMilestoneValue()
	{
		return ((int)(roadLength / 100) * 100);
	}
	public float GetRoadLength()
	{
		return roadLength;
	}

	public void GameOver()
	{
		StartCoroutine(PlayGameOver());
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.K))
		{
			Debug.Log("K Pressed !");
			GameOver();
		}
	}

	IEnumerator PlayGameOver()
	{
		float elapsedTime = 0;
		while (elapsedTime < 0.5f)
		{
			blackImage.color = new Color(0, 0, 0, elapsedTime / 0.5f);
			elapsedTime += Time.deltaTime;
			yield return null;
		}
		SceneManager.LoadSceneAsync("GameOverScene");
	}
}
