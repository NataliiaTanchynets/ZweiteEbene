using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class allgemeinVariantenCheck : MonoBehaviour
{
    public bool Wiederholung = true;
    public bool _choosen=false;

    public void WiederholungStop ()
    {
        Wiederholung = false;
    }

    public void WiederholungStart()
    {
        Wiederholung = true;
      
    }

    public void VarianteChoosed()
    {

           _choosen = true;
}
    public void VarianteNotChoosed()
    {

        _choosen = false;
    }

}
