
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class _Timer : MonoBehaviour
{
	public Text timerText;
	public float totalTime;
	int seconds;
	public GameObject Finish;

	public AudioSource BattleAudio; // add
	//public AudioSource GunAudio; 
									// Use this for initialization
	void Start()
	{
		BattleAudio.Play(); //add
	}

	// Update is called once per frame
	void Update()
	{
		totalTime -= Time.deltaTime;
		seconds = (int)totalTime;
		timerText.text = seconds.ToString();

        if (seconds <= 0)
        {
			Debug.Log("finish");
			BattleAudio.Stop();//add
			Finish.SetActive(true);
			//SceneManager.LoadScene(3);
		}

	}
}