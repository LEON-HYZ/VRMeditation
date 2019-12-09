using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControl : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject WelcomeUI;
    public GameObject MedGuideUI;
    public AudioClip MusicClip1;
    public AudioClip MusicClip2;
    public AudioClip MusicClip3;
    public AudioSource MusicSource;

    private List <AudioClip> MusicList;
    private int m_index = 0;
    

    // Use this for initialization
    public static bool GameIsPaused = false;
    void Start()
    {
        WelcomeUI.SetActive(true);
        MusicList = new List<AudioClip>();
        MusicList.Add(MusicClip1);
        MusicList.Add(MusicClip2);
        MusicList.Add(MusicClip3);
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.Start) || Input.GetKeyDown(KeyCode.Escape))
        {
            WelcomeUI.SetActive(false);
            MedGuideUI.SetActive(false);
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
       

        if (GameIsPaused && OVRInput.GetDown(OVRInput.RawButton.Y))
        {
            QuitGame();
        }

        if(GameIsPaused && OVRInput.GetDown(OVRInput.RawButton.B))
        {
            MedGuide();
        }

        if(!GameIsPaused && OVRInput.GetDown(OVRInput.RawButton.X))
        {
            GameIsPaused = true;
            MedGuideUI.SetActive(false);
            pauseMenuUI.SetActive(true);
            
        }
        //switch music
        if (GameIsPaused && OVRInput.GetDown(OVRInput.RawButton.A))
        {
            if (m_index < 3)
            {
                m_index++;
            }
            else
            {
                m_index = 0;
            }
            MusicSource.clip = MusicList[m_index];
            MusicSource.Play();

        }

    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

    }

    public void MedGuide()
    {
        pauseMenuUI.SetActive(false);
        MedGuideUI.SetActive(true);
        GameIsPaused = false;
        
    }

    public void QuitGame()
    {
        Debug.Log("Quiting Game...");
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
