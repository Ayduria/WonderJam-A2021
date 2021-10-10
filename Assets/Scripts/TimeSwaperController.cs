using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSwaperController : MonoBehaviour
{

    public List<GameObject> characters = new List<GameObject>();
    public List<GameObject> hourglass = new List<GameObject>();
    public AudioSource swap;
    public AudioSource swap2;

    bool swapSound = false;

    // Start is called before the first frame update
    void Start()
    {
        int random = UnityEngine.Random.Range(0, characters.Count);
        characters[random].GetComponent<Billy>().toggleTime();
        if(random == 0){
            hourglass[1].SetActive(false);
        }
        else{
            hourglass[0].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.LeftCommand)){
            
            if(swapSound){
                swap.Play();
            }
            else{
                swap2.Play();
            }

            swapSound = !swapSound;
            for(int i = 0; i < characters.Count; i++)
            {
                characters[i].GetComponent<Billy>().toggleTime();
                bool hourglassStatus = hourglass[i].activeInHierarchy;
                hourglass[i].SetActive(!hourglassStatus);
                hourglass[i].GetComponent<Animator>().SetTrigger("ShakeIt");
            }
        }
    }   
}
