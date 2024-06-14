using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text points_text;
    public BalloonPool pooler;
    public GameObject happyB;

    public MusicManager music;
    
    public float delta_game_duration = 30f;

    public int points;

    private float time;

    private bool done;
    // Start is called before the first frame update
    void Start()
    {
        points_text.text = points.ToString();
        time = 0;
        done = false;
        happyB.SetActive(false);
        music.PlayMusic("HappyB", true, 15f, 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (points >= 100 && !done)
        {
            pooler.delta_duration = 0.5f;
        }
        
        if (time >= delta_game_duration && !done)
        {
            done = true;
            StartCoroutine(StopAllPlay());
        }
        
        if(!done)
            time += Time.deltaTime;

    }

    public void AddPoints(int value)
    {
        points += value;
        points_text.text = points.ToString();
    }

    IEnumerator StopAllPlay()
    {
        music.StopAll();
        pooler.gameObject.SetActive(false);
        happyB.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        music.PlayMusic("Applause");
   
        
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene("HappyBirthdayScene");
    }
}
