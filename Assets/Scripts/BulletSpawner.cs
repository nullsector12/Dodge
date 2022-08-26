using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{

    public GameObject bulletPrefab;     // 생성할 탄알의 원본 프리팹
    public float spawnRateMin = 0.5f;   // 총알 최소 생성주기
    public float spawnRateMax = 3f;     // 총알 최대 생성주기

    private Transform _target;       // 총알을 발사할 대상
    private float _spawnRate;        // 총알을 발사할 주기
    private float _timeAfterSpawn;   // 총알의 최근 생성시점에서 지난 시간
    
    void Start()
    {
        _timeAfterSpawn = 0f;
        _spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        _target = FindObjectOfType<PlayerController>().transform;
    }
    //
    void Update()
    {
        // timeAfterSpawn 갱신
        _timeAfterSpawn += Time.deltaTime;
        
        // 최근 생성 시점에서부터 누적된 시간이 생성 주기보다 크거나 같다면
        if(_timeAfterSpawn >= _spawnRate)
        {
            //  누적된 시간 리셋
            _timeAfterSpawn = 0f;

            //  bulletPrefab의 복제본을
            //  transform.position 위치와 tranform.rotation 회전으로 생성
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            
            // 생성된 bullet 게임 오브젝트의 정면 방향이 target을 향하도록 회전
            bullet.transform.LookAt(_target);
            
            // 다음번 생성 간격을 spawnRateMin, spawnRateMax 사이에서 랜덤 지정
            _spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
    
    
}
