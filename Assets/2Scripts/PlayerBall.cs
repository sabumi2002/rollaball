using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBall : MonoBehaviour
{
    public float jumpPower= 10;
    public int itemCount;
    public GameManagerLogic manager;
    bool isJump;
    Rigidbody rigid;
    AudioSource audio;

    void Awake()
    {
        isJump = false;
        rigid = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && !isJump) {
            isJump = true;
            rigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        rigid.AddForce(new Vector3(h, 0, v), ForceMode.Impulse); //방향키로 움직이게해줌

    }

    void OnCollisionEnter(Collision collision)  //충돌정보는 이 콜리션 안에있다.
    {
        if (collision.gameObject.tag == "Floor")   //부딪친게 바닥이다!
            isJump = false;
    }

    private void OnTriggerEnter(Collider other) //아이템 먹었을때 소리.
    {
        if (other.tag == "Item")
        {

            itemCount++;
            audio.Play(); //오디오실행
            other.gameObject.SetActive(false);
            manager.GetItem(itemCount);
        }
        else if (other.tag == "FinishPoint")
        {
            if (itemCount == manager.TotalItemCount)
            {
                //game clear!
                if (manager.stage == 2)
                    SceneManager.LoadScene(0);
                else
                    SceneManager.LoadScene(manager.stage + 1);

            }
            else
            {
                //restart..
                SceneManager.LoadScene(manager.stage);

            }
        }
        
    }

}
