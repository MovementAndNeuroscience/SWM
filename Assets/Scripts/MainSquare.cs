using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainSquare : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject Square_Back;
    [SerializeField] private GameObject Square_Yellow;

    public Vector3 position;
    public float posY;

    public void OnPointerClick(PointerEventData eventData)
    {
        Globals.iterations++;
        Globals.currentCycleIterations++;
        int identity = transform.GetInstanceID();
        Globals.clickSequence[Globals.iterations] = identity;
        Globals.currentCycleSequence[Globals.currentCycleIterations] = identity;
        if(Square_Back.activeSelf)
        {
            Square_Back.SetActive(false);
            StartCoroutine(ShortPause());
        }

        //Move object if red cicle is active
        if(Square_Yellow.activeSelf){
            move();
        }
        // If yellow square has been moved -> register all subsequent clicks/touches as errors
        if(transform.childCount == 1) 
        //|| Globals.clickSequence[Globals.iterations] == Globals.clickSequence[Globals.iterations-1])
        {
            Globals.errors++;
            Globals.errorsA++;
        }        

        for (int i = Globals.currentCycleIterations; i > 0; i--)
        {
                if (identity == Globals.currentCycleSequence[i-1] && transform.childCount > 1)
                { 
                    Globals.errors++;
                    Globals.errorsB++;
                    break;
                }
        }
         //Debug.Log("Sequece: " + Globals.clickSequence);
         //Debug.Log("TransformID: " + transform.GetInstanceID());
         //Debug.Log("Identity: " + identity);

    }

     void move ()
     {
        Globals.moveFlag = true;        
        /*float shipSpeed = 7.0f;
        float totalSpeed = shipSpeed * Time.deltaTime;
        Square_Yellow.transform.Translate(Vector3.down * totalSpeed);*/
        //Square_Yellow.transform.SetParent(dropZone.transform, false);
     }

  	private IEnumerator ShortPause()
    {
        /*if (Square_Yellow.activeSelf){
            yield return new WaitUntil(() => !Square_Back.transform.hasChanged);
            Square_Back.SetActive(true);
        }
        else
        {*/
            yield return new WaitForSeconds(1.5f);
            Square_Back.SetActive(true);
        //}
    }
}
