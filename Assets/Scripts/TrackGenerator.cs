using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class TrackGenerator : MonoBehaviour
{
	[SerializeField] private GameManager gameManager;

	[SerializeField] private bool randomSeed = false;
	[SerializeField] private int seed;

	[SerializeField] private float maxAngle = 180f;
	[SerializeField] private float currentAngle;
	[SerializeField] private float[] lastCurveAngles = new float[10] {0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f };

	[SerializeField] private GameObject lastGeneratedTrack;
	private Transform lastGeneratedEndTrack;

	[SerializeField] private GameObject[] track;

	private float GetCurveAngle()
	{
		return lastCurveAngles.Sum();
	}

	private void AddCurveAngle(float value)
	{
		for (int i = lastCurveAngles.Length - 1; i > 0; i--)
		{
			lastCurveAngles[i] = lastCurveAngles[i - 1];
		}
		lastCurveAngles[0] = value;
	}

	public void GenerateTrack()
	{
		lastGeneratedEndTrack = lastGeneratedTrack.GetComponentInChildren<Track>().GetEnd();
        currentAngle = GetCurveAngle();
        GameObject futureTrack = Instantiate(RandomTrack(currentAngle), lastGeneratedEndTrack.position, lastGeneratedEndTrack.rotation);
		lastGeneratedTrack.GetComponentInChildren<Track>().SetNextTrack(futureTrack.GetComponentInChildren<Track>());
		Track fTrack = futureTrack.GetComponentInChildren<Track>();
		fTrack.SetPrevTrack(lastGeneratedTrack.GetComponentInChildren<Track>());
		fTrack.SetGameManager(gameManager);
		AddCurveAngle(fTrack.GetAngle());
		lastGeneratedTrack = futureTrack;
	}

	private GameObject RandomTrack(float angle)
	{
		List<GameObject> validTracks = new List<GameObject>();
		for (int i = 0; i < track.Length; i++)
		{
			float trackAngle = track[i].GetComponentInChildren<Track>().GetAngle();
            if ((trackAngle + angle) < maxAngle && (trackAngle + angle) > -maxAngle)
			{
				validTracks.Add(track[i]);
			}
		}
		return (track[Random.Range(0, validTracks.Count)]);
	}

	void Start()
	{
		if (!randomSeed)
		{
			Random.InitState(seed);
		}
	}
}
