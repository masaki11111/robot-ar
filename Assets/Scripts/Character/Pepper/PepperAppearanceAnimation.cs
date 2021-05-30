using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PepperAppearanceAnimation : MonoBehaviour
{
    bool pAppearanceEmissionSwitch = false;
    bool pAppearanceLightSwitch = false;
    //public GameObject pepperAppearanceEmission;
    //public GameObject pepperAppearanceLight;
    public AudioSource pepperAppearanceAudio;
    //public GameObject pepperColor;
    public Material PepperMaterial;
    //public GameObject PostGround;
    Transform[] childTransform;
    public DefaultTrackableEventHandler defaultTrackableEventHandler;

    public Light pepperAppearanceLight;
    public ParticleSystem pepperAppearanceEmission;
    public SpriteRenderer PostGround;
    // Start is called before the first frame update
    void Start()
    {
        //ペッパーを透明にしておく
        //pepperColor.SetActive(false);
        PepperMaterial.color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 0f / 255f);

        //ペッパー出現時のライトの角度
        pepperAppearanceLight.spotAngle = 1;
        //パーティクル
        //pepperAppearanceEmission = pepperAppearance.GetComponent<ParticleSystem>();

        //ペッパーがいないマーカー（postground）を透明にしておく
        PostGround.GetComponent<SpriteRenderer>().color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 0 / 255f);

        childTransform = GameObject.Find("PepperColor").GetComponentsInChildren<Transform>();

    }

    private void Update()
    {
        //Aを押したときにペッパー出現時のエフェクトをスキップする
        if (Input.GetMouseButtonDown(0))
        {
            pAppearanceLightSwitch = false;
            defaultTrackableEventHandler.startAppearanceAnimation = false;
            pAppearanceEmissionSwitch = false;
            pepperAppearanceEmission.Stop();
            pepperAppearanceAudio.Stop();
            pepperAppearanceLight.spotAngle = 179;
            PepperMaterial.color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 255 / 255f);
            PostGround.color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 255f / 255f);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (defaultTrackableEventHandler.startAppearanceAnimation)
        {
            pAppearanceLightSwitch = true;
            defaultTrackableEventHandler.startAppearanceAnimation = false;
        }

        if (pAppearanceLightSwitch)
        {
            if (pepperAppearanceLight.spotAngle < 179)
            {
                pepperAppearanceLight.spotAngle += 1.0f;
            }
            else
            {
                pAppearanceLightSwitch = false;
                //pepperColor.SetActive(true);
                pepperAppearanceEmission.Play();
                pepperAppearanceAudio.Play();
                pAppearanceEmissionSwitch = true;
                //pSwitch = false;
                Debug.Log("pAppearanceLightSwitch");
            }
        }

        if (pAppearanceEmissionSwitch)
        {
            if (PepperMaterial.color.a < 0.0001)
            {
                PepperMaterial.color += new Color(0 / 255f, 0 / 255f, 0 / 255f, 0.0001f / 255f);
                //var childTransform = GameObject.Find("PepperColor").GetComponentsInChildren<Transform>();
                //foreach (Transform child in childTransform)
                //{
                //    if (null != child.GetComponent<SkinnedMeshRenderer>())
                //    {
                //        child.GetComponent<Renderer>().material.color = PepperMaterial.color;
                //        //Material[] mats = child.GetComponent<Renderer>().materials;
                //        //mats[0] = PepperMaterial;
                //        //child.GetComponent<Renderer>().materials = mats;
                //    }
                //}
            }
            else if (PepperMaterial.color.a >= 0.0001 && PepperMaterial.color.a < 1)
            {
                PepperMaterial.color += new Color(0 / 255f, 0 / 255f, 0 / 255f, 4f / 255f);
                //var childTransform = GameObject.Find("PepperColor").GetComponentsInChildren<Transform>();
                //foreach (Transform child in childTransform)
                //{
                //    if (null != child.GetComponent<SkinnedMeshRenderer>())
                //    {
                //        child.GetComponent<Renderer>().material.color = PepperMaterial.color;

                //        //Material[] mats = child.GetComponent<Renderer>().materials;
                //        //mats[0] = PepperMaterial;
                //        //child.GetComponent<Renderer>().materials = mats;
                //    }
                //}
            }
            if (PostGround.color.a < 1)
            {
                PostGround.color += new Color(0 / 255f, 0 / 255f, 0 / 255f, 1f / 255f);

            }


        }

    }
}
