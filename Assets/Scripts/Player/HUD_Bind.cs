using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class HUD_Bind : MonoBehaviour
{
    public Slider[] sliderInstance = new Slider[3];
    public int HealthPoint;
    public int Stamina;
    public int Oxygen;

    // Start is called before the first frame update
    void Start()
    {
        // Set range limit for HP, stamina, oxygen level 
        sliderInstance[0].value = HealthPoint;
        sliderInstance[1].value = Stamina;
        sliderInstance[2].value = Oxygen;
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log ("Current Volume: " + sliderInstance[0].value);
        sliderInstance[0].value = HealthPoint;
        sliderInstance[1].value = Stamina;
        sliderInstance[2].value = Oxygen;
    }
}
