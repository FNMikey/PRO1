using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject target;
    public GameObject bullet;
    float range= 0.2f;
    float timeFired = 0;
    public float frequency = 0.2f;

    IEnumerator Fade()
    {
        Color c = GetComponent<Renderer>().material.color;
        for (float alpha = 1f; alpha >= 0; alpha -= 0.1f)
        {
            c.a = alpha;
            GetComponent<Renderer>().material.color = c;
            yield return new WaitForSeconds(0.1f);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
      
        StartCoroutine(Fade());

    }

    // Update is called once per frame
    void Update()
    {
        var amount = 88f * Time.deltaTime;
        transform.Rotate(new Vector3(0f, 0f, amount));


        var targetVector = (target.transform.position - transform.position).normalized;
        var dot = Vector3.Dot(targetVector, transform.up);
        if (dot > 1f - range && dot < 1f + range) 
        {

            if (Time.time - timeFired > frequency) 
            {
                timeFired = Time.time;
                var obj = Instantiate(bullet, transform.position, transform.rotation);
                obj.GetComponent<Rigidbody2D>().velocity = targetVector * 5f;


                Debug.Log(dot);
            }

            

        }
        



    }
}
