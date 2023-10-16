using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed;
    public int count;
    public Color mycolor;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        mycolor = Color.magenta;
    }

    // Update is called once per frame
    void Update()
    {

        var x = Input.GetAxis("Horizontal") * speed;
        var y = Input.GetAxis("Vertical") * speed;

        var rb = GetComponent<Rigidbody2D>();
        if (rb != null) { 
        
        rb.velocity = new Vector2(x, y);

        }



        GetComponent<Renderer>().material.color = mycolor;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var obj = collision.gameObject;
        count++;
        Destroy(obj);

        mycolor = new Color(Random.value * count,Random.value* count,Random.value * count);
    }
}
