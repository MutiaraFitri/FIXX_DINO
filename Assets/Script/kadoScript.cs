using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kadoScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if( other.gameObject.name == "player"){
            // Text my_text = GameObject.Find("Middleground/Coins/Canvas/score").GetComponent<Text>();
            print ("kena");
            Destroy(this.gameObject);
            GlobalScript.Instance.score += 5;
            SoundEffectManager.Instance.PlayCoinSFX();
        }        
    }
}
