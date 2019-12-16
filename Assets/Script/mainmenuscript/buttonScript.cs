using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playButtons(){
            Application.LoadLevel("map");
    }
    public void level1(){
            Application.LoadLevel("dessert");
    }
    public void level2(){
            Application.LoadLevel("Hutan");
    }
    public void level3(){
            Application.LoadLevel("sea_final");
    }
    public void finall(){
            Application.LoadLevel("finall");
    }

}
