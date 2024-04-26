using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.Splines;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private bool activated = false;
	[SerializeField] private float t = 0;
	[SerializeField] private SplineContainer spline;
	[SerializeField] private Track currentTrack;
	[SerializeField] private Track nextTrack;

	// Start is called before the first frame update
	void Start()
	{
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
				currentTrack = nextTrack;
				nextTrack = currentTrack.GetNextTrack();
                spline = currentTrack.GetEnemyTrack();
                t -= 1;
			}
		}
	}
}
