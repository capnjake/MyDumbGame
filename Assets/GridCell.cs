using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCell : MonoBehaviour
{


    public void BuildOnCell(GameObject objectToBuild)
    {
        Instantiate(objectToBuild, transform.position, Quaternion.identity);
    }
}
