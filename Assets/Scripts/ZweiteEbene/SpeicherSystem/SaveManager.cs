using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Hosting;

public class SaveManager : MonoBehaviour
{
    private string path;
    private Player _player;
    public KontrolleMenue auswahl_speicherort;

    private void Awake()
    {
        _player = GameObject.FindObjectOfType<Player>();
    }


    public void Save ()
    {
        if (auswahl_speicherort.thema_1== true)
        {
            path = Application.persistentDataPath + "/ZweiteEbene_Thema_1_VPInfo.txt";
            print("Application.dataPath" + Application.dataPath);
            print("gespeichert");
            string jsonString = JsonUtility.ToJson(_player);

            if (!File.Exists(path))
            {

                using (StreamWriter streamWriter = File.CreateText(path))
                {

                    streamWriter.WriteLine(jsonString);
                }
                //var Person = new Player();
                // File.AppendAllText(path, player.myStats.ToString());

            }


            using (StreamWriter streamWriter = File.AppendText(path))
            {

                streamWriter.WriteLine(jsonString);
            }
        }

    
     if (auswahl_speicherort.thema_2== true)
        {
            path = Application.persistentDataPath + "/ZweiteEbene_Thema_2_VPInfo.txt";
            print("Application.dataPath" + Application.dataPath);
    print("gespeichert");
    string jsonString = JsonUtility.ToJson(_player);

            if (!File.Exists(path))
            {

                using (StreamWriter streamWriter = File.CreateText(path))
                {

                    streamWriter.WriteLine(jsonString);
                }
                //var Person = new Player();
                // File.AppendAllText(path, player.myStats.ToString());

            }


            using (StreamWriter streamWriter = File.AppendText(path))
            {

                streamWriter.WriteLine(jsonString);
            }
        }
        if (auswahl_speicherort.thema_3 == true)
        {
            path = Application.persistentDataPath + "/ZweiteEbene_Thema_3_VPInfo.txt";
            print("Application.dataPath" + Application.dataPath);
            print("gespeichert");
            string jsonString = JsonUtility.ToJson(_player);

            if (!File.Exists(path))
            {

                using (StreamWriter streamWriter = File.CreateText(path))
                {

                    streamWriter.WriteLine(jsonString);
                }
                //var Person = new Player();
                // File.AppendAllText(path, player.myStats.ToString());

            }


            using (StreamWriter streamWriter = File.AppendText(path))
            {

                streamWriter.WriteLine(jsonString);
            }
        }

    }

}



