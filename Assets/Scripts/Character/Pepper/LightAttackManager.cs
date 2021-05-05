using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine
//名前空間が以下だった
using Coffee.UIEffects;
using System.Threading;
//using System.Threading.Task;
using UnityEngine.Rendering;//必要
//using UnityEngine.Rendering.Universal//必要;
using UnityEngine.Rendering.PostProcessing;
public class LightAttackManager : MonoBehaviour
{
    //炎
    public ButtonState buttonA;
    GameObject Flame;
    ParticleSystem FlameThrower;
    BoxCollider FlameCollider;
    //private bool FlameTrigger= false;
    float FlameLength;
    float FlamePosition;
    public AudioSource FlameAudio;


    // Start is called before the first frame update
    void Start()
    {
        //炎取得
        Flame = GameObject.Find("FlameThrower");
        FlameThrower = Flame.GetComponent<ParticleSystem>();
        FlameCollider = Flame.GetComponent<BoxCollider>();
        FlameCollider.enabled = false;
        Flame.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        //炎
        if (buttonA.IsDown())
        {
            Flame.SetActive(true);
            //FlameCollider.enabled = true;
            FlameThrower.Play();
            FlameAudio.Play();
            //FlameTrigger = true;
            //FlameCollider.enabled = true;
            //Flamelength = 0.0f;
        }
        else if (buttonA.IsUp())
        {
            FlameThrower.Stop();
            FlameAudio.Stop();
            //FlameTrigger = false;
            FlameLength = 0.0f;
            FlamePosition = 0.0f;
            //FlameCollider.enabled = false;
            Flame.SetActive(false);
        }
        //FlameCollider.size.z = speed;
        if (Flame.activeSelf == true)
        {
            if (FlameLength < 80)
            {
                FlameLength += 3f;
                FlamePosition += 1.87f;
            }
        }
        FlameCollider.size = new Vector3(20, 24, FlameLength);
        FlameCollider.center = new Vector3(0, -12, FlamePosition);

    }
}
