using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emplado : MonoBehaviour
{
    public string[] names;
    public string[] Name {  get { return names; } set { names = value; } }
    bool confirmar=false;
    public bool Confirmar { get {return confirmar;} set { confirmar = value;} }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        confirmar =this != collision;
    }
    public static bool operator ==(Emplado a, Collider2D b)
    {
        for (int i = 0; i < a.Name.Length; i++)
        {
            if (a.Name[i] == b.gameObject.tag)
            {
                return true;
            }
        }
        return false;
    }

    public static bool operator !=(Emplado a, Collider2D b)
    {
        for (int i = 0; i < a.Name.Length; i++)
        {
            if (a.Name[i] == b.gameObject.tag)
            {
                return true;
            }
        }
        Destroy(b.gameObject);
        return false;
    }
}
