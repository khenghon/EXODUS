// How to switch weapon in Unity
// https://answers.unity.com/questions/589666/how-to-switch-weaponsc.html

using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject[] weapons;
    public int currentWeapon = 0;
    private int numOfWeapons;

    void Start()
    {
        // Set default weapon
        numOfWeapons = weapons.Length;
        SwitchWeapon(currentWeapon); 

    }

    void Update()
    {
        // Changes weapon on number input
        for (int i = 1; i <= numOfWeapons; i++)
        {
            if (Input.GetKeyDown("" + i))
            {
                currentWeapon = i - 1;
                SwitchWeapon(currentWeapon);
            }
        }

    }

    void SwitchWeapon(int index)
    {

        for (int i = 0; i < numOfWeapons; i++)
        {
            if (i == index) weapons[i].gameObject.SetActive(true);
            else weapons[i].gameObject.SetActive(false);
        }
    }
}
