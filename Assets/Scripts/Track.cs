using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class Track : MonoBehaviour
{
	[SerializeField] private Transform end;
	[SerializeField] private SplineContainer enemyTrack;

	[SerializeField] private Track nextTrack;
	[SerializeField] private Track prevTrack;

	[SerializeField] private CollectibleGenerator collectibleGenerator;

	[SerializeField] private float enemyTrackLength;

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

    public void SetPrevTrack(Track track)
    {
        prevTrack = track;
    }

    public SplineContainer GetEnemyTrack()
	{
		return enemyTrack;
	}

	public void GenerateCollectibleSpline()
	{
		collectibleGenerator.GenerateSpline(prevTrack.collectibleGenerator.GetEnd());
	}

	public float GetTrackLength()
	{
		return enemyTrackLength;
	}

    void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 13)
		{
			Destroy(GetComponent<BoxCollider>());
			other.gameObject.GetComponentInParent<TrackGenerator>().GenerateTrack();
		}
	}

	void Start()
    {
        enemyTrackLength = enemyTrack.CalculateLength();
		if (prevTrack != null)
		{
            GenerateCollectibleSpline();
        }
    }
}
