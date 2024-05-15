using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Drawing.Text;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
	[SerializeField] private KartGame.KartSystems.ArcadeKart kartScript;

	[SerializeField] private TextMeshProUGUI scoreText;

	public static float score { get; private set; } = 0;

	void UpdateScore()
	{
		score += kartScript.Rigidbody.velocity.magnitude * Time.deltaTime;
		scoreText.text = "Score : " + (int)score;
	}

	public void AddScore(float amount)
	{
		score += amount;
	}

	private void Start()
	{
		score = 0;
	}

	// Update is called once per frame
	void Update()
	{
		UpdateScore();
	}
}
