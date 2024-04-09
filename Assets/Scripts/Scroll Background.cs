using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBAckground : MonoBehaviour
{
    public float scrollvelocityy = 2;
    public float repeatscale = 4;

    // Update is called once per frame
    void Update()
    {
        float posy= transform.position.y + scrollvelocityy * Time.deltaTime;
        posy = posy % repeatscale;

        transform.position = new Vector3 (0, posy, 0);
    }
}
