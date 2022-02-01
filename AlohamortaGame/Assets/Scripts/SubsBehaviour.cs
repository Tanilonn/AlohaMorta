using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SubsBehaviour : MonoBehaviour
{
    public Text Subtitle;
    public List<Subtitle> Subtitles;
    public AudioClip Clip;
    public AudioSource Player;
    public Button ContinueButton;
    public GameObject DisableThis;
    public string Scene;


    private void Start()
    {        
        Player.clip = Clip;
        Play();
        if (ContinueButton != null)
        {
            ContinueButton.gameObject.SetActive(false);
        }
    }
    public void Play()
    {
        if (DisableThis != null)
        {
            DisableThis.SetActive(false);
        }
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
        if (DisableThis != null)
        {
            DisableThis.SetActive(true);
        }
        Subtitle.text = "";
        Player.Stop();
        if(ContinueButton != null)
        {
            ContinueButton.gameObject.SetActive(true);
        }
        if (!string.IsNullOrEmpty(Scene))
        {
            SceneManager.LoadScene(Scene);
        }
    }
}
