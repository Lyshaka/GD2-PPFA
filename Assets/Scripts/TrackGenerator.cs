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
	[SerializeField] private float[] lastCurveAngles = new float[20] {0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f};

	[SerializeField] private GameObject lastGeneratedTrack;
	//[SerializeField] List<GameObject> validTracks = new List<GameObject>();
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
		GameObject futureTrack = Instantiate(RandomTrack(), lastGeneratedEndTrack.position, lastGeneratedEndTrack.rotation);
		lastGeneratedTrack.GetComponentInChildren<Track>().SetNextTrack(futureTrack.GetComponentInChildren<Track>());
		Track fTrack = futureTrack.GetComponentInChildren<Track>();
		fTrack.SetPrevTrack(lastGeneratedTrack.GetComponentInChildren<Track>());
		fTrack.SetGameManager(gameManager);
		//currentAngle = GetCurveAngle();
		AddCurveAngle(fTrack.GetAngle());
		lastGeneratedTrack = futureTrack;
	}

	private GameObject RandomTrack()
	{
		List<GameObject> validTracks = new List<GameObject>();
		validTracks.Clear();
		currentAngle = GetCurveAngle();
		int t = 0;
		for (int i = 0; i < track.Length; i++)
		{
			float trackAngle = track[i].GetComponentInChildren<Track>().GetAngle();
			if ((trackAngle + currentAngle) < maxAngle && (trackAngle + currentAngle) > -maxAngle)
			{
				validTracks.Add(track[i]);
				Debug.Log("Angle : " + (trackAngle + currentAngle));
				t++;
			}
		}
		//Debug.Log("i : " + t);
		return (track[Random.Range(0, validTracks.Count)]);
	}

	void Start()
	{
		if (!randomSeed)
		{
			Random.InitState(seed);
		}
		StartCoroutine(AutoGen(200));
	}
	
	IEnumerator AutoGen(int nb)
	{
		GenerateTrack();
		yield return new WaitForSeconds(0.01f);
		if (nb > 0)
		{
			StartCoroutine(AutoGen(nb - 1));
		}
	}
}
