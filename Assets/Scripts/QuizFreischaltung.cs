using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizFreischaltung : MonoBehaviour
{
    public GameObject QuizFreischaltungMeldungS1;
    public GameObject QuizFreischaltungMeldungS2;
    public GameObject QuizFreischaltungMeldungTakt;
    public GameObject QuizFreischaltungMeldungZündung;
    public ErscheinenVerschwinden1 boolVariable;
    public bool stopschleife = false;
    public KontrolleMenue menue;
    // Update is called once per frame
    public void Update()
    {
        if (boolVariable.QuizFreischaltungMeldung == true & stopschleife==false)
        {
        QuizFreischaltungMeldungS1.SetActive(true);
        QuizFreischaltungMeldungS2.SetActive(true);
        QuizFreischaltungMeldungTakt.SetActive(true);
        QuizFreischaltungMeldungZündung.SetActive(true);
            stopschleife = true;
            print("Nur einmal in der Schleife");
        }
       if (stopschleife==true & (menue.MarkerErkannt == false | menue.QuizMarkererkannt))
        {
            QuizFreischaltungMeldungS1.SetActive(false);
            QuizFreischaltungMeldungS2.SetActive(false);
            QuizFreischaltungMeldungTakt.SetActive(false);
            QuizFreischaltungMeldungZündung.SetActive(false);
        }
    }

   /* public void UnaktivSetzen()
    {
        QuizFreischaltungMeldung.SetActive(false);
    }*/
}
