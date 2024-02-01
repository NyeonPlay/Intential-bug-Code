using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movecaam : MonoBehaviour
{
    public Transform Camra_Pos;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Camra_Pos.position;

    }
}
