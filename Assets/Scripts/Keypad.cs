using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keypad : MonoBehaviour
{
    [SerializeField] private Text code;
    [SerializeField] private Animator Door;
    private string Answer = "2398";

    private void Start()
    {
        code.text = "";
    }

    public void Number (int number)


    {
        code.text += number.ToString();
    }

    public void Execute()
    {
        if (code.text.Equals(Answer))
        {
            code.text = "Correct";
            Door.SetBool("Open", true);
            Door.Play("Dooropen");
            StartCoroutine("StopDoor");

        }
        else
        {
            code.text = "Incorrect";
        }
    }
    IEnumerator StopDoor()
    {
        yield return new WaitForSeconds(0.8f);
        Door.SetBool("Open",false);
        Door.enabled = false;

    }
}
