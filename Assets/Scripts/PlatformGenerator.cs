using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{

    public Transform generationPoint;
    private float distanceBetween = 0;
    public List<GameObject> prefabList = new List<GameObject>();

    private float platformWidth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < generationPoint.position.x){

            int prefabIndex = UnityEngine.Random.Range(0,prefabList.Count);
            Debug.Log(prefabIndex);
            platformWidth = prefabList[prefabIndex].GetComponent<BoxCollider2D>().size.x;

            Vector3 platformPosition = transform.position;
            platformPosition.x += 0;
            Instantiate (prefabList[prefabIndex], platformPosition, transform.rotation);
            transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween, transform.position.y, transform.position.z);
        }
    }
}
