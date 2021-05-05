using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject Menu;
    // Start is called before the first frame update

    // Update is called once per frame
    //はじめはメニュを出さずに、メニューを表示させるためのボタンを押すと画面が出る

    bool isDisplay = true;
    public void Togglemenu()
    {
        //　メニュを表示する
        Menu.SetActive(isDisplay);
        isDisplay = !isDisplay;
    }
}
