using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keypad : MonoBehaviour
{
    [SerializeField] private Text code;
    [SerializeField] private Animator Door;
    private string Answer = "12398";


   public void Number (int number)


    {
        code.text += number.ToString();
    }

    public void Execute()
    {
        if (code.text == Answer)
        {
            code.text = "Correct";
            Door.SetBool("Open", true);
            StartCoroutine("StopDoor");

        }
        else
        {
            code.text = "Incorrect";
        }
    }
    IEnumerator StopDoor()
    {
        yield return new WaitForSeconds(0.3f);
        Door.SetBool("Open",false);
        Door.enabled = false;

    }
}
