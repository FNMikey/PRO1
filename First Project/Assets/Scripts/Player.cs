using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public float speed;
    public int count;
    public int health;
    public GameObject coin;

    IEnumerator Fade()
    {
        Color c = GetComponent<Renderer>().material.color;
        for (float alpha = 1f; alpha >= 0; alpha -= 0.1f)
        {
            c.a = alpha;
            GetComponent<Renderer>().material.color = c;
            yield return new WaitForSeconds(0.1f);
            Debug.Log("Coroutine" + GetComponent<Renderer>().material.color.a);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Fade());
        count = 0;
        health = 3;
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

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var obj = collision.gameObject;
        
       //Debug.Log(obj.tag);
        if (obj.tag == "Coin") {
            count++;
            Destroy(obj);

            if (count == 5) {
                GetComponent<Renderer>().material.color = new Color(Random.value * count, Random.value * count, Random.value * count);
            }
        }


        if (obj.tag == "Enemy") {

            health--;

            if (health == 0) {

                Destroy(gameObject);
            }
        
        }

    }
}
