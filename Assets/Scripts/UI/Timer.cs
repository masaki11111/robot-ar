using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour {
	public GameObject Menu;
	ProgressBarCircle PbC;
	public AudioSource BattleAudio; // add
	ObtainedPointManager obtainedPointManager;
	EnemyCreation enemyCreation;
    public Text ResultPoint;
	PlayerHit playerHit;
	//public bool HitPlayer;
	public ButtonState StartButton;
	bool startTimer;
	public GameObject Pepper;
	void Start()
	{
		PbC = GameObject.Find("Timer").GetComponent<ProgressBarCircle>();
		obtainedPointManager = GameObject.Find("Point").GetComponent<ObtainedPointManager>();
		enemyCreation = GameObject.Find("EnemyManager").GetComponent<EnemyCreation>();

		playerHit = GameObject.Find("Collider").GetComponent<PlayerHit>();
		PbC.BarValue = 100;
		startTimer = false;
		Pepper = GameObject.Find("Pepper");
	}

	// Update is called once per frame
	void Update()
	{

		if (StartButton.IsDown())
		{
			BattleAudio.Play(); //add
			Destroy(GameObject.Find("StartButton"));
			startTimer = true;
			enemyCreation.CreateEnemyForFirstTime();
		}

		if (startTimer)
        {
			PbC.BarValue -= Time.deltaTime;
		}

		//タイムアップしたら
		if (PbC.BarValue <= 0 || playerHit.HitPlayer)
        {
			FinishGame();
		}

    }

	//時間を回復
	public void RecoverTIme()
    {
		PbC.barValue += 5.0f;
    }

	//時間を回復
	public void FinishGame()
	{
		//Debug.Log("finish");
		BattleAudio.Stop();//add
		Menu.SetActive(true);
		//結果表示
		
		ResultPoint.text = obtainedPointManager._ObtainedPoint.ToString();
		//SceneManager.LoadScene(3);
		//Destroy(Pepper);
		Pepper.SetActive(false);
	}

}