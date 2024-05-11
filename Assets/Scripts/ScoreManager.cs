using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Drawing.Text;

public class ScoreManager : MonoBehaviour
{
	[SerializeField] private KartGame.KartSystems.ArcadeKart kartScript;

	[SerializeField] private TextMeshProUGUI scoreText;
	[SerializeField] private float score = 0;

	[SerializeField] private List<GameObject> collectibleObject = new();
	[SerializeField] private List<float> collectibleMilestone = new();
	//[SerializeField] private List<>

	public class CollectibleDistribution : MonoBehaviour
	{
		public float milestone;
		public float score;
	}

	void UpdateScore()
	{
		score += kartScript.Rigidbody.velocity.magnitude * Time.deltaTime;
		scoreText.text = "Score : " + (int)score;
	}

	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		UpdateScore();
	}
}
