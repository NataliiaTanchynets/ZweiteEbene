using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


using UnityEngine.UI;
using System.Runtime.InteropServices;

public class QuizGame : MonoBehaviour
{
   
    public QuestionList[] questions;
    public TextMeshProUGUI qText;
    public TextMeshProUGUI [] answersText;
    public List<object> qList;
    QuestionList currentQ;
    public GameObject[] varianten;
    public TimerQuiz timerQuiz;
    private TimerGesamt timerGesamt;

    public allgemeinVariantenCheck allgemeinvariantencheck;
    public Probe probe;

    //private int index;
    int randQ;
    public Animator[] anim = new Animator[5];
    public TextMeshProUGUI richtigFalsch;
    public GameObject canvas;
    public int richtigeAntwortenCount = 0;

    public void Start()
    {
        qList = new List<object>(questions);

    }
    public void ersteFrage()
    {
          
       // qList = new List<object>(questions);
        questionGenerate();
        probe.menueaktiv = true;
        //probe.menueaktiv = false;
        for (int i =0; i <anim.Length; i++) { 
        if (!anim[i].gameObject.GetComponent<Animator>().enabled) anim[i].gameObject.GetComponent<Animator>().enabled = true;
        else
        {
            anim[i].gameObject.GetComponent<Animator>().SetTrigger("FadeIn");
            }
        }
        
    }


    public void questionGenerate()
    {

        if (qList.Count > 0)
        {
            print("length=" + qList.Count);
            randQ = Random.Range(0, qList.Count);
            currentQ = qList[randQ] as QuestionList;
            qText.text = currentQ.question;
            qText.gameObject.GetComponent<Animator>().SetTrigger("FadeIn");
            List<string> answers = new List<string>(currentQ.answers);


            for (int i = 0; i < currentQ.answers.Length; i++)
            {
                int rand = Random.Range(0, answers.Count);
                answersText[i].text = answers[rand];
                answers.RemoveAt(rand);

            }
            StartCoroutine(GetDelayZeit());
            print("Coroutine ist gestartet");

        }
        else
        {
            print("Sie haben " + richtigeAntwortenCount + " Fragen richtig beantwortet");
            canvas.SetActive(true);
            timerQuiz.StopTimer();
            //timerGesamt.StopTimer();
            timerGesamt = GameObject.Find("TimerInApp").GetComponent<TimerGesamt>();
            timerGesamt.StopTimer();
            MapValuesToPlayer();
            canvas.GetComponentInChildren<TextMeshProUGUI>().text = "Sie haben das Quiz abgeschlossen und " +richtigeAntwortenCount+ " von " +questions.Length+ " Fragen richtig beantwortet.";
           
           
        }
       // probe.menueaktiv = false;

    }
    

    private IEnumerator GetDelayZeit()
    {
        yield return new WaitForSeconds(1.5f);
        //pointer.GetComponent<Collider>().enabled = false;
        // for (int i = 0; i < anim.Length; i++) anim[i].gameObject.GetComponent<Animator>().enabled = false;
        int a = 0;
        while (a < answersText.Length)
        {

            if (!answersText[a].gameObject.GetComponent<Animator>().enabled) answersText[a].gameObject.GetComponent<Animator>().enabled = true;
            else
            {
                answersText[a].gameObject.GetComponent<Animator>().SetTrigger("FadeIn");
                a++;
                //yield return new WaitForSeconds(3);
            }
        }
        // pointer.GetComponent<Collider>().enabled = false;
        // for (int i = 0; i < anim.Length; i++) anim[i].gameObject.GetComponent<Animator>().enabled = false;

        print("3 Sekunden sind vorbei");
        // for (int i = 0; i < currentQ.answers.Length; i++) pointer.GetComponent<Collider>().enabled = false;
       
        yield break;
    }

    public void Prüfung(int index)
    {
        allgemeinvariantencheck.VarianteNotChoosed();
        print("Variante ausgewählt ist muss false sein und ist " + allgemeinvariantencheck._choosen);
        allgemeinvariantencheck.WiederholungStop();
        print("Wiedrholung muss false sein und ist " + allgemeinvariantencheck.Wiederholung);
        if (answersText[index].text.ToString() == currentQ.answers[0])
        {
            richtigeAntwortenCount++;
            print("Richtige Antwort ist gewählt");

            StartCoroutine(trueOrfalse(true));
        }
        else
        {
            print("Falsche Antwort ist gewählt");

            StartCoroutine(trueOrfalse(false));
        }
    }

    private IEnumerator trueOrfalse(bool check)
    {
        if (qList.Count > 0) { 
        //yield return new WaitForSeconds(1);
        for (int i = 0; i < anim.Length; i++) anim[i].gameObject.GetComponent<Animator>().SetTrigger("FadeOut");
        qText.gameObject.GetComponent<Animator>().SetTrigger("FadeOut");
        // pointer.GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(1);
        print("subroutine delete question");
       
        if (check)
        {
            print("Richtige Antwort ist gewählt und geleitet");
            richtigFalsch.text = "Richtige Antwort";
            richtigFalsch.fontSize = 0.6f;
                if (!richtigFalsch.gameObject.GetComponent<Animator>().enabled) richtigFalsch.gameObject.GetComponent<Animator>().enabled = true;
        else
        {
            richtigFalsch.GetComponent<Animator>().SetTrigger("FadeIn");
        }
            qList.RemoveAt(randQ);
            yield return new WaitForSeconds(1.5f);
            richtigFalsch.GetComponent<Animator>().SetTrigger("FadeOut");
            print("Die Prüfung methode funktioniert");
            

            print("Die Frage wurde gelöscht");
           // questionGenerate();
            richtigFalsch.GetComponent<Animator>().SetTrigger("FadeOut");
            // pointer.GetComponent<Collider>().enabled = true;
            // anim[i].gameObject.GetComponent<Animator>().SetTrigger("FadeOut");
            //yield break;
        }
        else
        {
            print("Falsche Antwort ist gewählt und weitergeleitet");
            richtigFalsch.text = "Falsche Antwort \n Richtige Antwort ist " + currentQ.answers[0];
            richtigFalsch.fontSize = 0.4f;
                if (!richtigFalsch.gameObject.GetComponent<Animator>().enabled) richtigFalsch.gameObject.GetComponent<Animator>().enabled = true;
            else
            {
                richtigFalsch.GetComponent<Animator>().SetTrigger("FadeIn");
            }
            qList.RemoveAt(randQ);
            yield return new WaitForSeconds(3f);
            richtigFalsch.GetComponent<Animator>().SetTrigger("FadeOut");
            print("Die Prüfung methode funktioniert");
            

            print("Die Frage wurde gelöscht");
            //questionGenerate();
            //pointer.GetComponent<Collider>().enabled = true;
            // anim[i].gameObject.GetComponent<Animator>().SetTrigger("FadeOut");
            //yield break;
            
        }

    }}
    void MapValuesToPlayer()
    {
        Player player = GameObject.FindObjectOfType<Player>();
        player.myStats.richtigeAntwort = richtigeAntwortenCount;
    }
}
[System.Serializable]
public class QuestionList
{
    public string question;
    public string[] answers = new string[4];
}