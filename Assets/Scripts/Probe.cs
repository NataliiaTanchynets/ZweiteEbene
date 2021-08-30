using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class Probe : MonoBehaviour
{
    public GameObject aTransparent;
    public GameObject bTransparent;
    public GameObject cTransparent;
    public GameObject dTransparent;
    public GameObject quizTransparent;

    public bool cubeBool;
    public bool sphereBool;
    public bool zylinderBool;
    public bool planeBool;
    public bool quizBool;

    /*public GameObject cube;
    public GameObject sphere;
    public GameObject zylinder;
    public GameObject plane;*/

 
    public allgemeinVariantenCheck variantenCheck;
    public QuizGame QuizGameThema1;
    public QuizGame QuizGameThema2;
    public QuizGame QuizGameThema3;

    //public GameObject GO_QuizGameThema1;
    //public GameObject GO_QuizGameThema2;
    //public GameObject GO_QuizGameThema3;

    public TimerQuiz timerQuiz;

    public KontrolleMenue menue;
    public bool menueaktiv = false;
    public ErscheinenVerschwinden1 erscheinen;

    public GameObject Menue;
    float Zeit;
    private float realeZeit;
    private float Startzeit = 0;

    public bool aScleifeBeendet = false;
    public bool bScleifeBeendet = false;
    public bool cScleifeBeendet = false;
    public bool dScleifeBeendet = false;

    

    public GameObject [] progressKreis;
   
    float ZeitBar = 2f;
    float ZeitKreis;
    public Outline[] outlines;

    void Start()
    {
        //GO_QuizGameThema2.SetActive(false);
        //GO_QuizGameThema3.SetActive(false);
        //GO_QuizGameThema1.SetActive(false);

        Menue.SetActive(false);
        variantenCheck.VarianteChoosed();
        variantenCheck.WiederholungStart();

        foreach (Outline o in outlines)
        {
            o.enabled = false;

        }
        foreach (GameObject prKreis in progressKreis)
        {
            prKreis.SetActive(false) ;

        }
        ZeitKreis = ZeitBar;
    }
    void Update()
    {
        cubeBool = aTransparent.GetComponent<MeshRenderer>().enabled;
        sphereBool = bTransparent.GetComponent<MeshRenderer>().enabled;
        zylinderBool = cTransparent.GetComponent<MeshRenderer>().enabled;
        planeBool = dTransparent.GetComponent<MeshRenderer>().enabled;
        quizBool = quizTransparent.GetComponent<MeshRenderer>().enabled;

        if (quizBool & (menue.Blatt1_1erkannt | menue.Blatt1_2erkannt))
        {
            //GO_QuizGameThema1.SetActive(true);
            // timerQuiz.StartTimer();
            if (erscheinen.kolbenvideogespielt == true & erscheinen.kurbeltriebvideogespielt == true & erscheinen.pleuelstangevideogespielt == true & erscheinen.wellevideogespielt == true)
            {

                Menue.SetActive(true);
                if (!menueaktiv)
                {
                    print("Blatt ist erkannt Thema 1 soll aktiv werden");
                    print(" Ich bin in der schleife für die erste frage in der Probe");
                    timerQuiz.StartTimer();
                    QuizGameThema1.ersteFrage();


                }


                if (cubeBool & !sphereBool & !zylinderBool & !planeBool)
                {

                    //cube.SetActive(true);
                    outlines[0].enabled = true;
                    progressKreis[0].SetActive(true);
                    ZeitKreis -= Time.deltaTime;
                    progressKreis[0].GetComponent<Image>().fillAmount = ZeitKreis / ZeitBar;
                    realeZeit += Time.deltaTime;

                    if (realeZeit > 2f)
                    {

                        variantenCheck.VarianteChoosed();
                        if (variantenCheck._choosen == true & variantenCheck.Wiederholung == true)
                        {

                            QuizGameThema1.Prüfung(0);
                            variantenCheck.VarianteNotChoosed();
                            aScleifeBeendet = true;
                        }

                        print("Ich muss jetzt in !aBool schleife gehen");

                    }


                }
                if (!cubeBool & aScleifeBeendet)
                {
                    outlines[0].enabled = false;
                    ZeitKreis = ZeitBar;
                    realeZeit = Startzeit;
                    variantenCheck.VarianteNotChoosed();
                    print("Variante muss wieder ausgewählt werden" + variantenCheck._choosen);
                    variantenCheck.WiederholungStart();
                    print("ist weg");
                    if (variantenCheck._choosen == false & variantenCheck.Wiederholung == true & aScleifeBeendet == true)
                    {
                        QuizGameThema1.questionGenerate();
                        variantenCheck.VarianteNotChoosed();

                    }
                    aScleifeBeendet = false;
                }


                if (sphereBool & !cubeBool & !zylinderBool & !planeBool)
                {
                   // sphere.SetActive(true);
                    outlines[1].enabled = true;
                    progressKreis[1].SetActive(true);
                    ZeitKreis -= Time.deltaTime;
                    progressKreis[1].GetComponent<Image>().fillAmount = ZeitKreis / ZeitBar;
                    realeZeit += Time.deltaTime;
                    if (realeZeit > 2f)
                    {
                        variantenCheck.VarianteChoosed();
                        if (variantenCheck._choosen == true & variantenCheck.Wiederholung == true)
                        {

                            QuizGameThema1.Prüfung(1);
                            variantenCheck.VarianteNotChoosed();
                            bScleifeBeendet = true;
                        }
                        print("Ich muss jetzt in bBool schleife gehen");

                    }


                }

                if (!sphereBool & bScleifeBeendet)
                {
                    realeZeit = Startzeit;
                    outlines[1].enabled = false;
                    ZeitKreis = ZeitBar;
                    variantenCheck.VarianteNotChoosed();
                    print("Variante muss wieder ausgewählt werden" + variantenCheck._choosen);
                    variantenCheck.WiederholungStart();
                    print("ist weg");
                    if (variantenCheck._choosen == false & variantenCheck.Wiederholung == true & bScleifeBeendet == true)
                    {
                        QuizGameThema1.questionGenerate();
                        variantenCheck.VarianteNotChoosed();

                    }
                    bScleifeBeendet = false;
                }


                if (zylinderBool & !cubeBool & !sphereBool & !planeBool)
                {
                    //zylinder.SetActive(true);
                    outlines[2].enabled = true;
                    progressKreis[2].SetActive(true);
                    ZeitKreis -= Time.deltaTime;
                    progressKreis[2].GetComponent<Image>().fillAmount = ZeitKreis / ZeitBar;
                    realeZeit += Time.deltaTime;
                    if (realeZeit > 2f)
                    {
                        variantenCheck.VarianteChoosed();
                        if (variantenCheck._choosen == true & variantenCheck.Wiederholung == true)
                        {

                            QuizGameThema1.Prüfung(2);
                            variantenCheck.VarianteNotChoosed();
                            cScleifeBeendet = true;
                        }
                        print("Ich muss jetzt in cBool schleife gehen");

                    }


                }

                if (!zylinderBool & cScleifeBeendet)
                {
                    realeZeit = Startzeit;
                    outlines[2].enabled = false;
                    ZeitKreis = ZeitBar;
                    variantenCheck.VarianteNotChoosed();
                    print("Variante muss wieder ausgewählt werden" + variantenCheck._choosen);
                    variantenCheck.WiederholungStart();
                    print("ist weg");
                    if (variantenCheck._choosen == false & variantenCheck.Wiederholung == true & cScleifeBeendet == true)
                    {
                        QuizGameThema1.questionGenerate();
                        variantenCheck.VarianteNotChoosed();

                    }
                    cScleifeBeendet = false;
                }

                if (planeBool & !cubeBool & !sphereBool & !zylinderBool)
                {
                    //plane.SetActive(true);
                    outlines[3].enabled = true;
                    progressKreis[3].SetActive(true);
                    ZeitKreis -= Time.deltaTime;
                    progressKreis[3].GetComponent<Image>().fillAmount = ZeitKreis / ZeitBar;
                    realeZeit += Time.deltaTime;

                    if (realeZeit > 2f)
                    {
                        variantenCheck.VarianteChoosed();
                        if (variantenCheck._choosen == true & variantenCheck.Wiederholung == true)
                        {

                            QuizGameThema1.Prüfung(3);
                            variantenCheck.VarianteNotChoosed();
                            dScleifeBeendet = true;
                        }
                    }

                }
                if (!planeBool & dScleifeBeendet)
                {
                    realeZeit = Startzeit;
                    outlines[3].enabled = false;
                    ZeitKreis = ZeitBar;
                    variantenCheck.VarianteNotChoosed();
                    print("Variante muss wieder ausgewählt werden" + variantenCheck._choosen);
                    variantenCheck.WiederholungStart();
                    print("ist weg");
                    if (variantenCheck._choosen == false & variantenCheck.Wiederholung == true & dScleifeBeendet == true)
                    {
                        QuizGameThema1.questionGenerate();
                        variantenCheck.VarianteNotChoosed();

                    }
                    dScleifeBeendet = false;
                }


            }
        }


        else if (quizBool & menue.taktErkannt& erscheinen.taktvideogespielt == true)
        {
            //GO_QuizGameThema2.SetActive(true);
            Menue.SetActive(true);
            //timerQuiz.StartTimer();
            if (!menueaktiv)
            {
                print(" Ich bin in der schleife für die erste frage in der Probe");
                timerQuiz.StartTimer();
                QuizGameThema2.ersteFrage();


            }
            print("Blatt ist erkannt Thema 2 soll aktiv werden");
            if (cubeBool & !sphereBool & !zylinderBool & !planeBool)
            {

               // cube.SetActive(true);
                outlines[0].enabled = true;
                progressKreis[0].SetActive(true);
                ZeitKreis -= Time.deltaTime;
                progressKreis[0].GetComponent<Image>().fillAmount = ZeitKreis / ZeitBar;
                realeZeit += Time.deltaTime;

                if (realeZeit > 2f)
                {

                    variantenCheck.VarianteChoosed();
                    if (variantenCheck._choosen == true & variantenCheck.Wiederholung == true)
                    {

                        QuizGameThema2.Prüfung(0);
                        variantenCheck.VarianteNotChoosed();
                        aScleifeBeendet = true;
                    }

                    print("Ich muss jetzt in !aBool schleife gehen");

                }


            }
            if (!cubeBool & aScleifeBeendet)
            {
                outlines[0].enabled = false;
                ZeitKreis = ZeitBar;
                realeZeit = Startzeit;
                variantenCheck.VarianteNotChoosed();
                print("Variante muss wieder ausgewählt werden" + variantenCheck._choosen);
                variantenCheck.WiederholungStart();
                print("ist weg");
                if (variantenCheck._choosen == false & variantenCheck.Wiederholung == true & aScleifeBeendet == true)
                {
                    QuizGameThema2.questionGenerate();
                    variantenCheck.VarianteNotChoosed();

                }
                aScleifeBeendet = false;
            }


            if (sphereBool & !cubeBool & !zylinderBool & !planeBool)
            {
                //sphere.SetActive(true);
                outlines[1].enabled = true;
                progressKreis[1].SetActive(true);
                ZeitKreis -= Time.deltaTime;
                progressKreis[1].GetComponent<Image>().fillAmount = ZeitKreis / ZeitBar;
                realeZeit += Time.deltaTime;
                if (realeZeit > 2f)
                {
                    variantenCheck.VarianteChoosed();
                    if (variantenCheck._choosen == true & variantenCheck.Wiederholung == true)
                    {

                        QuizGameThema2.Prüfung(1);
                        variantenCheck.VarianteNotChoosed();
                        bScleifeBeendet = true;
                    }
                    print("Ich muss jetzt in bBool schleife gehen");

                }


            }

            if (!sphereBool & bScleifeBeendet)
            {
                realeZeit = Startzeit;
                outlines[1].enabled = false;
                ZeitKreis = ZeitBar;
                variantenCheck.VarianteNotChoosed();
                print("Variante muss wieder ausgewählt werden" + variantenCheck._choosen);
                variantenCheck.WiederholungStart();
                print("ist weg");
                if (variantenCheck._choosen == false & variantenCheck.Wiederholung == true & bScleifeBeendet == true)
                {
                    QuizGameThema2.questionGenerate();
                    variantenCheck.VarianteNotChoosed();

                }
                bScleifeBeendet = false;
            }


            if (zylinderBool & !cubeBool & !sphereBool & !planeBool)
            {
                //zylinder.SetActive(true);
                outlines[2].enabled = true;
                progressKreis[2].SetActive(true);
                ZeitKreis -= Time.deltaTime;
                progressKreis[2].GetComponent<Image>().fillAmount = ZeitKreis / ZeitBar;
                realeZeit += Time.deltaTime;
                if (realeZeit > 2f)
                {
                    variantenCheck.VarianteChoosed();
                    if (variantenCheck._choosen == true & variantenCheck.Wiederholung == true)
                    {

                        QuizGameThema2.Prüfung(2);
                        variantenCheck.VarianteNotChoosed();
                        cScleifeBeendet = true;
                    }
                    print("Ich muss jetzt in cBool schleife gehen");

                }


            }

            if (!zylinderBool & cScleifeBeendet)
            {
                realeZeit = Startzeit;
                outlines[2].enabled = false;
                ZeitKreis = ZeitBar;
                variantenCheck.VarianteNotChoosed();
                print("Variante muss wieder ausgewählt werden" + variantenCheck._choosen);
                variantenCheck.WiederholungStart();
                print("ist weg");
                if (variantenCheck._choosen == false & variantenCheck.Wiederholung == true & cScleifeBeendet == true)
                {
                    QuizGameThema2.questionGenerate();
                    variantenCheck.VarianteNotChoosed();

                }
                cScleifeBeendet = false;
            }

            if (planeBool & !cubeBool & !sphereBool & !zylinderBool)
            {
                //plane.SetActive(true);
                outlines[3].enabled = true;
                progressKreis[3].SetActive(true);
                ZeitKreis -= Time.deltaTime;
                progressKreis[3].GetComponent<Image>().fillAmount = ZeitKreis / ZeitBar;
                realeZeit += Time.deltaTime;

                if (realeZeit > 2f)
                {
                    variantenCheck.VarianteChoosed();
                    if (variantenCheck._choosen == true & variantenCheck.Wiederholung == true)
                    {

                        QuizGameThema2.Prüfung(3);
                        variantenCheck.VarianteNotChoosed();
                        dScleifeBeendet = true;
                    }
                }

            }
            if (!planeBool & dScleifeBeendet)
            {
                realeZeit = Startzeit;
                outlines[3].enabled = false;
                ZeitKreis = ZeitBar;
                variantenCheck.VarianteNotChoosed();
                print("Variante muss wieder ausgewählt werden" + variantenCheck._choosen);
                variantenCheck.WiederholungStart();
                print("ist weg");
                if (variantenCheck._choosen == false & variantenCheck.Wiederholung == true & dScleifeBeendet == true)
                {
                    QuizGameThema2.questionGenerate();
                    variantenCheck.VarianteNotChoosed();

                }
                dScleifeBeendet = false;
            }


        }

        else if (quizBool & menue.zündfolgeErkannt&erscheinen.funktionvideogespielt == true)
        {
            print("Menü soll erscheinen Thema 3");
            Menue.SetActive(true);

            //GO_QuizGameThema3.SetActive(true);
            if (!menueaktiv)
            {
                print(" Ich bin in der schleife für die erste frage in der Probe");
                timerQuiz.StartTimer();
                QuizGameThema3.ersteFrage();


            }

            if (cubeBool & !sphereBool & !zylinderBool & !planeBool)
            {

                //cube.SetActive(true);
                outlines[0].enabled = true;
                progressKreis[0].SetActive(true);
                ZeitKreis -= Time.deltaTime;
                progressKreis[0].GetComponent<Image>().fillAmount = ZeitKreis / ZeitBar;
                realeZeit += Time.deltaTime;

                if (realeZeit > 2f)
                {

                    variantenCheck.VarianteChoosed();
                    if (variantenCheck._choosen == true & variantenCheck.Wiederholung == true)
                    {

                        QuizGameThema3.Prüfung(0);
                        variantenCheck.VarianteNotChoosed();
                        aScleifeBeendet = true;
                    }

                    print("Ich muss jetzt in !aBool schleife gehen");

                }


            }
            if (!cubeBool & aScleifeBeendet)
            {
                outlines[0].enabled = false;
                ZeitKreis = ZeitBar;
                realeZeit = Startzeit;
                variantenCheck.VarianteNotChoosed();
                print("Variante muss wieder ausgewählt werden" + variantenCheck._choosen);
                variantenCheck.WiederholungStart();
                print("ist weg");
                if (variantenCheck._choosen == false & variantenCheck.Wiederholung == true & aScleifeBeendet == true)
                {
                    QuizGameThema3.questionGenerate();
                    variantenCheck.VarianteNotChoosed();

                }
                aScleifeBeendet = false;
            }


            if (sphereBool & !cubeBool & !zylinderBool & !planeBool)
            {
                //sphere.SetActive(true);
                outlines[1].enabled = true;
                progressKreis[1].SetActive(true);
                ZeitKreis -= Time.deltaTime;
                progressKreis[1].GetComponent<Image>().fillAmount = ZeitKreis / ZeitBar;
                realeZeit += Time.deltaTime;
                if (realeZeit > 2f)
                {
                    variantenCheck.VarianteChoosed();
                    if (variantenCheck._choosen == true & variantenCheck.Wiederholung == true)
                    {

                        QuizGameThema3.Prüfung(1);
                        variantenCheck.VarianteNotChoosed();
                        bScleifeBeendet = true;
                    }
                    print("Ich muss jetzt in bBool schleife gehen");

                }


            }

            if (!sphereBool & bScleifeBeendet)
            {
                realeZeit = Startzeit;
                outlines[1].enabled = false;
                ZeitKreis = ZeitBar;
                variantenCheck.VarianteNotChoosed();
                print("Variante muss wieder ausgewählt werden" + variantenCheck._choosen);
                variantenCheck.WiederholungStart();
                print("ist weg");
                if (variantenCheck._choosen == false & variantenCheck.Wiederholung == true & bScleifeBeendet == true)
                {
                    QuizGameThema3.questionGenerate();
                    variantenCheck.VarianteNotChoosed();

                }
                bScleifeBeendet = false;
            }


            if (zylinderBool & !cubeBool & !sphereBool & !planeBool)
            {
                //zylinder.SetActive(true);
                outlines[2].enabled = true;
                progressKreis[2].SetActive(true);
                ZeitKreis -= Time.deltaTime;
                progressKreis[2].GetComponent<Image>().fillAmount = ZeitKreis / ZeitBar;
                realeZeit += Time.deltaTime;
                if (realeZeit > 2f)
                {
                    variantenCheck.VarianteChoosed();
                    if (variantenCheck._choosen == true & variantenCheck.Wiederholung == true)
                    {

                        QuizGameThema3.Prüfung(2);
                        variantenCheck.VarianteNotChoosed();
                        cScleifeBeendet = true;
                    }
                    print("Ich muss jetzt in cBool schleife gehen");

                }


            }

            if (!zylinderBool & cScleifeBeendet)
            {
                realeZeit = Startzeit;
                outlines[2].enabled = false;
                ZeitKreis = ZeitBar;
                variantenCheck.VarianteNotChoosed();
                print("Variante muss wieder ausgewählt werden" + variantenCheck._choosen);
                variantenCheck.WiederholungStart();
                print("ist weg");
                if (variantenCheck._choosen == false & variantenCheck.Wiederholung == true & cScleifeBeendet == true)
                {
                    QuizGameThema3.questionGenerate();
                    variantenCheck.VarianteNotChoosed();

                }
                cScleifeBeendet = false;
            }

            if (planeBool & !cubeBool & !sphereBool & !zylinderBool)
            {
               // plane.SetActive(true);
                outlines[3].enabled = true;
                progressKreis[3].SetActive(true);
                ZeitKreis -= Time.deltaTime;
                progressKreis[3].GetComponent<Image>().fillAmount = ZeitKreis / ZeitBar;
                realeZeit += Time.deltaTime;

                if (realeZeit > 2f)
                {
                    variantenCheck.VarianteChoosed();
                    if (variantenCheck._choosen == true & variantenCheck.Wiederholung == true)
                    {

                        QuizGameThema3.Prüfung(3);
                        variantenCheck.VarianteNotChoosed();
                        dScleifeBeendet = true;
                    }
                }

            }
            if (!planeBool & dScleifeBeendet)
            {
                realeZeit = Startzeit;
                outlines[3].enabled = false;
                ZeitKreis = ZeitBar;
                variantenCheck.VarianteNotChoosed();
                print("Variante muss wieder ausgewählt werden" + variantenCheck._choosen);
                variantenCheck.WiederholungStart();
                print("ist weg");
                if (variantenCheck._choosen == false & variantenCheck.Wiederholung == true & dScleifeBeendet == true)
                {
                    QuizGameThema3.questionGenerate();
                    variantenCheck.VarianteNotChoosed();

                }
                dScleifeBeendet = false;
            }


        }
        else
        {
            variantenCheck.VarianteNotChoosed();
            realeZeit = Startzeit;
            Menue.SetActive(false);
            outlines[3].enabled = false;
            outlines[0].enabled = false;
            outlines[1].enabled = false;
            outlines[2].enabled = false;
           /* cube.SetActive(false);
            sphere.SetActive(false);
            zylinder.SetActive(false);
            plane.SetActive(false);*/
        }
    }


}
