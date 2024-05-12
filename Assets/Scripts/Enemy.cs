using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.Splines;

public class Enemy : MonoBehaviour
{
	[SerializeField] private float speed = 1f;
	[SerializeField] private float speedMin = 1f;
	[SerializeField] private float speedMax = 1f;
	[SerializeField] private bool activated = false;
	[SerializeField] private Track firstTrack;
	private float t = 0;
	private SplineContainer spline;
	private Track currentTrack;
	private Track nextTrack;
	private Track previousTrack;
	[SerializeField] private Transform playerTransform;
	[SerializeField] private float acceleration;
	[SerializeField] private float minDistance;
	[SerializeField] private float maxDistance;
	[SerializeField] private float totalLength = 0;
	[SerializeField] private float distanceFromPlayer;
	[SerializeField] private GameManager gameManager;

	private GameObject trackToDestroy;

	public void SetActivated(bool value)
	{
		activated = value;
	}

	float DistanceFromPlayer()
	{
		return gameManager.GetCurrentLength() - totalLength;
	}

	void DestroyPreviousTrack()
	{
		Destroy(trackToDestroy);
		trackToDestroy = previousTrack.gameObject.transform.parent.gameObject;
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 13)
		{
			gameManager.GameOver();
		}
	}

	// Start is called before the first frame update
	void Start()
	{
		currentTrack = firstTrack;
		spline = currentTrack.GetEnemyTrack();
		nextTrack = currentTrack.GetNextTrack();
	}

	// Update is called once per frame
	void Update()
	{
		if (activated)
		{
			t += (Time.deltaTime * speed) / currentTrack.GetTrackLength();
			transform.position = spline.EvaluatePosition(t);
			transform.rotation = Quaternion.LookRotation(spline.EvaluateTangent(t));
			if (t > 1)
			{
				totalLength += currentTrack.GetTrackLength();
				previousTrack = currentTrack;
				currentTrack = nextTrack;
				nextTrack = currentTrack.GetNextTrack();
				spline = currentTrack.GetEnemyTrack();
				DestroyPreviousTrack();
				t -= 1;
			}
		}

		distanceFromPlayer = DistanceFromPlayer();

		if (distanceFromPlayer > maxDistance && speed < speedMax)
		{
			speed += Time.deltaTime * acceleration;
		}
		if (distanceFromPlayer < minDistance && speed > speedMin)
		{
			speed -= Time.deltaTime * acceleration;
		}
	}
}
