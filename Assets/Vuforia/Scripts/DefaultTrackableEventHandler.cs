/*==============================================================================
Copyright (c) 2019 PTC Inc. All Rights Reserved.

Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;
using Vuforia;



/// <summary>
/// A custom handler that implements the ITrackableEventHandler interface.
///
/// Changes made to this file could be overwritten when upgrading the Vuforia version.
/// When implementing custom event handler behavior, consider inheriting from this class instead.
/// </summary>
public class DefaultTrackableEventHandler : MonoBehaviour, ITrackableEventHandler
{

    #region PROTECTED_MEMBER_VARIABLES

    protected TrackableBehaviour mTrackableBehaviour;
    protected TrackableBehaviour.Status m_PreviousStatus;
    protected TrackableBehaviour.Status m_NewStatus;
    //bool pSwitch = true;
    bool pAppearanceAnimationSwitch = false;
    public GameObject pepperPresence;
    ParticleSystem pepperPresenceAnimation;
    //ペッパーが出たときの音
    public AudioSource pepperPresenceAudio;
    public GameObject pepperColor;
    public Material PepperMaterial;
    public GameObject spotLight;
    bool pAppearanceLightSwitch = false;
    //bool pAppearanceSwitch = true;
    //pepperが出たときにマーカーをペッパーがいないのものに差し替える
    //public Texture NormalmapTexture;
    //public Material TargetMaterial;
    public GameObject PostGround;
    #endregion // PROTECTED_MEMBER_VARIABLES

    #region UNITY_MONOBEHAVIOUR_METHODS


    protected virtual void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        Debug.Log("Start");

        //ペッパーを透明にしておく
        pepperColor.SetActive(false);
        PepperMaterial.color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 0f / 255f);

        //ペッパー出現時のライト
        spotLight.GetComponent<Light>().spotAngle = 1;

        //ペッパーがいないマーカーを透明にしておく
        PostGround.GetComponent<SpriteRenderer>().color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 0 / 255f);
        //var childTransform = GameObject.Find("PepperColor").GetComponentsInChildren<Transform>();

        pepperPresenceAnimation = pepperPresence.GetComponent<ParticleSystem>();

    }

    protected virtual void OnDestroy()
    {
        if (mTrackableBehaviour)
            mTrackableBehaviour.UnregisterTrackableEventHandler(this);
        //Debug.Log("OnDestroy()");
    }

    #endregion // UNITY_MONOBEHAVIOUR_METHODS

    #region PUBLIC_METHODS

    /// <summary>
    ///     Implementation of the ITrackableEventHandler function called when the
    ///     tracking state changes.
    /// </summary>
    public void OnTrackableStateChanged(
        TrackableBehaviour.Status previousStatus,
        TrackableBehaviour.Status newStatus)
    {
        m_PreviousStatus = previousStatus;
        m_NewStatus = newStatus;

        Debug.Log("Trackable " + mTrackableBehaviour.TrackableName +
                  " " + mTrackableBehaviour.CurrentStatus +
                  " -- " + mTrackableBehaviour.CurrentStatusInfo);
        Debug.Log("OnTrackableStateChanged");
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            OnTrackingFound();
        }
        else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
                 newStatus == TrackableBehaviour.Status.NO_POSE)
        {
            OnTrackingLost();
        }
        else
        {
            // For combo of previousStatus=UNKNOWN + newStatus=UNKNOWN|NOT_FOUND
            // Vuforia is starting, but tracking has not been lost or found yet
            // Call OnTrackingLost() to hide the augmentations
            OnTrackingLost();
        }
    }

    #endregion // PUBLIC_METHODS

    #region PROTECTED_METHODS

    protected virtual void OnTrackingFound()
    {
        if (mTrackableBehaviour)
        {
            var rendererComponents = mTrackableBehaviour.GetComponentsInChildren<Renderer>(true);
            var colliderComponents = mTrackableBehaviour.GetComponentsInChildren<Collider>(true);
            var canvasComponents = mTrackableBehaviour.GetComponentsInChildren<Canvas>(true);
            Debug.Log("OnTrackingFound()");


           //キラキラカードのエフェクト
           pAppearanceLightSwitch = true;
       
            // Enable rendering:
            foreach (var component in rendererComponents)
                component.enabled = true;

            // Enable colliders:
            foreach (var component in colliderComponents)
                component.enabled = true;

            // Enable canvas':
            foreach (var component in canvasComponents)
                component.enabled = true;
        }
    }


    protected virtual void OnTrackingLost()
    {
        if (mTrackableBehaviour)
        {
            var rendererComponents = mTrackableBehaviour.GetComponentsInChildren<Renderer>(true);
            var colliderComponents = mTrackableBehaviour.GetComponentsInChildren<Collider>(true);
            var canvasComponents = mTrackableBehaviour.GetComponentsInChildren<Canvas>(true);
            Debug.Log("OnTrackingLost()");
            // Disable rendering:
            foreach (var component in rendererComponents)
                component.enabled = false;

            // Disable colliders:
            foreach (var component in colliderComponents)
                component.enabled = false;

            // Disable canvas':
            foreach (var component in canvasComponents)
                component.enabled = false;
        }
    }
    void FixedUpdate()
    {
        if (pAppearanceLightSwitch)
        {
            if (spotLight.GetComponent<Light>().spotAngle < 179)
            {
                spotLight.GetComponent<Light>().spotAngle += 1.0f;
            }
            else
            {
                pAppearanceLightSwitch = false;
                pepperColor.SetActive(true);
                pepperPresenceAnimation.Play();
                pepperPresenceAudio.Play();
                pAppearanceAnimationSwitch = true;
                //pSwitch = false;
            }
        }
        if (pAppearanceAnimationSwitch)
        {
            if (PepperMaterial.color.a < 0.0001)
            {
                PepperMaterial.color += new Color(0 / 255f, 0 / 255f, 0 / 255f, 0.0001f / 255f);
                var childTransform = GameObject.Find("PepperColor").GetComponentsInChildren<Transform>();
                foreach (Transform child in childTransform)
                {
                    if (null != child.GetComponent<SkinnedMeshRenderer>())
                    {
                        Material[] mats = child.GetComponent<Renderer>().materials;
                        mats[0] = PepperMaterial;
                        child.GetComponent<Renderer>().materials = mats;
                    }
                }
            }
            else if (PepperMaterial.color.a >= 0.0001 && PepperMaterial.color.a < 1)
            {
                PepperMaterial.color += new Color(0 / 255f, 0 / 255f, 0 / 255f, 4f / 255f);
                var childTransform = GameObject.Find("PepperColor").GetComponentsInChildren<Transform>();
                foreach (Transform child in childTransform)
                {
                    if (null != child.GetComponent<SkinnedMeshRenderer>())
                    {
                        Material[] mats = child.GetComponent<Renderer>().materials;
                        mats[0] = PepperMaterial;
                        child.GetComponent<Renderer>().materials = mats;
                     }
                }
            }
            if (PostGround.GetComponent<SpriteRenderer>().color.a < 1)
            {
                PostGround.GetComponent<SpriteRenderer>().color += new Color(0 / 255f, 0 / 255f, 0 / 255f, 1f / 255f);

            }


        }




    }

    #endregion // PROTECTED_METHODS
}
