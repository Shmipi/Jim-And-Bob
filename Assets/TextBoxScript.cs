using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxScript : MonoBehaviour
{
    [SerializeField] private Image imageRenderer;

    private float startTime = 0f;
    [SerializeField] private float holdTime = 0.4f;
    private float timer = 0f;

    [SerializeField] private Sprite img1;
    [SerializeField] private Sprite img2;
    [SerializeField] private Sprite img3;

    private bool switchImage;
    private bool timeToSwitch;
    private bool middlePhase;
    private bool middlePhaseTwo;
    private bool finalPhase;

    private void Awake()
    {

        imageRenderer.sprite = img1;
        startTime = Time.time;
        timer = startTime;

        switchImage = false;
        timeToSwitch = true;
        middlePhase = false;
        middlePhaseTwo = false;
        finalPhase = false;

    }

    // Update is called once per frame
    void Update()
    {

        if (switchImage != timeToSwitch)
        {
            timer += Time.deltaTime;

            if (timer > (startTime + holdTime) && switchImage == false)
            {
                switchImage = !switchImage;
                timeToSwitch = !timeToSwitch;
                middlePhase = true;
                startTime = Time.time;
                timer = startTime;
                imageRenderer.sprite = img1;
            }
            else if (timer > (startTime + holdTime) && middlePhase == true)
            {
                middlePhase = false;
                middlePhaseTwo = true;
                startTime = Time.time;
                timer = startTime;
                imageRenderer.sprite = img2;
            }
            else if (timer > (startTime + holdTime) && middlePhaseTwo == true)
            {
                middlePhaseTwo = false;
                finalPhase = true;
                startTime = Time.time;
                timer = startTime;
                imageRenderer.sprite = img1;
            }
            else if (timer > (startTime + holdTime) && finalPhase == true)
            {
                switchImage = !switchImage;
                timeToSwitch = !timeToSwitch;
                finalPhase = false;
                startTime = Time.time;
                timer = startTime;
                imageRenderer.sprite = img3;
            }
        }
    }
}
