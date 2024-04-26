using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackGenerator : MonoBehaviour
{
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
        lastGeneratedTrack = futureTrack;
	}

	private GameObject RandomTrack()
	{
		return (track[Random.Range(0, track.Length)]);
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
