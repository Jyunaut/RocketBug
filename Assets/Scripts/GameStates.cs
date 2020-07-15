using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStates : MonoBehaviour
{
    public GameObject canvas;
    public GameObject rocket;
    public Transform pondLoc;
    public Text fireCounter;
    public Text distance;
    private float timer = 60f;

    void Update()
    {
        fireCounter.text = SpawnFire.fireCount.ToString("F");
        
        if (timer >= 0.0f) 
        {
            timer -= Time.deltaTime;
            distance.text = timer.ToString("F");
        }

        if (SpawnFire.fireCount >= 10)
        {
            SceneManager.LoadScene("Destroyed Rocket");
        }

        if (timer <= 0)
        {
            SceneManager.LoadScene("Safe Landing");
        }

        if (Mathf.Abs(pondLoc.transform.position.x) >= 4f)
        {
            SceneManager.LoadScene("Destroyed Rocket");
        }
    }

    public void Play()
    {
        SpawnFire.fireCount = 0;
        GetComponent<SpawnFire>().enabled = true;
        GetComponent<PondMove>().enabled = true;
        GetComponent<GameStates>().enabled = true;
        
        MonoBehaviour[] scripts = rocket.GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour script in scripts) {
            script.enabled = true;
        }

        canvas.SetActive(false);
    }
}
