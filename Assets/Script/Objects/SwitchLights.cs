using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLights : MonoBehaviour
{
    public GameObject light1;
    public GameObject FlashlightModel;
    public GameObject keyModel;
    public GameObject paperModel;
    public GameObject missionPaperModel;
    public GameObject storyLetterModel;
    public GameObject toolModel;
    public GameObject tool02Model;
    public GameObject KeyModel01;
    public GameObject KeyModel02;

    private bool isFlashlightOn = false; 
    private bool isKeyOn = false;        
    public bool hasKey = false;
    private bool isPaperOn = false;
    private bool isMissionPaperOn = false;
    private bool isStoryLetterOn = false;
    private bool isToolOn = false;
    private bool isTool02On = false;
    private bool isKey01On = false;
    private bool isKey02On = false;

    void Start()
    {
        light1.SetActive(false);
        FlashlightModel.SetActive(false);
        keyModel.SetActive(false);
        paperModel.SetActive(false);
        missionPaperModel.SetActive(false);
        storyLetterModel.SetActive(false);
        toolModel.SetActive(false);
        tool02Model.SetActive(false);
        KeyModel01.SetActive(false);
        KeyModel02.SetActive(false);
    }

    void Update()
    {

        // FLASHLIGHT TOGGLE
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            isFlashlightOn = !isFlashlightOn;

            light1.SetActive(isFlashlightOn);
            FlashlightModel.SetActive(isFlashlightOn);

            // turn off key if flashlight is on
            if (isFlashlightOn)
            {
                keyModel.SetActive(false);
                paperModel.SetActive(false);
                missionPaperModel.SetActive(false);
                storyLetterModel.SetActive(false);
                tool02Model.SetActive(false);
                KeyModel01.SetActive(false);
                KeyModel02.SetActive(false);

                isTool02On = false;
                isKey01On = false;
                isKey02On = false;
                isStoryLetterOn = false;
                isMissionPaperOn = false;
                isKeyOn = false;
                isPaperOn = false;
            }
        }

        // KEY TOGGLE
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (hasKey)
            {
                isKeyOn = !isKeyOn;

                keyModel.SetActive(isKeyOn);

                // turn off flashlight if key is on
                if (isKeyOn)
                {
                    light1.SetActive(false);
                    FlashlightModel.SetActive(false);
                    paperModel.SetActive(false);
                    missionPaperModel.SetActive(false);
                    storyLetterModel.SetActive(false);
                    tool02Model.SetActive(false);
                    KeyModel01.SetActive(false);
                    KeyModel02.SetActive(false);

                    isTool02On = false;
                    isKey01On = false;
                    isKey02On = false;
                    isStoryLetterOn = false;
                    isMissionPaperOn = false;
                    isFlashlightOn = false;
                    isPaperOn = false;
                }
            }
            else
            {
                Debug.Log("You don't have the key!");
            }
        }

        // PAPER TOGGLE (like flashlight)
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            isPaperOn = !isPaperOn;

            paperModel.SetActive(isPaperOn);

            // turn off others if paper is on
            if (isPaperOn)
            {
                light1.SetActive(false);
                FlashlightModel.SetActive(false);
                keyModel.SetActive(false);
                missionPaperModel.SetActive(false);
                storyLetterModel.SetActive(false);
                tool02Model.SetActive(false);
                KeyModel01.SetActive(false);
                KeyModel02.SetActive(false);

                isTool02On = false;
                isKey01On = false;
                isKey02On = false;
                isStoryLetterOn = false;
                isMissionPaperOn = false;
                isFlashlightOn = false;
                isKeyOn = false;
            }
        }

        // MISSION PAPER TOGGLE (like paper)
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            isMissionPaperOn = !isMissionPaperOn;

            missionPaperModel.SetActive(isMissionPaperOn);

            // turn off others if mission paper is on
            if (isMissionPaperOn)
            {
                light1.SetActive(false);
                FlashlightModel.SetActive(false);
                keyModel.SetActive(false);
                paperModel.SetActive(false);
                storyLetterModel.SetActive(false);
                tool02Model.SetActive(false);
                KeyModel01.SetActive(false);
                KeyModel02.SetActive(false);

                isTool02On = false;
                isKey01On = false;
                isKey02On = false;
                isStoryLetterOn = false;
                isFlashlightOn = false;
                isKeyOn = false;
                isPaperOn = false;
            }
        }

        // STORY LETTER TOGGLE
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            isStoryLetterOn = !isStoryLetterOn;

            storyLetterModel.SetActive(isStoryLetterOn);

            // turn off others if story letter is on
            if (isStoryLetterOn)
            {
                light1.SetActive(false);
                FlashlightModel.SetActive(false);
                keyModel.SetActive(false);
                paperModel.SetActive(false);
                missionPaperModel.SetActive(false);
                tool02Model.SetActive(false);
                KeyModel01.SetActive(false);
                KeyModel02.SetActive(false);

                isTool02On = false;
                isKey01On = false;
                isKey02On = false;
                isFlashlightOn = false;
                isKeyOn = false;
                isPaperOn = false;
                isMissionPaperOn = false;
            }
        }

        // TOOL TOGGLE 
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            isToolOn = !isToolOn;

            toolModel.SetActive(isToolOn);

            // turn off others if tool is on
            if (isToolOn)
            {
                light1.SetActive(false);
                FlashlightModel.SetActive(false);
                keyModel.SetActive(false);
                paperModel.SetActive(false);
                missionPaperModel.SetActive(false);
                storyLetterModel.SetActive(false);
                tool02Model.SetActive(false);
                KeyModel01.SetActive(false);
                KeyModel02.SetActive(false);

                isTool02On = false;
                isKey01On = false;
                isKey02On = false;
                isFlashlightOn = false;
                isKeyOn = false;
                isPaperOn = false;
                isMissionPaperOn = false;
                isStoryLetterOn = false;
            }
        }


        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            isTool02On = !isTool02On;

            tool02Model.SetActive(isTool02On);

            if (isTool02On)
            {
                light1.SetActive(false);
                FlashlightModel.SetActive(false);
                keyModel.SetActive(false);
                KeyModel01.SetActive(false);
                KeyModel02.SetActive(false);
                paperModel.SetActive(false);
                missionPaperModel.SetActive(false);
                storyLetterModel.SetActive(false);
                toolModel.SetActive(false);

                isFlashlightOn = false;
                isKeyOn = false;
                isKey01On = false;
                isKey02On = false;
                isPaperOn = false;
                isMissionPaperOn = false;
                isStoryLetterOn = false;
                isToolOn = false;
            }
        }


        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            isKey01On = !isKey01On;

            KeyModel01.SetActive(isKey01On);

            if (isKey01On)
            {
                light1.SetActive(false);
                FlashlightModel.SetActive(false);
                keyModel.SetActive(false);
                KeyModel02.SetActive(false);
                paperModel.SetActive(false);
                missionPaperModel.SetActive(false);
                storyLetterModel.SetActive(false);
                toolModel.SetActive(false);
                tool02Model.SetActive(false);

                isFlashlightOn = false;
                isKeyOn = false;
                isKey02On = false;
                isPaperOn = false;
                isMissionPaperOn = false;
                isStoryLetterOn = false;
                isToolOn = false;
                isTool02On = false;
            }
        }


        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            isKey02On = !isKey02On;

            KeyModel02.SetActive(isKey02On);

            if (isKey02On)
            {
                light1.SetActive(false);
                FlashlightModel.SetActive(false);
                keyModel.SetActive(false);
                KeyModel01.SetActive(false);
                paperModel.SetActive(false);
                missionPaperModel.SetActive(false);
                storyLetterModel.SetActive(false);
                toolModel.SetActive(false);
                tool02Model.SetActive(false);

                isFlashlightOn = false;
                isKeyOn = false;
                isKey01On = false;
                isPaperOn = false;
                isMissionPaperOn = false;
                isStoryLetterOn = false;
                isToolOn = false;
                isTool02On = false;
            }
        }
    }
}
