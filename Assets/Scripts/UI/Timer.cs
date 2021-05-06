using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour {

	//public Text timerText;
	//public float totalTime;
	//int seconds;
	public GameObject Menu;

	public ProgressBarCircle PbC;

	public AudioSource BattleAudio; // add
	EnemyCreation enemyCreation;

	public Text ResultPoint;

	void Start()
	{
        PbC.BarValue = 100;
        BattleAudio.Play(); //add
		Destroy(GameObject.Find("StartButton"));

		enemyCreation = GameObject.Find("EnemyManager").GetComponent<EnemyCreation>();

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
            //Debug.Log("finish");
            BattleAudio.Stop();//add
            Menu.SetActive(true);
			//結果表示
			ResultPoint.text = enemyCreation.EnemyNum.ToString();
			//SceneManager.LoadScene(3);
		}

    }
}