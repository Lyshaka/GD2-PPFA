using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class Track : MonoBehaviour
{
	private GameManager gameManager;

	[SerializeField] private Transform end;
	[SerializeField] private SplineContainer enemyTrack;

	[SerializeField] private GameObject signR;
	[SerializeField] private GameObject signL;

	[SerializeField] private Track nextTrack;
	[SerializeField] private Track prevTrack;

	[SerializeField] private CollectibleGenerator collectibleGenerator;

	[SerializeField] private float enemyTrackLength;
	[SerializeField] private float totalTrackLength;
	[SerializeField] private float angle;

	public float GetAngle()
	{
		return angle;
	}

	public void SetGameManager(GameManager gm)
	{
		gameManager = gm;
	}

	public void SetScoreManager(ScoreManager sm)
	{
		collectibleGenerator.SetScoreManager(sm);
	}

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
		collectibleGenerator.GenerateCollectible(prevTrack.collectibleGenerator.GetEnd());
	}

	public float GetTrackLength()
	{
		return enemyTrackLength;
	}

	public float GetTotalTrackLength()
	{
		return totalTrackLength;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 13)
		{
			Destroy(GetComponent<BoxCollider>());
			other.gameObject.GetComponentInParent<TrackGenerator>().GenerateTrack();
			gameManager?.SetCurrentLength(totalTrackLength);
		}
	}

	void Start()
	{
		enemyTrackLength = enemyTrack.CalculateLength();
		if (gameManager != null)
		{
			gameManager.AddRoadLength(enemyTrackLength);
			totalTrackLength = gameManager.GetRoadLength();
			if (gameManager.ReachedMilestone())
			{
				if (Random.Range(0f, 1f) < 0.5f)
				{
					signR.SetActive(true);
					signR.GetComponent<Sign>().SetText("" + gameManager.GetMilestoneValue());
				}
				else
				{
					signL.SetActive(true);
					signL.GetComponent<Sign>().SetText("" + gameManager.GetMilestoneValue());
				}
			}
		}
		if (prevTrack != null && nextTrack == null)
		{
			GenerateCollectibleSpline();
		}
	}
}
