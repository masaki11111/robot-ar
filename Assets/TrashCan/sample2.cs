using UnityEngine;
using System.Collections;

public class sample2 : MonoBehaviour
{
    public float minimum = 10.0F;
    public float maximum = 20.0F;
    public float duration = 5.0F;
    private float startTime;
    void Start()
    {
        startTime = Time.time;
    }
    void Update()
    {
        SA();
    }
    private void SA()
    {
        
        float t = (Time.time - startTime) / duration;
        transform.position = new Vector3(Mathf.SmoothStep(minimum, maximum, t), 0, 0);


    }
}