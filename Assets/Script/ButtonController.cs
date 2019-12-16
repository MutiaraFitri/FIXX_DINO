using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public static ButtonController Instance;
    public int posisi,maksimal;
    public bool keyDown;
    // Start is called before the first frame update
    void Start()
    {
        Instance=this;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Vertical") != 0){
            if(!keyDown){
                if(Input.GetAxis("Vertical")>0){
                    if(posisi<maksimal){
                        posisi++;
                    }else
                    {
                        posisi=0;
                    }
                    keyDown=true;
                }
                if(Input.GetAxis("Vertical")<0){
                    if(posisi>0){
                        posisi--;
                    }else
                    {
                        posisi=maksimal;
                    }
                    keyDown=true;
                }
            }
        }else
        {
            keyDown = false;
        }
    }
}
