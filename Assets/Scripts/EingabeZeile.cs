using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EingabeZeile: MonoBehaviour
{
    public GameObject panel;
    public InputField inputField;

    public string platzhalterName;

    public static bool nameExist = false;

    private void Start()
    {
        panel.SetActive(true);
    }

    public void Update()
    {
        if (nameExist == true)
        {
            panel.SetActive(false);
        }
        else
        {
            panel.SetActive(true);
        }
    }
    public void CheckName(string name)
    {
        name = inputField.text;
        print("wir sind bevor if");
        if (name.Length >= 3 && nameExist == false)
        {
            print("wir sind in if");

            print("Ihr Name lautet " + name);
            nameExist = true;
            print("NameExist ist  " + nameExist);
            platzhalterName = name;
            MapValuesToPlayer();
        }
        else
        {
            print(" Versuchen Sie erneut.");
        }

    }
   void MapValuesToPlayer() {
        Player player = GameObject.FindObjectOfType<Player>();
        player.myStats.name = platzhalterName;
}
}
