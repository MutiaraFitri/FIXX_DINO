using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalScript : MonoBehaviour
{
    public static GlobalScript Instance;
    public GameObject nyawa_1;
    public GameObject nyawa_2,nyawa;
    public GameObject PanelGameOver,panelPause;
    public GameObject nyawa_3;
    public float health=100;
    public int life;
    private float healthAwal;
    public int score=0;
    public bool isPause,isHutan,isSea;

    public bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetFloat("Checkpoint",0);
        Instance = this;
        healthAwal = health;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver){
            PanelGameOver.gameObject.SetActive(true);
            SoundEffectManager.Instance.GameOverSFX();
            nyawa.gameObject.SetActive(false);
        }
    }

    public void mati(){
        if(life==3){
            Destroy(nyawa_3);
        }else if(life==2){
            Destroy(nyawa_2);
        }else if(life==1){
            Destroy(nyawa_1);
            gameOver = true;
        }
        life-=1;
    }

    public void matiJatuh(){
            gameOver = true; 
            PlayerPrefs.SetFloat("ckSea",0f);
            PlayerPrefs.SetFloat("Checkpoint",0f);
            SoundEffectManager.Instance.GameOverSFX();     
    }

    public float getHealthAwal(){
        return healthAwal;
    }

    public void setPause()
    {
        isPause=true;
        panelPause.gameObject.SetActive(true);
    }

    public void setPlay()
    {
        isPause=false;
        panelPause.gameObject.SetActive(false);
    }

    public void Restart()
    {
          
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    public void Home()
    {
        SceneManager.LoadScene("main_menu");
    }
}