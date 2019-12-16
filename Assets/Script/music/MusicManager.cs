using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;
    public AudioSource bgmSource;
    public Slider musicSlider;

    public Text musicButton;
    public AudioClip audioClips;
    //public AudioClip[] audioClips;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        Inisiate();
    }

    public void Inisiate()
    {
        bgmSource.volume = PlayerPrefs.GetFloat("musicVolume", 0.5f);
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume", 0.5f);
    }
    // public void setMusic(int id){
    //     bgmSource.clip = audioClips[id];
    //     PlayMusic();

    // }
    public void setVolume(){
        bgmSource.volume= musicSlider.value;
        PlayerPrefs.SetFloat("musicVolume", bgmSource.volume); // ini untuk save mode

    }

    // Update is called once per frame
    public void PlayMusic()
    {
        bgmSource.Play();
        musicButton.text =" Music ON";
    }


    public void StopMusic()
    {
        //bgmSource.Stop();
        bgmSource.Pause();
        musicButton.text =" Music OFF";
    }

    public void ToggleMusic()
    {
        if(bgmSource.isPlaying)
        {
            bgmSource.Pause();
            musicButton.text =" Music OFF";
        }
        else
        {
            bgmSource.Play();
            musicButton.text =" Music ON";
        }
    }


}
