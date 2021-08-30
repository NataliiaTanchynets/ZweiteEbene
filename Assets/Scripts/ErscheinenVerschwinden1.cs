using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ErscheinenVerschwinden1 : MonoBehaviour
{
    public GameObject Menue1;
    public GameObject Menue1_Durchsichtig;
    public GameObject Menue2;
    public GameObject Menue2_Durchsichtig;
    public GameObject MenueTakt;
    public GameObject MenueTakt_Durchsichtig;
    public GameObject MenueZündung;
    public GameObject MenueZündung_Durchsichtig;
    public GameObject QuizDurchsichtigS1;
    public GameObject QuizDurchsichtigS2;
    public GameObject QuizDurchsichtigtakt;
    public GameObject QuizDurchsichtigzündung;
    public bool QuizFreischaltungMeldung = false;

    public bool stopschleife = false;

    public bool kolbenvideogespielt = false;
    public bool kurbeltriebvideogespielt = false;
    public bool pleuelstangevideogespielt = false;
    public bool wellevideogespielt = false;
    public bool taktvideogespielt = false;
    public bool funktionvideogespielt = false;


    public GameObject KurbeltriebExplosionAnsicht;
    public GameObject KolbenAnsicht;
    public GameObject PleuelstangeAnsicht;
    public GameObject WelleAnsicht;
    public GameObject TakteAnsicht;
    public GameObject FunktionAnsicht;

    public KontrolleMenue menue;
    public VideoPlayer kurbeltriebExplosion;
    public VideoPlayer kolben;
    public VideoPlayer pleuelstange;
    public VideoPlayer welle;
    public VideoPlayer takte;
    public VideoPlayer zündung;

    public void Start ()
    {

       

    }

    public void Update()
    {
        print("ich bin in der ersten Schleife");
        if (!menue.QuizMarkererkannt) {
            print("ich bin in der zweiten Schleife");
      
        if (menue.Blatt1_1erkannt & menue.MarkerErkannt)
        {
            
            Menue1.SetActive(true);
            Menue1_Durchsichtig.SetActive(false);
            //Menue2.SetActive(true);
        }
        else 
        {
            Menue1.SetActive(false);
            Menue1_Durchsichtig.SetActive(true);
            //Menue2.SetActive(false);
        } 
      


        if (menue.Blatt1_2erkannt & menue.MarkerErkannt)
        {

            Menue2_Durchsichtig.SetActive(false);
            Menue2.SetActive(true);
        }
        else
        {
            Menue2_Durchsichtig.SetActive(true);
            Menue2.SetActive(false);
        }
        if (menue.taktErkannt & menue.MarkerErkannt)
        {


            MenueTakt.SetActive(true);
            MenueTakt_Durchsichtig.SetActive(false);
        }
        else
        {

            MenueTakt.SetActive(false);
            MenueTakt_Durchsichtig.SetActive(true);
        }
      
        if (menue.zündfolgeErkannt & menue.MarkerErkannt & menue.QuizMarkererkannt==false)
        {
            MenueZündung_Durchsichtig.SetActive(false);

            MenueZündung.SetActive(true);
        }
        else
        {
            MenueZündung_Durchsichtig.SetActive(true);
            MenueZündung.SetActive(false);
        }

        if (menue.videoS1==true & menue.MarkerErkannt & menue.aKurbeltriebErkannt & menue.bKolbenErkannt==false)
        {
            KurbeltriebExplosionAnsicht.SetActive(true);
            kurbeltriebExplosion.Play();
            kurbeltriebvideogespielt = true;
            Menue2.SetActive(false);
            Menue1.SetActive(false);
            QuizDurchsichtigS1.SetActive(false);
        }
        else
        {
            KurbeltriebExplosionAnsicht.SetActive(false);
            kurbeltriebExplosion.Stop();
            
        }
        if (menue.videoS1==true & menue.MarkerErkannt & menue.bKolbenErkannt & menue.aKurbeltriebErkannt== false)
        {
            KolbenAnsicht.SetActive(true);
            kolben.Play();
            kolbenvideogespielt = true;
            Menue2.SetActive(false);
            Menue1.SetActive(false);
            QuizDurchsichtigS1.SetActive(false);
        }
        else
        {
            KolbenAnsicht.SetActive(false);
            kolben.Stop();

        }
        if (menue.videoS2==true & menue.MarkerErkannt & menue.cPleuelErkannt & menue.dWelleErkannt==false)
        {
            PleuelstangeAnsicht.SetActive(true);
            pleuelstange.Play();
            pleuelstangevideogespielt = true;
            Menue2.SetActive(false);
            Menue1.SetActive(false);
            QuizDurchsichtigS2.SetActive(false);
        }
        else
        {
            PleuelstangeAnsicht.SetActive(false);
            pleuelstange.Stop();

        }

        if (menue.videoS2==true & menue.MarkerErkannt & menue.dWelleErkannt & menue.cPleuelErkannt==false)
        {
            WelleAnsicht.SetActive(true);
            welle.Play();
            wellevideogespielt = true;
            Menue2.SetActive(false);
            Menue1.SetActive(false);
            QuizDurchsichtigS2.SetActive(false);
        }
        else
        {
            WelleAnsicht.SetActive(false);
            welle.Stop();

        }

        if (menue.videotakt==true & menue.markerAnimationerkannt)
        {
            TakteAnsicht.SetActive(true);
            takte.Play();
            taktvideogespielt = true;
            MenueTakt.SetActive(false);
            QuizDurchsichtigtakt.SetActive(false);
        }
        else
        {
            TakteAnsicht.SetActive(false);
            takte.Stop();

        }
        if (menue.videozündung==true & menue.markerAnimationerkannt)
        {
            QuizDurchsichtigzündung.SetActive(false);
            FunktionAnsicht.SetActive(true);
            zündung.Play();
            funktionvideogespielt = true;
            MenueZündung.SetActive(false);

        }
        else
        {
            FunktionAnsicht.SetActive(false);
            zündung.Stop();

        }

        if (menue.Blatt1_2erkannt & kolbenvideogespielt==true & kurbeltriebvideogespielt==true & pleuelstangevideogespielt==true & wellevideogespielt==true & menue.MarkerErkannt==false & menue.QuizMarkererkannt == false)
        {
            QuizDurchsichtigS2.SetActive(true);

               
        }
        else
        {

            QuizDurchsichtigS2.SetActive(false);
        }


        if (menue.Blatt1_1erkannt & kolbenvideogespielt == true & kurbeltriebvideogespielt == true & pleuelstangevideogespielt == true & wellevideogespielt == true & menue.MarkerErkannt == false & menue.QuizMarkererkannt == false)
        {
            QuizDurchsichtigS1.SetActive(true);
            
        }
        else
        {
            QuizDurchsichtigS1.SetActive(false);


        }
        if ((menue.Blatt1_1erkannt| menue.Blatt1_2erkannt) & kolbenvideogespielt == true & kurbeltriebvideogespielt == true & pleuelstangevideogespielt == true & wellevideogespielt == true & menue.dWelleErkannt==false & menue.cPleuelErkannt==false & menue.bKolbenErkannt==false & menue.aKurbeltriebErkannt==false)
            {
                QuizFreischaltungMeldung = true;

            }


            if (menue.zündfolgeErkannt & funktionvideogespielt==true & menue.MarkerErkannt == false)
        {
            FunktionAnsicht.SetActive(false);
            QuizDurchsichtigzündung.SetActive(true);

        }
        else
        {
            QuizDurchsichtigzündung.SetActive(false);

        }
        
        if (menue.zündfolgeErkannt & funktionvideogespielt == true & menue.markerAnimationerkannt==false)
            {
                QuizFreischaltungMeldung = true;

            }

            if (menue.taktErkannt & taktvideogespielt==true & menue.MarkerErkannt == false)
        {
            TakteAnsicht.SetActive(false);
            QuizDurchsichtigtakt.SetActive(true);

        }
        else
        {
            QuizDurchsichtigtakt.SetActive(false);

        }
            if (menue.taktErkannt & taktvideogespielt == true & menue.markerAnimationerkannt == false)
            {
                QuizFreischaltungMeldung = true;

            }

            if (kolbenvideogespielt == true & kurbeltriebvideogespielt == true & pleuelstangevideogespielt == true & wellevideogespielt == true & menue.MarkerErkannt == false)
        {

            stopschleife=true;
       

        }
        if(taktvideogespielt==true)
        {
            stopschleife = true;

        }
        if (funktionvideogespielt == true)
        {
            stopschleife = true;

        }
        }
        else
        {
            Menue1_Durchsichtig.SetActive(false);
            MenueTakt_Durchsichtig.SetActive(false);
            Menue2_Durchsichtig.SetActive(false);
            MenueZündung_Durchsichtig.SetActive(false);
            MenueZündung.SetActive(false);
            QuizDurchsichtigzündung.SetActive(false);
            MenueTakt.SetActive(false);
            Menue1.SetActive(false);
            Menue2.SetActive(false);
            QuizDurchsichtigS1.SetActive(false);
            QuizDurchsichtigS2.SetActive(false);
            
        }

    }




}
