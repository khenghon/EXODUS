using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class HUD_Bind : MonoBehaviour
{
    public Slider[] sliderInstance = new Slider[3];

    // Start is called before the first frame update
    void Start()
    {
        // Set range limit for HP, stamina, oxygen level 
        foreach (Slider instance in sliderInstance) {
            instance.minValue = 0;
            instance.maxValue = 110;
            instance.wholeNumbers = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log ("Current Volume: " + sliderInstance[0].value);
    }
}
