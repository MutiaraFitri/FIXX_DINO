using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScript : MonoBehaviour
{
    public string Level;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Level=="sea"){
            GlobalScript.Instance.isHutan=false;
            GlobalScript.Instance.isSea=true;
        }
        if(Level=="hutan"){
            GlobalScript.Instance.isHutan=true;
            GlobalScript.Instance.isSea=false;
        }
    }
}
