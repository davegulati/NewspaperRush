using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start () 
    {
        SetMaxTimeLimit(5.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ResetTimeLimit ()
    {
        UI_Manager.instance.ResetTimeLimit();
    }

    public void SetMaxTimeLimit (float seconds)
    {
        UI_Manager.instance.SetMaxTimeLimit(seconds);
    }
}
