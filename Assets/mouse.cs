using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class mouse : MonoBehaviour
{
   
      private Ray m_Ray;
    private RaycastHit m_RayCastHit;
   private MovableObject m_CurrentTouchableObject;

    void Update()
    {
        if (Input.touches.Length == 1)
        {
            Debug.Log(" you clicked on k");
            Touch touchedFinger = Input.touches[0];

            switch (touchedFinger.phase)
            {
                case TouchPhase.Ended:
                    m_Ray = Camera.main.ScreenPointToRay(touchedFinger.position);
                    if (Physics.Raycast(m_Ray.origin, m_Ray.direction, out m_RayCastHit, Mathf.Infinity))
                    {
                        TouchableObject touchableObj = m_RayCastHit.collider.gameObject.GetComponent<TouchableObject>();
                        if (touchableObj)
                        {
                            m_CurrentTouchableObject = touchableObj;
                            Debug.Log(" you clicked on ");
                        }
                        else //nothing is selected
                        {
                            Debug.Log(" you clicked on 2");
                            if (m_CurrentTouchableObject)
                            {
                                m_CurrentTouchableObject = null;
                                Debug.Log(" you clicked on 3");
                                // reset the text back... 
                            }
                        }

                    }
                    break;
                default:
                    break;
            }
        }
    }
}

