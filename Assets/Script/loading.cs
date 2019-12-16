using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loading : MonoBehaviour
{
    public Transform masukkanLoadingbar;
    [SerializeField]
    private float nilaiSekarang;
    [SerializeField]
    private float nilaiKecepatan;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (nilaiSekarang <100){
            nilaiSekarang += nilaiKecepatan * Time.deltaTime;
            Debug.Log ((int)nilaiSekarang);

        }else{
            Application.LoadLevel("main_menu");
        }
        masukkanLoadingbar.GetComponent<Image>().fillAmount=nilaiSekarang/100;
    }
}
