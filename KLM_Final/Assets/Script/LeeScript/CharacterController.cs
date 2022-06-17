using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour
{
    [SerializeField]
    private Transform characterBody;
    [SerializeField]
    private Transform cameraArm;



    Animator animator;
    public GameObject bullet;
    public GameObject firePosition;

    public static bool isFire = false;
    public static float speed = 7f;

    public AudioClip audioAttack;
    AudioSource audioSource;

    void Awake()
    {
    	this.audioSource = GetComponent<AudioSource>();
        speed = 7f;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        animator = characterBody.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        LookAround();
        Move();
        Fire();
        UpdateAnimatior();
        fallGround();
    }

    private void Move()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        bool isMove = moveInput.magnitude != 0;
        animator.SetBool("isMove", isMove);
        if (isMove)
        {
            Vector3 lookForward = new Vector3(cameraArm.forward.x, 0f, cameraArm.forward.z).normalized;
            Vector3 lookRight = new Vector3(cameraArm.right.x, 0f, cameraArm.right.z).normalized;
            Vector3 moveDir = lookForward * moveInput.y + lookRight * moveInput.x;

            characterBody.forward = moveDir;
            transform.position += moveDir * Time.deltaTime * speed;
        }
    }



    private void LookAround()
    {
        Vector2 mouseDelta= new Vector2(Input.GetAxis("Mouse X"),Input.GetAxis("Mouse Y"));
        Vector3 camAngle = cameraArm.rotation.eulerAngles;
        float x = camAngle.x - mouseDelta.y;

        if (x < 180f)
        {
            x = Mathf.Clamp(x, -1f, 70f);
        }
        else
        {
            x = Mathf.Clamp(x, 335f, 361f);
        }

        cameraArm.rotation = Quaternion.Euler(x, camAngle.y + mouseDelta.x, camAngle.z);
    }

    private void Fire()
    {
        if (!Pause.IsPause)
        {
            if (Input.GetMouseButtonDown(0))
            {
                audioSource.clip = audioAttack;
                audioSource.Play();
                isFire = true;
                Instantiate(bullet, firePosition.GetComponent<Transform>().position, firePosition.GetComponent<Transform>().rotation);
            }
            if (Input.GetMouseButtonUp(0))
            {
                isFire = false;
            }
        }
        else return;
    }

    private void UpdateAnimatior()
    {
        animator.SetBool("isAttack", isFire);
    }

    private void fallGround()
    {
        if(transform.GetChild(0).gameObject.transform.position.y <-5)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
