using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBubbleController : MonoBehaviour
{

    public GameObject player;
    private Vector3 initialTransform;
    private float speed = 15;

    // Start is called before the first frame update
    void Start()
    {
        initialTransform = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<Billy>().IsDead == true){
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(0, 0, 0), speed * Time.deltaTime);
        }
        else{
            if(player.GetComponent<Billy>().timeIsStopped == true){
                transform.localScale = Vector3.Lerp(transform.localScale, initialTransform, speed * Time.deltaTime);
            }
            else{
                transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(0, 0, 0), speed * Time.deltaTime);
            }
        }
    }
}
