using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeKeeper : MonoBehaviour
{
    public TextMeshProUGUI text;


    private float time;

    private void Start()
    {
        time = 0;
    }
    // Update is called once per frame
    void Update ()
    {
        time += Time.deltaTime;
        text.text = "Time: " + time;
	}

    public float GetTime()
    {
        return time;
    }

}
