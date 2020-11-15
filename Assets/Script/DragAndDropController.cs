using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDropController : MonoBehaviour
{

    private Vector3 screenPoint;
    private Vector3 initialPos;
    private Vector3 offset;

    private bool canDrop = false;
    private SpriteRenderer render;
    private GameObject plateformeASupr;

    public string nomCarte;

    private Vector3 curPosition;

    public GameObject gamePrefab;
    private bool fusion = false;

    void Start()
    {
        render = GetComponent<SpriteRenderer>();
    }

    public void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position); 

        initialPos = gameObject.transform.position;
        offset = initialPos - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));


    }

    public void OnMouseDrag()
    {
        Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        curPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + offset;

        transform.position = curPosition;
    }

    void OnMouseUp()
    {
        if(!canDrop)
        {
            transform.position = initialPos;
        }
        if(canDrop)
        {
            if(!fusion)
            {
                Instantiate(gamePrefab, transform.position, transform.rotation);
                Destroy(gameObject);           
                Destroy(plateformeASupr);
            }
            else
            {
                transform.position = curPosition;
            }
            
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.CompareTag("emplacementCarte"))
        {
            canDrop = true;
            render.color = Color.green;
            plateformeASupr = coll.gameObject;
            
        } 
        if(coll.gameObject.CompareTag("emplacementFusion"))
        {
            canDrop = true;
            render.color = Color.green;
            plateformeASupr = null;
            fusion = true;
        } 
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if(coll.gameObject.CompareTag("emplacementCarte"))
        {
            canDrop = false;
            render.color = Color.yellow;
        }
        if(coll.gameObject.CompareTag("emplacementFusion"))
        {
            canDrop = false;
            render.color = Color.black;
            plateformeASupr = null;
            fusion = false;
        }
        
    }

}
