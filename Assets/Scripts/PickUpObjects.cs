using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObjects : MonoBehaviour
{
    public bool CanPickUp = false;
    public GameObject objectSet;
    public GameObject objectPickUp;
    public bool PickUp=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (objectSet==null)
        {
            if (Input.GetKeyDown(KeyCode.E) && objectPickUp!=null)
            {
                objectSet = objectPickUp;
                Rigidbody2D _rbObject = objectSet.GetComponent<Rigidbody2D>();
                _rbObject.isKinematic = true;
                objectSet.GetComponent<BoxCollider2D>().isTrigger=true;
                objectSet.transform.SetParent(transform);
                PickUp = true;
            }
        }else if (objectSet != null)
        {
            if (Input.GetKeyDown(KeyCode.E)) 
            {
                PickUp = false;
                objectSet.transform.SetParent(null);
                Rigidbody2D _rbObject = objectSet.GetComponent<Rigidbody2D>();
                _rbObject.isKinematic = false;
                objectSet.GetComponent<BoxCollider2D>().isTrigger = false;
                objectSet = null;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ObjectsPickUp")
        {
            if (PickUp == false) 
            {
                CanPickUp = true;
                objectPickUp = collision.gameObject;
            }

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ObjectsPickUp")
        {
            CanPickUp = false;
            objectPickUp = null;
        }
    }
}
