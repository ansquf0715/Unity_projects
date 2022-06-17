using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI scoreText;
    //public TextMeshProUGUI[] rankText;

    public static int score = 0;
    public float time = 15f;

    private int[] bestScore = new int[5];

    public Toggle mute;
    public AudioMixer audioMixer;
    public Slider audioSlider;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer();
        scoreUpdate();

        if (GetItemAll.getCrown || GetItemAll.getGold)
        {
            setScore();
        }

    }

    private void timer()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            setScore();
            time = 5f;
            score = 0;
            if (UI.score >= 100)
            {
                SceneManager.LoadScene("GameClear");
            }
            SceneManager.LoadScene("GameOver");
        }
        timeText.text = "남은 시간: " + Mathf.Ceil(time).ToString() + "초";
    }

    private void scoreUpdate()
    {
        scoreText.text = "Score: " + score.ToString()+ "점";
    }

    private void timeOver()
    {
        
    }

    void setScore()
    {
        int tmpScore = 0;

        for (int i = 0; i < 5; i++)
        {
            bestScore[i] = PlayerPrefs.GetInt(i + "BestScore");
            if (score > bestScore[i])
            {
                tmpScore = bestScore[i];
                bestScore[i] = score;

                PlayerPrefs.GetInt(i + "BestScore", score);

                score = tmpScore;
            }
        }
        for(int i=0; i<5; i++)
        {
            PlayerPrefs.SetInt(i + "BestScore", bestScore[i]);
        }
    }

    public void Mute()
    {
        AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;
    }

    public void AudioControl()
    {
        float Sound = audioSlider.value;

        if (Sound == -40f) audioMixer.SetFloat("BGM", -80);
        else audioMixer.SetFloat("BGM", Sound);
    }
}
