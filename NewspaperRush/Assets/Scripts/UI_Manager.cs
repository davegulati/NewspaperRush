using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour {

    public static UI_Manager instance;

    private Slider slider_TimeLimit;

    private float maxTimeLimit;
    private float timeLimit;

    private void Awake()
    {
        instance = this;

        if (GameObject.Find("Canvas").transform.Find("Slider_TimeLimit").GetComponent<Slider>() == null)
        {
            Debug.LogError("No slider found to show time limit. Are you missing the slider gameobject or component?");
        }
        else
        {
            slider_TimeLimit = GameObject.Find("Canvas").transform.Find("Slider_TimeLimit").GetComponent<Slider>();
        }
    }

    // Use this for initialization
    void Start () 
    {
        
	}
	
	// Update is called once per frame
	void Update () 
    {
        timeLimit -= Time.deltaTime;
        UpdateTimeLimitSlider();
	}

    private void UpdateTimeLimitSlider ()
    {
        slider_TimeLimit.value = timeLimit / maxTimeLimit;
    }

    public void SetMaxTimeLimit (float seconds)
    {
        maxTimeLimit = seconds;
        timeLimit = seconds;
    }

    public void ResetTimeLimit ()
    {
        timeLimit = maxTimeLimit;
        UpdateTimeLimitSlider();
    }
}
