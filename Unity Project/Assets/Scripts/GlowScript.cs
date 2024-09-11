using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class GlowScript : MonoBehaviour
{
    private GameObject ball;
    private PostProcessVolume postProcessVolume;
    private GameObject cameraGameObject;
    private PostProcessProfile postProcessProfile;
    private Color color;
    private Bloom bloom;
    private float time;
    private float delay = 0.2f;

    //Deze script hoef je niet met de hand op het gameobject slepen
    [RuntimeInitializeOnLoadMethod]
    static void OnGameStart()
    {
        StartGameText gameControllerObject = FindFirstObjectByType<StartGameText>();
        gameControllerObject.gameObject.AddComponent<GlowScript>();
    }
    void Start()
    {
        BallMovement ballMovementScript = FindFirstObjectByType<BallMovement>();
        if (ballMovementScript == null)
        {
            return;
        }
        ball = ballMovementScript.gameObject;
        int postProcessLayer = LayerMask.NameToLayer("UI"); 
        ball.layer = postProcessLayer; 
        postProcessVolume = ball.AddComponent<PostProcessVolume>(); 
        postProcessProfile = ScriptableObject.CreateInstance<PostProcessProfile>(); 
        postProcessVolume.profile = postProcessProfile;
        bloom = postProcessProfile.AddSettings<Bloom>(); 
        bloom.intensity.Override(20f);
        bloom.threshold.Override(1f);
        bloom.color.Override(Color.red);
        postProcessVolume.isGlobal = true;

    }

    private void Update()
    {
        GenerateNewGlowColor();
    }

    private void GenerateNewGlowColor()
    {

        if (Time.time >= time + delay)
        {
            RandomizeColor();
            time = Time.time;
        }
    }
    private void RandomizeColor()
    {
        byte r = (byte)Random.Range(1, 255);
        byte g = (byte)Random.Range(1, 255);
        byte b = (byte)Random.Range(1, 255);
        byte c = (byte)Random.Range(1, 255);
        color = new Color32(r, g, b,c);
        bloom.color.value = color;
    }
}
