using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
     // Start is called before the first frame update
    private float timer=5 ;
    public GameObject tanah;
    private float arah= -0.025f ;
    void Start()
    {
        tanah.GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= 0.025f ;
        if( timer > 0 )
        {
            tanah.transform.Translate(arah,0,0);
        }
        else {
            arah = arah*-1;
            timer = 5;
        }
    }
}