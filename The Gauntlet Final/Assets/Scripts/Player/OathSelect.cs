using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OathSelect : MonoBehaviour
{
    public TextMeshProUGUI dropdown;
    private static string oath;

    public void SelectOath(int val)
    {
        if(val == 1)
        {
            oath = "Flagellant";
        }
        if(val == 2)
        {
            oath = "Warrior";
        }
        if(val == 3)
        {
            oath = "Paladin";
        }

        if (val == 0)
        {
            Debug.Log("That is not a valid choice");
        }
        else
        { Debug.Log($"{oath}  has been chosen"); }
    }
}
