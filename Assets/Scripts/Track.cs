using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class Track : MonoBehaviour
{
	[SerializeField] private Transform end;
	[SerializeField] private SplineContainer enemyTrack;

	[SerializeField] private Track nextTrack;

	[SerializeField] private float trackLength;

	public Transform GetEnd()
	{
		return end;
	}

	public Track GetNextTrack()
	{
		return nextTrack;
	}

	public void SetNextTrack(Track track)
	{
		nextTrack = track;
	}

	public SplineContainer GetEnemyTrack()
	{
		return enemyTrack;
	}

	public float GetTrackLength()
	{
		return trackLength;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 13)
		{
			Destroy(GetComponent<BoxCollider>());
			other.gameObject.GetComponentInParent<TrackGenerator>().GenerateTrack();
		}
	}

	// Start is called before the first frame update
	void Start()
    {
        trackLength = enemyTrack.CalculateLength();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
