using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OathSelect : MonoBehaviour
{
    public TextMeshProUGUI dropdown;
    public TextMeshProUGUI title;
    string oath;
    public static int oathNumber;

    public void SelectOath(int val)
    {
        oathNumber = val;
        if(val == 2)
        {
            oath = "Flagellant";
        }
        if(val == 1)
        {
            oath = "Warrior";
        }
        if(val == 0)
        {
            oath = "Paladin";
        }

        title.text = $"{oath}";
    }
}
