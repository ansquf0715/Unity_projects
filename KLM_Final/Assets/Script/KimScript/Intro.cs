using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Intro : MonoBehaviour
{
    public GameObject TargetMenu;
    public GameObject TargetStory;
    public GameObject TargetControl;
    public GameObject TargetItem;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowStory()
    {
        TargetMenu.SetActive(false);
        TargetStory.SetActive(true);
        TargetControl.SetActive(false);
        TargetItem.SetActive(false);
    }
    public void ShowControl()
    {
        TargetMenu.SetActive(false);
        TargetStory.SetActive(false);
        TargetControl.SetActive(true);
        TargetItem.SetActive(false);
    }
    public void ShowItem()
    {
        TargetMenu.SetActive(false);
        TargetStory.SetActive(false);
        TargetControl.SetActive(false);
        TargetItem.SetActive(true);
    }
    public void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}
