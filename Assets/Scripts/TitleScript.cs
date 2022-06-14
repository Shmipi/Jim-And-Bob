using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleScript : MonoBehaviour
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
    private bool finalPhase;
    private bool backCycle;

    private void Awake()
    {

        imageRenderer.sprite = img1;
        startTime = Time.time;
        timer = startTime;

        switchImage = false;
        timeToSwitch = true;
        middlePhase = false;
        finalPhase = false;
        backCycle = false;

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
            } else if (timer > (startTime + holdTime) && middlePhase == true && backCycle == false)
            {
                middlePhase = false;
                finalPhase = true;
                startTime = Time.time;
                timer = startTime;
            } else if (timer > (startTime + holdTime) && finalPhase == true && backCycle == false)
            {
                switchImage = !switchImage;
                timeToSwitch = !timeToSwitch;
                finalPhase = false;
                startTime = Time.time;
                timer = startTime;
                backCycle = !backCycle;
            }
        }

        if (backCycle == false)
        {
            if (!switchImage)
            {
                imageRenderer.sprite = img1;
            }
            else if (middlePhase == true)
            {
                imageRenderer.sprite = img2;
            }
            else if (finalPhase == true)
            {
                imageRenderer.sprite = img1;
            }
        } else if (backCycle == true)
        {
            if (!switchImage)
            {
                imageRenderer.sprite = img3;
            }
            else if (middlePhase == true)
            {
                switchImage = !switchImage;
                timeToSwitch = !timeToSwitch;
                middlePhase = false;
                startTime = Time.time;
                timer = startTime;
                backCycle = !backCycle;
            }
        }

    }
}
