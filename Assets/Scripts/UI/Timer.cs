using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

	//public Text timerText;
	//public float totalTime;
	//int seconds;
	public GameObject Menu;

	public ProgressBarCircle PbC;

	public AudioSource BattleAudio; // add
									//public AudioSource GunAudio; 
									// Use this for initialization
	void Start()
	{
        PbC.BarValue = 100;
        BattleAudio.Play(); //add
		Destroy(GameObject.Find("StartButton"));

	}

	// Update is called once per frame
	void Update()
	{
		//totalTime -= Time.deltaTime;
		//seconds = (int)totalTime;
		//timerText.text = seconds.ToString();
		PbC.BarValue -= Time.deltaTime;

        if (PbC.BarValue <= 0)
        {
            Debug.Log("finish");
            BattleAudio.Stop();//add
            Menu.SetActive(true);
            //SceneManager.LoadScene(3);
        }

    }
}