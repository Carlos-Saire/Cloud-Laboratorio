using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TimerControl : MonoBehaviour
{
    public CambioScene CambioScene;
    Text _text;
    float _time=100;
    float Min;
    float Seg;
    bool _confir=true;
    private void Awake()
    {
        _text = GetComponent<Text>();
    }
    private void Update()
    {
        if (_confir == true)
        {
            _time -=Time.deltaTime;
            if(_time <= 0)
            {
                _time = 0;
                CambioScene.LoadScene("Lomo Saltado Fail");
            }
        }
        PrintTiempo();
    }
    void Comenzar(float Timer)
    {
        _time = Timer;
        _confir = true;
    }
    void PrintTiempo()
    {
        Min = Mathf.Floor(_time / 60);
        Seg = Mathf.Floor(_time % 60);
        _text.text =string.Format("0{0}:{1}",Min,Seg);
    }
}
