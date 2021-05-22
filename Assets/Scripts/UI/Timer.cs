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
	ObtainedPointManager obtainedPointManager;


	public Text ResultPoint;

	void Start()
	{
		obtainedPointManager = GameObject.Find("Point").GetComponent<ObtainedPointManager>();
		PbC.BarValue = 100;
        BattleAudio.Play(); //add
		Destroy(GameObject.Find("StartButton"));

		//obtainedPointManager = GameObject.Find("Point").GetComponent<EnemyCreation>();

	}

	// Update is called once per frame
	void Update()
	{
		//totalTime -= Time.deltaTime;
		//seconds = (int)totalTime;
		//timerText.text = seconds.ToString();
		PbC.BarValue -= Time.deltaTime;

		//タイムアップしたら
        if (PbC.BarValue <= 0)
        {
            //Debug.Log("finish");
            BattleAudio.Stop();//add
            Menu.SetActive(true);
			//結果表示
			ResultPoint.text = obtainedPointManager._ObtainedPoint.ToString();
			//SceneManager.LoadScene(3);
		}

    }
	public void RecoverTIme()
    {
		Debug.Log("barvalue");
		PbC.barValue += 10.0f;
    }

}