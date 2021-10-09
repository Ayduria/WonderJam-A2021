using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformController : MonoBehaviour
{
    private GameObject generationPoint;

    // Start is called before the first frame update
    void Start()
    {
        generationPoint = GameObject.FindWithTag("generationPoint");
    }

    // Update is called once per frame
    void Update()
    {
        if((transform.position.x + GetComponent<BoxCollider2D>().size.x * 2) < generationPoint.transform.position.x){
            Destroy(gameObject);
        }
    }
}
