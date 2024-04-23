using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackGenerator : MonoBehaviour
{
	[SerializeField]
	private GameObject lastGeneratedTrack;
	private Transform lastGeneratedEndTrack;

	[SerializeField]
	private GameObject track;


	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 11)
		{
			Debug.Log("Yes !");
			Destroy(other.gameObject);
			lastGeneratedEndTrack = lastGeneratedTrack.GetComponent<Track>().GetEnd();
			lastGeneratedTrack = Instantiate(track, lastGeneratedEndTrack.position, lastGeneratedEndTrack.rotation);
		}
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
