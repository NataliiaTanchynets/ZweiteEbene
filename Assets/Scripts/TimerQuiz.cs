using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerQuiz: MonoBehaviour
{
       public static float startTime;

       public static bool keepTiming;
       public static float timer;
        public static float t;
        public static string platzhalterQuizZeit;

        void Start()
        {
           
        }
    

        void UpdateTime()
        {
         
            
        }

       public void StopTimer()
        {
            keepTiming = false;
        TimeToString();
        Debug.Log("Die Zeit für die Quizbearbeitung beträgt  " + platzhalterQuizZeit);
          
        }

       public  void ResumeTimer()
        {
            keepTiming = true;
            startTime = Time.time - timer;
        }

       public void StartTimer()
        {
            keepTiming = true;
            startTime = Time.time;
        }

       public void TimeToString()
        {   
            t= Time.time - startTime;
            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f0");
            platzhalterQuizZeit = minutes + ":" + seconds;
        MapValuesToPlayer();
        }
    void MapValuesToPlayer()
    {
        Player player = GameObject.FindObjectOfType<Player>();
        player.myStats.zeitQuiz = platzhalterQuizZeit;
    }
}

