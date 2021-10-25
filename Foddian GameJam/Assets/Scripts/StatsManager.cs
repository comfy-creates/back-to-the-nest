using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Diagnostics;
using UnityEngine.SceneManagement;
//using MoreMountains.Feedbacks;
using Cinemachine;
using UnityEngine.UI;
using DG.Tweening;

public class StatsManager : MonoBehaviour
{
    [SerializeField] Image img;

    public Stopwatch watch;

    [SerializeField] TMP_Text SpeedrunTimer, JumpText;

    public bool StartRun;
    bool _firstFrame;

    public int Jumps;

    //[SerializeField] MMFeedbacks StartFeedback;
    [SerializeField] GameObject Player;

    [SerializeField] CinemachineVirtualCamera cam;
    Transform uwu;
    Vector3 StartPos;

    private void Start()
    {
        img.DOColor(Color.clear, 1f);
        //uwu = Instantiate(Player).transform;
        uwu = FindObjectOfType<PlayerController>().transform;
        cam.Follow = uwu.transform;
        cam.LookAt = uwu.transform;

        StartPos = uwu.position;

        //StartFeedback.PlayFeedbacks();
        watch = new Stopwatch();
        watch.Start();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            FindObjectOfType<PlayerController>()._rb.velocity = Vector2.zero;
            uwu.position = StartPos;
            watch.Restart();
            Jumps = 0;
            _firstFrame = false;
        }

        if (StartRun)
        {
            if (!_firstFrame)
            {
                watch = new Stopwatch();
                watch.Start();

                _firstFrame = true;
            }

            TimeSpan currentTime = watch.Elapsed;
            SpeedrunTimer.text = currentTime.ToString(@"m\:ss\.fff");
            JumpText.text = "Jumps: " + Jumps;

        }
    }
}