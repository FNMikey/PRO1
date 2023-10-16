using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    private SpriteRenderer sr;


    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sr != null)
        {
            var col = sr.color;
            var value = 0.1f * Time.deltaTime;
            sr.color = new Color(col.r, col.g - value, col.b);
        }
        else {
            Debug.Log("null");
        }
    }
}
