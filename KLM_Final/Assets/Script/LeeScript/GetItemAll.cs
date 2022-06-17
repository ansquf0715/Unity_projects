using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GetItemAll : MonoBehaviour
{
    float speedTime = 0f;
    bool GetSpeed = false;

    float damageTime = 0f;
    bool GetDamage = false;

    float blindTime = 0f;
    bool GetBlind = false;

    public GameObject BlindImage;
    public GameObject Gold;
    public GameObject Crown;
    public RawImage[] itemImage;
    public Texture speedImage;
    public Texture damageImage;
    public Texture blindImage;

    public AudioClip audioItem;
    AudioSource audioSource;

    public static bool getCrown = false;
    public static bool getGold = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponentInParent<AudioSource>();

        speedTime = 0f;
        damageTime = 0f;
        blindTime = 0f;
        SetCrownGold();
    }

    // Update is called once per frame
    void Update()
    {
        SetSpeedItemTimer();
        SetDamageItemTimer();
        SetBlindItemTimer();

        Debug.Log(getGold);
        //Debug.Log(CharacterController.speed);
        //Debug.Log(Attack.moveSpeed);
        if (UI.score>=100)
        {
            CreateCrown();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SpeedItem")
        {
            PlayItemSound();
            Destroy(other.transform.parent.parent.gameObject);
            GetSpeed = true;

            SetUIimage(0,speedImage,100);

            CharacterController.speed = 14f;
            Attack.moveSpeed = 20f;

            if (speedTime > 0)
            {
                speedTime += 3f;
            }
            else
            {
                speedTime = 3f;
            }
        }

        if (other.tag == "DamageItem")
        {
            PlayItemSound();

            Destroy(other.transform.parent.parent.gameObject);
            GetDamage = true;
            
            SetUIimage(1, damageImage,100);

            Attack.damage = 2;

            if (damageTime > 0)
            {
                damageTime += 3f;
            }
            else
            {
                damageTime = 3f;
            }
        }

        if (other.tag == "BlindItem")
        {
            PlayItemSound();

            Destroy(other.transform.parent.parent.gameObject);
            GetBlind = true;

            SetUIimage(2, blindImage,100);

            BlindImage.SetActive(true);

            if (blindTime > 0)
            {
                blindTime += 5f;
            }
            else
            {
                blindTime = 5f;
            }
        }

        if (other.tag == "CoinItem")
        {
            PlayItemSound();

            Destroy(other.transform.parent.parent.gameObject);
            UI.score += 5;
        }
        if (other.tag == "Gold")
        {
            PlayItemSound();
            getGold = true;
            Debug.Log("°ñµå¼º°ø");
            UI.score += 10;
            if (UI.score >= 100)
            {
                SceneManager.LoadScene("GameClear");
            }
            SceneManager.LoadScene("GameOver");

        }
        if (other.tag =="Crown")
        {
            PlayItemSound();
            getCrown = true;
            Debug.Log("¿Õ°ü¼º°ø");
            SceneManager.LoadScene("GameClear");
        }
    }

    private void SetSpeedItemTimer()
    {
        if (GetSpeed)
        {
            if (speedTime > 0)
            {
                //Debug.Log(speedTime);
                speedTime -= Time.deltaTime;
            }
            else
            {
                CharacterController.speed = 7f;
                Attack.moveSpeed = 7f;

                GetSpeed = false;
                EndItem(0);
            }
        }
    }
    private void SetDamageItemTimer()
    {
        if (GetDamage)
        {
            if (damageTime > 0)
            {
                //Debug.Log(damageTime);
                damageTime -= Time.deltaTime;
            }
            else
            {
                Attack.damage = 1;
                GetDamage = false;
                EndItem(1);
            }
        }
    }
    private void SetBlindItemTimer()
    {
        if (GetBlind)
        {
            if (blindTime > 0)
            {
                blindTime -= Time.deltaTime;
            }
            else
            {
                BlindImage.SetActive(false);
                GetBlind = false;
                EndItem(2);
            }
        }
    }

    void SetUIimage(int i,Texture Image, int colorA)
    {
        itemImage[i].texture = Image;

        Color color = itemImage[i].color;
        color.a = colorA;
        itemImage[i].color = color;
    }

    void EndItem(int i)
    {
        speedTime = 0;
        SetUIimage(i, null, 0);
    }
    void PlayItemSound()
    {
        audioSource.clip = audioItem;
        audioSource.Play();
    }
    void CreateCrown()
    {
        Gold.SetActive(false);
        Crown.SetActive(true);
    }

    void SetCrownGold()
    {
        Gold.SetActive(true);
        Crown.SetActive(false);
    }
}
