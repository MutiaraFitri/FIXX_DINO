using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController Instance;
    public GameObject player;
    private float offset;
    public float babi;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        offset = transform.position.x - player.transform.position.x;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(player.transform.position.x>-64 && player.transform.position.x<165.3f){
            transform.position = new Vector3(player.transform.position.x+offset,transform.position.y,transform.position.z);
        }
    }

    public void resetLocation(float x){
        if(babi!=0){
            x=babi;
        }
            transform.position = new Vector3(-55.95f+x,0,-10f);
    }
}