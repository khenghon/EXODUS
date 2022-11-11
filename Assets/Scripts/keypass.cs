using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;


public class Keypad : MonoBehaviour
{
    public GameObject player;
    public GameObject keypass;
    public GameObject hud;
    public GameObject inv;


    public GameObject animate;
    public Animator ANI;


    public Text textobject;
    public string answer = "exodus";

    public AudioSource button;
    public AudioSource correct;
    public AudioSource wrong;

    public bool should_ani;


    void Start()
    {
        keypass.SetActive(false);

    }


    public void onetwothree(int number)
    {
        textobject.text += number.ToString();
        button.Play();
    }

    public void run()
    {
        if (textobject.text == answer)
        {
            correct.Play();
            textonject.text = "Right";

        }
        else
        {
            wrong.Play();
            textobject.text = "Wrong";
        }


    }

    public void Clear()
    {
        {
            textobject.text = "";
            button.Play();
        }
    }

    public void leave()
    {
        keypass.SetActive(false);
        inv.SetActive(true);
        hud.SetActive(true);
        player.GetComponent<FirstPersonController>().enabled = true;
    }

    public void Update()
    {
        if (textobject.text == "Right" && animate)
        {
            ANI.SetBool("animate", true);
            Debug.Log("its open");
        }


        if(keypadobject.activeInHierarchy)
        {
            hud.SetActive(false);
            inv.SetActive(false);
            player.GetComponent<FirstPersonController>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

    }


}
// taken most of the inspiration from user1 productions youtube channel https://www.youtube.com/watch?v=c2Ze4WRUgKY

