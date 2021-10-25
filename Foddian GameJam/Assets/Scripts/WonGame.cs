using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class WonGame : MonoBehaviour
{
    [SerializeField] TMP_Text WinText;
    [SerializeField] TMP_Text SpeedrunText;
    [SerializeField] TMP_Text JumpText;

    public bool _won;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_won && collision.CompareTag("Player"))
        {
            StatsManager _stats = FindObjectOfType<StatsManager>();
            _stats.watch.Stop();

            WinText.gameObject.SetActive(true);
            SpeedrunText.gameObject.SetActive(true);
            JumpText.gameObject.SetActive(true);

            WinText.text = "You Win!";
            SpeedrunText.text = "Time: " + _stats.watch.Elapsed.ToString(@"m\:ss\.fff");
            JumpText.text = "jumps: " + _stats.Jumps;
            _won = true;
        }
    }
}
