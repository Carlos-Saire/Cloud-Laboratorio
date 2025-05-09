using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredientes : MonoBehaviour
{
    public bool mause=true;
    public bool plato;
    public TablaControl Tabla;
    private AudioSource _componetAudioSource;
    
	
     private void Update()
    {
        if (mause==true)
        {
            transform.position = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        plato = true;
        Tabla=collision.GetComponent<TablaControl>();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        plato=false;
        Tabla = null;
    }
    private void OnMouseDown()
    {
        if (plato==true)
        {
            if (Tabla != null)
            {

                mause = false;
                transform.position = Tabla.transform.position;
                Tabla.Guardar(this.gameObject);
            }
            else
            {

                Destroy(this.gameObject);
            }
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
