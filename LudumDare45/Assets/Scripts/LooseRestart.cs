using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LooseRestart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Start coroutine to go back to start screen
        StartCoroutine(RestartGame());
    }

    public IEnumerator RestartGame()
    {
        // 3s tempo before switching to start screen
        yield return new WaitForSeconds(3.0f);

        // Load start screen
        SceneManager.LoadScene("TitleScreen");
    }
}
