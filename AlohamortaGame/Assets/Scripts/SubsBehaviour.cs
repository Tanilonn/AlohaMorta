using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubsBehaviour : MonoBehaviour
{
    public Text Subtitle;
    public List<Subtitle> Subtitles;
    public AudioClip Clip;
    public AudioSource Player;
    public Button ContinueButton;

    private void Start()
    {
        Player.clip = Clip;
        Play();
    }
    public void Play()
    {
        StartCoroutine(SubRoutine());
    }

    public IEnumerator SubRoutine()
    {
        Player.Play();     
        foreach(var sub in Subtitles)
        {
            Subtitle.text = sub.Sub;
            yield return new WaitForSeconds(sub.Duration);
        }
        End();
    }    

    private void End()
    {
        Subtitle.text = "";
        ContinueButton.gameObject.SetActive(true);
    }
}
