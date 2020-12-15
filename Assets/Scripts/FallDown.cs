using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDown : Movement
{

    // Update is called once per frame
    void Update()
    {
        
        if (gameObject.GetComponent<Movement>().isActiveAndEnabled == false)
        {
            foreach (Transform children in transform)
            {
                int roundedX = Mathf.RoundToInt(children.transform.position.x);
                int roundedY = Mathf.RoundToInt(children.transform.position.y);
                grid[roundedX, roundedY] = null;
            }
            transform.position += new Vector3(0, -1, 0);
            Debug.Log("go go");
            if (!ValidMove())
            {
                transform.position -= new Vector3(0, -1, 0);
                AddToGrid();
            }
        }

    }

    /*bool CheckVertical()
    {
        int sum = 0;
        foreach (Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);
            sum += roundedY;
        }
        if (sum % 2 == 0) return false;
        return true;
    }

    void CheckBelow()
    {
        if(CheckVertical())
        {
            int minYPosition = 1000000;
            foreach (Transform children in transform)
            {
                int roundedX = Mathf.RoundToInt(children.transform.position.x);
                int roundedY = Mathf.RoundToInt(children.transform.position.y);
                minYPosition = roundedY < minYPosition ? roundedY : minYPosition;
            }
        }
    }*/
}
