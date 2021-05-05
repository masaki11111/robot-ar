using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Coffee.UIEffects;
using System.Threading;
using UnityEngine.Rendering;//必要
using UnityEngine.Rendering.PostProcessing;
public class PlayerMover : MonoBehaviour
{

    public float speed;
    private Vector3 latestPos;
    //private Collider leftFootCollider;
    public FixedJoystick joystick;
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //joystickを使って移動
        var input = new Vector3(joystick.Horizontal * (-1f), 0f, joystick.Vertical * (-1f)) * speed;
        this.transform.localPosition -= input;

        //向き変更
        Vector3 diff = transform.localPosition - latestPos;   //前回からどこに進んだかをベクトルで取得
        latestPos = transform.localPosition;  //前回のPositionの更新

        //ベクトルの大きさが0.01以上の時に向きを変える処理をする
        //0fにするとコントローラを話した瞬間に前を向く
        if (diff.magnitude > 0.0001f)
        {
            transform.localRotation = Quaternion.LookRotation(diff); //向きを変更する
        }
        //Debug.Log(this.transform.localPosition.magnitude);
    }
}
