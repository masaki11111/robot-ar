using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class sample_1 : MonoBehaviour
{
    GameObject Earth;
    float EarthLength;

    BoxCollider EarthCollider;


    public float minimum = 10.0F;
    public float maximum = 20.0F;
    public float duration = 5.0F;
    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        Earth = GameObject.Find("Sphere");
        EarthCollider = Earth.GetComponent<BoxCollider>();
        EarthLength = 0f;
        Sample();
    }

    // Update is called once per frame
    private void Update()
    {
        //Vector3 position = transform.position;

        ////position.xから10まで、0.1秒で進む。ただし最大速度はmaxSpeed。
        ////現在の速度はcurrentVelocity、前回呼び出された時からの経過時間はTime.deltaTime
        ////maxSpeedとtime.deletatimeは無くてもok
        //float currentVelocity = 0, smoothTime = 0.1f, maxSpeed = 100;
        //position.x = Mathf.SmoothDamp(position.x, 10, ref currentVelocity, smoothTime, maxSpeed, Time.deltaTime);

        //transform.position = position;
    }
    private void Sample()
    {
        Vector3 localscale = transform.localScale;

        ////position.xから10まで、0.1秒で進む。ただし最大速度はmaxSpeed。
        ////現在の速度はcurrentVelocity、前回呼び出された時からの経過時間はTime.deltaTime
        ////maxSpeedとtime.deletatimeは無くてもok
        float currentVelocity = 0, smoothTime = 0.1f, maxSpeed = 100;
        localscale.x = Mathf.SmoothDamp(localscale.x, 10, ref currentVelocity, smoothTime, maxSpeed, Time.deltaTime);

        //transform.localScdale = localscale;

        Debug.Log(Time.time);
        Debug.Log(startTime);

        float t = (Time.time - startTime) / duration;
        //transform.position = new Vector3(Mathf.SmoothStep(minimum, maximum, t), 0, 0);


        //float currentVelocity = 0, smoothTime = 0.5f, maxSpeed = 100;
        ////EarthCollider.size = new Vector3(Mathf.SmoothDamp(0, 10, ref currentVelocity, smoothTime, maxSpeed, Time.deltaTime),10, Mathf.SmoothDamp(0, 10, ref currentVelocity, smoothTime, maxSpeed, Time.deltaTime));
        //position.x = Mathf.SmoothDamp(0, 10, ref currentVelocity, smoothTime, maxSpeed, Time.deltaTime);
        //Debug.Log(position.x);
        EarthCollider.size = new Vector3(Mathf.SmoothStep(minimum, maximum, t), 0, 0);



    }

}

