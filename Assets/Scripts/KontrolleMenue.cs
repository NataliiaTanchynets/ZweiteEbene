using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KontrolleMenue : MonoBehaviour
{
    public bool thema_1 = false;
    public bool thema_2 = false;
    public bool thema_3 = false;

    public bool Blatt1_1erkannt= false;
    public bool Blatt1_2erkannt = false;
    public bool MarkerErkannt = false;
    public bool aKurbeltriebErkannt = false;
    public bool bKolbenErkannt = false;
    public bool cPleuelErkannt = false;
    public bool dWelleErkannt = false;
    public bool taktErkannt = false;
    public bool zündfolgeErkannt = false;
    public bool markerAnimationerkannt = false;
    public bool QuizMarkererkannt = false;

    public bool videoS1 = false;
    public bool videoS2 = false;
    public bool videotakt = false;
    public bool videozündung = false;

    public ErscheinenVerschwinden1 erscheinen;

    public void EinschaltenBlatt_1_1() {
        Blatt1_1erkannt = true;
        thema_1 = true;
        videoS1 = true;
        videoS2 = false;
    }

    public void MarkerErkennung()
    {
        MarkerErkannt = true;
    }
    public void MarkerVerloren()
    {
        MarkerErkannt = false;
    }
    public void EinschaltenBlatt_1_2()
    {
        videoS1 = false;
        videoS2 = true;
        Blatt1_2erkannt = true;
        thema_1 = true;
    }

    public void AusschaltenBlatt_1()
    {
        Blatt1_1erkannt = false;
    }
    public void AusschaltenBlatt_2()
    {
        Blatt1_2erkannt = false;
    }

    public void KurbeltriebErkannt()
    {
        aKurbeltriebErkannt = true;

    }

    public void KurbeltriebVerloren()
    {
        aKurbeltriebErkannt = false;

    }
    public void KolbenErkannt()
    {
        bKolbenErkannt = true;

    }

    public void KolbenVerloren()
    {
        bKolbenErkannt = false;

    }
    public void PleuelErkannt()
    {
        cPleuelErkannt = true;

    }

    public void PleuelVerloren()
    {
        cPleuelErkannt = false;

    }
    public void WelleErkannt()
    {
        dWelleErkannt = true;

    }

    public void WelleVerloren()
    {
        dWelleErkannt = false;

    }

    public void TaktErkannt()
    {
        taktErkannt = true;
        thema_2 = true;
        videotakt = true;

    }
    public void TaktVerloren()
    {
        taktErkannt = false;

    }
    public void ZündungErkannt()
    {
        zündfolgeErkannt = true;
        thema_3 = true;
        videozündung = true;

    }
    public void ZündungVerloren()
    {
        zündfolgeErkannt = false;

    }
    public void MarkerAnimErkannt()
    {
        markerAnimationerkannt = true;

    }
    public void MarkerAnimVerloren()
    {
        markerAnimationerkannt = false;

    }
    public void QuizErkannt()
    {
        if (erscheinen.funktionvideogespielt == true| erscheinen.taktvideogespielt == true|(erscheinen.kolbenvideogespielt == true & erscheinen.kurbeltriebvideogespielt == true & erscheinen.pleuelstangevideogespielt == true & erscheinen.wellevideogespielt == true)) { 
        QuizMarkererkannt = true;
        erscheinen.QuizDurchsichtigtakt.SetActive(false);
        erscheinen.QuizDurchsichtigzündung.SetActive(false);
        erscheinen.QuizDurchsichtigS1.SetActive(false);
        erscheinen.QuizDurchsichtigS2.SetActive(false);
    }
    }
    public void QuizVerloren()
    {
        erscheinen.QuizDurchsichtigtakt.SetActive(true);
        erscheinen.QuizDurchsichtigzündung.SetActive(true);
        erscheinen.QuizDurchsichtigS1.SetActive(true);
        erscheinen.QuizDurchsichtigS2.SetActive(true);
    }

}
