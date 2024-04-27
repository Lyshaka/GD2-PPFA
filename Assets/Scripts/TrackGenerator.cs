using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackGenerator : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    [SerializeField] private int randomSeed;

    [SerializeField]
	private GameObject lastGeneratedTrack;
	private Transform lastGeneratedEndTrack;

	[SerializeField]
	private GameObject[] track;

	public void GenerateTrack()
	{
		lastGeneratedEndTrack = lastGeneratedTrack.GetComponentInChildren<Track>().GetEnd();
		GameObject futureTrack = Instantiate(RandomTrack(), lastGeneratedEndTrack.position, lastGeneratedEndTrack.rotation);
		lastGeneratedTrack.GetComponentInChildren<Track>().SetNextTrack(futureTrack.GetComponentInChildren<Track>());
        futureTrack.GetComponentInChildren<Track>().SetPrevTrack(lastGeneratedTrack.GetComponentInChildren<Track>());
		futureTrack.GetComponentInChildren<Track>().SetGameManager(gameManager);
        lastGeneratedTrack = futureTrack;
	}

	private GameObject RandomTrack()
	{
		return (track[Random.Range(0, track.Length)]);
	}

    void Start()
    {
        Random.InitState(randomSeed);
    }
}
