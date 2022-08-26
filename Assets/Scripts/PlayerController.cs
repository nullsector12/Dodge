using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody PlayerRigidbody;

    public float playerMoveSpeed = 8f; 
    
    void Start()
    {
        PlayerRigidbody = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        // 수평축과 수직축의 입력값을 감지하여 저장
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");
        
        // 실제 이동속도를 입력값과 이동 속력을 사용해 결정
        float xMoveSpeed = xInput * playerMoveSpeed;
        float zMoveSpeed = zInput * playerMoveSpeed;
        
        // Vector3 속도를 (xMoveSpeed, zMoveSpeed)로 생성
        Vector3 newPlayerVelocity = new Vector3(xMoveSpeed, 0f, zMoveSpeed);
        PlayerRigidbody.velocity = newPlayerVelocity;

        // 플레이어 입력 감지
        // 관성의 영향으로 가속도가 작용해 실제 이동속력을 바로바로 적용하지 못함.
        /*if (Input.GetKey(KeyCode.UpArrow) == true)
        {
            PlayerRigidbody.AddForce(0f, 0f, playerMoveSpeed);
        }
        
        if (Input.GetKey(KeyCode.DownArrow) == true)
        {
            PlayerRigidbody.AddForce(0f, 0f, -playerMoveSpeed);
        }
        
        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            PlayerRigidbody.AddForce(playerMoveSpeed, 0f, 0f);
        }
        
        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            PlayerRigidbody.AddForce(-playerMoveSpeed, 0f, 0f);
        }0f*/
        
        
    }

    public void Die()
    {
        gameObject.SetActive(false);

        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.EndGame();
    }
}
