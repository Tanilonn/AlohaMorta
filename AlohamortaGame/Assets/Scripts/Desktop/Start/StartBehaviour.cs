using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartRoutine());
    }

    public IEnumerator StartRoutine()
    {
        yield return new WaitForSeconds(5);

        SceneManager.LoadScene("Desktop");
    }
}
