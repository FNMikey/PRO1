using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour
{

    public TextMeshProUGUI uitext;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        uitext.text = $"frame: {Time.deltaTime}";


    }


    public void Click1()
    {

        uitext.color = Color.blue ;

    }
}
