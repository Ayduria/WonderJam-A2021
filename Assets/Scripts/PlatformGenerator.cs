using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{

    public GameObject platform;
    public Transform generationPoint;
    private float distanceBetween = 0;

    private float platformWidth;

    // Start is called before the first frame update
    void Start()
    {
        platformWidth = platform.GetComponent<BoxCollider2D>().size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < generationPoint.position.x){
            Vector3 platformPosition = transform.position;
            platformPosition.x += platformWidth / 2;
            Debug.Log(platformPosition.x);
            Instantiate (platform, platformPosition, transform.rotation);
            transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween, transform.position.y, transform.position.z);
        }
    }
}
