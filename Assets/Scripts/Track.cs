using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour
{
	[SerializeField] private Transform end;

	public Transform GetEnd()
	{
		return end;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 13)
		{
			Destroy(gameObject);
			other.gameObject.GetComponentInParent<TrackGenerator>().GenerateTrack();
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
