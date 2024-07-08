using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodByeDeleteScript : MonoBehaviour
{

    private float deleteTime = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, deleteTime);
    }

    // Update is called once per frame
    void Update()
    {

    }
}