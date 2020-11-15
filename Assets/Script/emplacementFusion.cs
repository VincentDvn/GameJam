using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emplacementFusion : MonoBehaviour
{
    private GameObject objectARetourner;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.CompareTag("carte"))
        {
            objectARetourner = coll.gameObject;
        }
    }
    void OnTriggerExit2D(Collider2D coll)
    {
        if(coll.gameObject.CompareTag("carte"))
        {
            objectARetourner = null;
        }
    }

    public GameObject carteStationnee()
    {
    
        return objectARetourner;
        
    }

    public bool cartePlacee()
    {
        if(objectARetourner == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public bool Equals(DragAndDropController obj)
    {
        if(obj == null)
        {
            return false;
        }
        if(objectARetourner == obj.gamePrefab)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
}
