using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.Splines;

public class Enemy : MonoBehaviour
{
	[SerializeField] private float speed = 1f;
	[SerializeField] private bool activated = false;
	[SerializeField] private Track firstTrack;
	private float t = 0;
	private SplineContainer spline;
	private Track currentTrack;
	private Track nextTrack;
	private Track previousTrack;
	[SerializeField] private float totalLength;
	[SerializeField] private float currentLength;

	// Start is called before the first frame update
	void Start()
	{
		currentTrack = firstTrack;
		currentLength = currentTrack.GetTrackLength();
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
				currentLength = currentTrack.GetTrackLength();
				previousTrack = currentTrack;
				currentTrack = nextTrack;
				nextTrack = currentTrack.GetNextTrack();
				spline = currentTrack.GetEnemyTrack();
				Destroy(previousTrack.gameObject.transform.parent.gameObject);
				t -= 1;
			}
		}
	}
}
