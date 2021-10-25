using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using MoreMountains.Feedbacks;
using UnityEngine.UI;
using DG.Tweening;
public class CutScene : MonoBehaviour
{
    bool _canOpen;
    [SerializeField] Image WantedImage;

    private void Start()
    {
        //OpenFeedback.PlayFeedbacks();
        Invoke(nameof(ShallOpen), 0.75f);
    }

    private void Update()
    {
        if (_canOpen)
        {
            if (Input.GetMouseButtonDown(0))
            {
                WantedImage.DOColor(Color.black, 1f);
                //CloseFeedback.PlayFeedbacks();
                StartCoroutine(OpenNumerator());
                _canOpen = false;
            }
        }
    }

    IEnumerator OpenNumerator()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    void ShallOpen()
    {
        _canOpen = true;
    }
}
