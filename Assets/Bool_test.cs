using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bool_test : MonoBehaviour
{
    public bool A= true;
    public bool B= true;
    public bool C= false;
    public bool d;
    // Start is called before the first frame update
    void Start()
    {
       Debug.Log(d= (!A || (B && C)) && (A && !C));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
