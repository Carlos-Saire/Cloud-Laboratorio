using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GenerarIngredientes : MonoBehaviour
{
    public GameObject Ingrediente;
    private void OnMouseDown()
    {
        Instantiate(Ingrediente,transform.position,transform.rotation);
    }
    public void AddIngredinete(GameObject ingrediente)
    {
        Ingrediente = ingrediente;
    }
}
