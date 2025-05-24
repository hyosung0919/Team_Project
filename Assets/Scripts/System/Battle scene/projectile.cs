using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public enum BulletType { Stone, Arrow , Dialysis, Cannon , Missile }

public class projectile : MonoBehaviour
{
    [SerializeField]
    private List<BulletData> bulletdatas; //스크립터블 오브잭트 받아옴
    [SerializeField]
    private GameObject bulletprefab;



    public Animator animator;  //투사체 오브젝트 애니메이션
    private AudioSource _source; //투사체 오디오
    private AudioClip _clip; //히트사운드

    public float rayDistance = 20; //투사체 날라갈 거리
    public LayerMask targetLayer;

    public bool isWallHit = false; //벽 충돌 판정 
    public bool iscastlehit = false; //성 충돌 판정

   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = Vector2.left; //왼쪽으로 레이생성

        RaycastHit2D[] hit2D = Physics2D.RaycastAll(transform.position, dir, rayDistance, targetLayer);


        Debug.DrawRay(transform.position, dir * rayDistance, Color.red); //레이 디버그용 레이 보이게하는 코드

        foreach (RaycastHit2D hit in hit2D)
        {
            Debug.Log("충돌한 오브젝트: " + hit.collider.name);
            if (hit.collider.CompareTag("Wall"))
            {
                Debug.Log("벽 감지");
                // Destroy(hit.collider.gameObject);
                break; // 벽이 있으면 탐색 중단
            }

            if (hit.collider.CompareTag("Castle"))
            {
                Debug.Log("성 감지");
            }
        }

    }
    public BulletData SpwawnBullet(BulletType type)
    {
        var newbullet = Instantiate(bulletprefab).GetComponent<BulletData>();
        newbullet.bulletdata = bulletdatas[(int)type];
        newbullet.name = newbullet.bulletdata.ToString();
        return newbullet;   
    }
}
