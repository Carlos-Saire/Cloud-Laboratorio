using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CounterController : MonoBehaviour
{
    TMP_Text _text;
    float _time = 0;
    float Min;
    float Seg;
    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }
    private void Update()
    {
        _time += Time.deltaTime;
        PrintTiempo();
    }
    private void PrintTiempo()
    {
        Min = Mathf.Floor(_time / 60);
        Seg = Mathf.Floor(_time % 60);
        _text.text = Counter();
    }
    public string Counter()
    {
        return string.Format("0{0}:{1}", Min, Seg);
    }
}
