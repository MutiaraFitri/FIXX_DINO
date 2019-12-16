using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundEffectManager : MonoBehaviour
{
    public static SoundEffectManager Instance;
    public AudioSource audioSource;

    [Header("Audio Koin !")]
    public AudioClip sfxCoin;
    public AudioClip sfxButton;
    public AudioClip sfxGameOver;
    public bool isOn;
    public Text sfxButtonText;

    // Start is called before the first frame update
    void Start()
    {
        Instance= this;
    }

    public void PlayCoinSFX()
    {
             audioSource.PlayOneShot(sfxCoin,0.75f);
       
    }

    public void GameOverSFX()
    {
        audioSource.PlayOneShot(sfxGameOver,0.75f);
       
    }
    
}
