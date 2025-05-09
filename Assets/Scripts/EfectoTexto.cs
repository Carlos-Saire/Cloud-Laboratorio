 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EfectoTexto : MonoBehaviour
{
    float Velocidad_Text = 0.05f;
    float Velocidad_textIncial = 0;
    sbyte index=0;
    Text _text;
    bool Comenzar;
    string _Dialogo;
    private void Awake()
    {
        _text = GetComponent<Text>();
    }
    private void Update()
    {
        if (Comenzar == true)
        {
            Velocidad_textIncial += Time.deltaTime;
        }
        if (Comenzar == true&& Velocidad_textIncial >= Velocidad_Text)
        {
            if(index<_Dialogo.Length)
            {
                _text.text += _Dialogo[index];
                Velocidad_textIncial = 0;
                ++index;
            }
            else
            {
                Comenzar = false;
            }
        }
    }
    public void Inprimir(string texto)
    {
        _Dialogo = texto;
        Comenzar = true;
        index = 0;
        _text.text = "";
    }
}
