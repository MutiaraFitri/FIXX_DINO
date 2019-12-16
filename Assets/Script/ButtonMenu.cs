using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMenu : MonoBehaviour
{
    public int thisPosisi;
    public Animator animator;
    // Start is called before the first frame update
    void Start()    
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ButtonController.Instance.posisi == thisPosisi)
            {
                animator.SetBool ("onSelect", true);
                // if(Input.GetAxis ("Submit") == 1){
                //     animator.SetBool ("pressed", true);
                // }else if (animator.GetBool ("pressed")){
                //     animator.SetBool ("pressed", false);
                // }
            }else{
                animator.SetBool ("onSelect", false);
            }
    }
}
