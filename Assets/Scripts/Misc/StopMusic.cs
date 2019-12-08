using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMusic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        //counts music objs and will delete music
        GameObject[] objs = GameObject.FindGameObjectsWithTag("GameController");
      
            Destroy(this.gameObject);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
