using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorDetector : MonoBehaviour
{
    public Transform Pivot;
    private bool m_bIsOpen = false;
    private int m_playersInside = 0;  

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter");
        if (!other.CompareTag("Player"))
            return;

        m_playersInside++;

        if (!m_bIsOpen)
        {
            Pivot.Rotate(new Vector3(0, -90, 0));
            m_bIsOpen = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit");
        if (!other.CompareTag("Player"))
            return;

        m_playersInside--;

        if (m_playersInside == 0 && m_bIsOpen)
        {
            Pivot.rotation = Quaternion.Euler(0, 0, 0);
            m_bIsOpen = false;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
