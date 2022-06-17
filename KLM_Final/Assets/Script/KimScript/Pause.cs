using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public static bool IsPause;
    bool state;
    public GameObject Target;
    // Start is called before the first frame update
    void Start()
    {
        IsPause = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            //일시정지 활성화
            if (IsPause==false)
            {
                Time.timeScale = 0;
                Target.SetActive(true);
                IsPause = true;
                return;
            }
            else if(IsPause==true)
            {
                Time.timeScale = 1;
                IsPause = false;
                Target.SetActive(false);
            }
        }
    }
}
