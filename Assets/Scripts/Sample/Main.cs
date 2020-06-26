using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// メイン
public class Main : MonoBehaviour
{
    public FixedJoystick joystick;
    public ButtonState buttonA;
    public ButtonState buttonB;

    // 更新時に呼ばれる
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    this.transform.position += new Vector3(0, 0.1f, 0);
        //}

        this.transform.position += new Vector3(joystick.Horizontal * 0.005f, joystick.Vertical * 0.005f, 0);
        // ボタンの状態表示
        //print("ButtonA Pressed: " + buttonA.IsPressed());
        //print("ButtonB Pressed: " + buttonB.IsPressed());
        //print("ButtonA Down: " + buttonA.IsDown());
        //print("ButtonB Down: " + buttonB.IsDown());
        //print("ButtonA Up: " + buttonA.IsUp());
        //print("ButtonB Up: " + buttonB.IsUp());
    }
}