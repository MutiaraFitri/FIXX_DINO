using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    public GameObject panelAtas;
    public GameObject panelCheckpoint;
    public GameObject panelCheckpointsea;
    public GameObject panelFinish;
    public GameObject panelFinishing;

    Animator charAnimator;
    GameObject attactEffect;
    private Rigidbody2D jump;
    private float timer = 0;
    public float dessert;
    float tambah;

    private int countJump = 0;
    bool isJumps, hadapKanan = true, hadapKiri = false;

    // Start is called before the first frame update
    void Start()
    {
        charAnimator = GetComponent<Animator>();
        jump = GetComponent<Rigidbody2D>();
        PlayerPrefs.SetFloat("ckSea", 0f);
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        countJump = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if (charAnimator.transform.position.x > 35)
        {
            PlayerPrefs.SetFloat("Checkpoint", 1);
        }
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            charAnimator.SetBool("isWalk", false);
        }
        if (timer <= 0 && !GlobalScript.Instance.gameOver)
        {

            // jika ingin jalaan maka pakai bool jika di lepas false
            //player jalan ke kiri
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                charAnimator.SetBool("isWalk", true);
                if (hadapKanan)
                {
                    charAnimator.transform.Rotate(0, 180, 0);
                    hadapKiri = true;
                    hadapKanan = false;
                }
                charAnimator.transform.Translate(0.1f, 0, 0);
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                charAnimator.SetBool("isWalk", false);
                charAnimator.transform.Translate(0f, 0, 0);
            }
            //player jalan ke kanan
            if (Input.GetKey(KeyCode.RightArrow))
            {
                charAnimator.SetBool("isWalk", true);
                charAnimator.transform.Translate(0.1f, 0, 0);
                if (hadapKiri)
                {
                    charAnimator.transform.Rotate(0, 180, 0);
                    hadapKiri = false;
                    hadapKanan = true;
                }
            }
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                charAnimator.SetBool("isWalk", false);
                charAnimator.transform.Translate(0f, 0, 0);
            }
            // player lompat 
            // get key down hanya bisa dipakai sekali saja, get key bisa dipakai ditahan
            if ((Input.GetKeyDown(KeyCode.UpArrow)) && (countJump < 1))
            {
                jump.AddForce(new Vector3(0f, 1f, 0f) * 10, ForceMode2D.Impulse);
                countJump += 1;
            }
            if (isJumps)
            {
                jump.AddForce(new Vector3(0.0f, 1f, 0.0f) * 10f, ForceMode2D.Impulse);
                isJumps = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Monster")
        {
            print("KENA! monster");
            if (GlobalScript.Instance.isSea)
            {
                print("sea");
                if (PlayerPrefs.GetFloat("ckSea") == 1f)
                {
                    transform.localPosition = new Vector3(109.66f, 1.2f, -5f);
                    // CameraController.Instance.resetLocation(100);
                    CameraController.Instance.resetLocation(0);
                }
                else
                {
                    transform.localPosition = new Vector3(-5.52f, -1.238f, -5f);
                    CameraController.Instance.resetLocation(0);
                }
                GlobalScript.Instance.mati();

            }
            else if (GlobalScript.Instance.isHutan)
            {
                if (PlayerPrefs.GetFloat("Checkpoint") == 1f)
                {
                    transform.localPosition = new Vector3(35f, -1.238f, -5f);
                    CameraController.Instance.resetLocation(100);
                }
                else
                {
                    transform.localPosition = new Vector3(-65.946f, -1.238f, -5f);
                    CameraController.Instance.resetLocation(0);
                }
                GlobalScript.Instance.mati();

            }
            else
            {
                transform.localPosition = new Vector3(-5.52f, -2.581f, -5f);
                CameraController.Instance.resetLocation(0);
                GlobalScript.Instance.mati();

            }
        }
        if (other.gameObject.tag == "Jurang")
        {
            // print("KENA! Jurang");
            if (GlobalScript.Instance.isSea)
            {
                if (PlayerPrefs.GetFloat("ckSea") == 1f)
                {
                    tambah = -40;
                    transform.localPosition = new Vector3(-5, -1.238f, -5f);
                    CameraController.Instance.resetLocation(100);
                }
                else
                {
                    transform.localPosition = new Vector3(-65.946f + dessert, -1.238f, -5f);
                    CameraController.Instance.resetLocation(0);
                }
                GlobalScript.Instance.matiJatuh();

            }
            else if (GlobalScript.Instance.isHutan)
            {
                if (PlayerPrefs.GetFloat("Checkpoint") == 1f)
                {
                    transform.localPosition = new Vector3(35f, -1.238f, -5f);
                    CameraController.Instance.resetLocation(100);
                }
                else
                {
                    transform.localPosition = new Vector3(-65.946f, -1.238f, -5f);
                    CameraController.Instance.resetLocation(0);
                }
                GlobalScript.Instance.matiJatuh();

            }
            else
            {
                transform.localPosition = new Vector3(-5.52f, -2.581f, -5f);
                CameraController.Instance.resetLocation(0);
                GlobalScript.Instance.matiJatuh();
            }
        }

        if (other.gameObject.tag == "Tutorial")
        {
            panelAtas.gameObject.SetActive(true);
        }
        if (other.gameObject.tag == "finish")
        {
            panelFinish.gameObject.SetActive(true);
        }
        if (other.gameObject.tag == "Finish")
        {
            panelFinishing.gameObject.SetActive(true);
        }
        if (other.gameObject.tag == "Checkpoint")
        {
            panelCheckpoint.gameObject.SetActive(true);
        }
        if (other.gameObject.tag == "ckSea")
        {
            PlayerPrefs.SetFloat("ckSea", 1f);
            panelCheckpointsea.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Tutorial")
        {
            panelAtas.gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "Checkpoint")
        {
            panelCheckpoint.gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "ckSea")
        {
            panelCheckpointsea.gameObject.SetActive(false);
        }
    }
}
