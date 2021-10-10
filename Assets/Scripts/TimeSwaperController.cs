using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSwaperController : MonoBehaviour
{

    public List<GameObject> characters = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        int random = UnityEngine.Random.Range(0, characters.Count - 1);
        characters[random].GetComponent<Billy>().toggleTime();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.LeftCommand)){
            for(int i = 0; i < characters.Count; i++)
            {
                characters[i].GetComponent<Billy>().toggleTime();
            }
        }
    }   
}
