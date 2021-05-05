using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{

	//　非同期動作で使用するAsyncOperation
	private AsyncOperation async;
	//　シーンロード中に表示するUI画面
	[SerializeField]
	private GameObject loadUI;
	//　読み込み率を表示するスライダー
	[SerializeField]
	private Slider slider;

	//バトルシーンへの遷移
	public void ToBattle()
	{
		//　ロード画面UIをアクティブにする
		loadUI.SetActive(true);

		//　コルーチンを開始
		StartCoroutine("LoadingBattle");
	}

	IEnumerator LoadingBattle()
	{
		// シーンの読み込みをする
		async = SceneManager.LoadSceneAsync("Battle");

		//　読み込みが終わるまで進捗状況をスライダーの値に反映させる
		while (!async.isDone)
		{
			//Debug.Log("async.progress "+async.progress);
			var progressVal = Mathf.Clamp01(async.progress / 1.0f);
			//Debug.Log("progressVal " + progressVal);
			slider.value = progressVal;
			yield return null;
		}
	}

	//バトルシーンへの遷移
	public void ToLookingCharacter()
	{
		//　ロード画面UIをアクティブにする
		loadUI.SetActive(true);

		//　コルーチンを開始
		StartCoroutine("LoadingLookingCharacter");
	}

	IEnumerator LoadingLookingCharacter()
	{
		// シーンの読み込みをする
		async = SceneManager.LoadSceneAsync("Character");

		//　読み込みが終わるまで進捗状況をスライダーの値に反映させる
		while (!async.isDone)
		{
			//Debug.Log("async.progress "+async.progress);
			var progressVal = Mathf.Clamp01(async.progress / 1.0f);
			//Debug.Log("progressVal " + progressVal);
			slider.value = progressVal;
			yield return null;
		}
	}

    public void ToMenu()
    {
        //　ロード画面UIをアクティブにする
        loadUI.SetActive(true);

        //　コルーチンを開始
        StartCoroutine("LoadingMenu");
    }

    IEnumerator LoadingMenu()
    {
        // シーンの読み込みをする
        async = SceneManager.LoadSceneAsync("Menu");

        //　読み込みが終わるまで進捗状況をスライダーの値に反映させる
        while (!async.isDone)
        {
            //Debug.Log("async.progress "+async.progress);
            var progressVal = Mathf.Clamp01(async.progress / 1.0f);
            //Debug.Log("progressVal " + progressVal);
            slider.value = progressVal;
            yield return null;
        }
    }

}
