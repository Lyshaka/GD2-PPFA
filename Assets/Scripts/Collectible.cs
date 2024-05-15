using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
	[SerializeField] private float collectSpeed = 10f;

	private ScoreManager scoreManager;

	public void SetScoreManager(ScoreManager sm)
	{
		scoreManager = sm;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 13)
		{
			StartCoroutine(Collect(other.gameObject.transform));
		}
	}

	IEnumerator Collect(Transform toFollow)
	{
		/*while (Vector3.Distance(gameObject.transform.position, toFollow.position) >= 0.1f)
		{
			gameObject.transform.position += collectSpeed * Time.deltaTime * (toFollow.position - gameObject.transform.position);
			yield return null;
		}*/
		scoreManager?.AddScore(10);
		Destroy(gameObject);
		yield return null;
	}
}
