using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    private bool isDragging = false;
    private bool isOverDropZone = false;
    private GameObject dropZone;
    private Vector2 startPosition;
  
    // Update is called once per frame
    void Update()
    {
        if (isDragging)
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            //transform.parent.rotation = Quaternion.identity;
            //transform.rotation = Quaternion.identity;

        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //GetComponent<Rigidbody2D> ().Rigidbody2D.angularVelocity = 0;
        isOverDropZone = true;
        //transform.rotation = Quaternion.identity;
        //transform.parent.Rigidbody2D.angularVelocity = 0;
        //transform.parent.rotation = Quaternion.identity;
        dropZone = collision.gameObject;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isOverDropZone = false;
        dropZone = null;
    }

    public void StartDrag()
    {
        startPosition = transform.position;
        isDragging = true;
    }

    public void FinishDrag()
    {
        isDragging = false;
        //transform.rotation = Quaternion.identity;
        if(isOverDropZone)
        {
            Globals.score++;
            Globals.currentCycleIterations = 1;
            Globals.currentCycleSequence = new int[5000];
            transform.SetParent(dropZone.transform, false);
            transform.hasChanged = false;
        } 
        else
        {
            transform.position = startPosition;
        }
    }
}
