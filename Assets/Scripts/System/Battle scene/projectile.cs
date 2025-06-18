using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public enum BulletType { Stone, Arrow , Dialysis, Cannon , Missile }

public class projectile : MonoBehaviour
{
    [SerializeField]
    private List<BulletData> bulletdatas; //��ũ���ͺ� ������Ʈ �޾ƿ�

    [SerializeField]
    private GameObject bulletprefab;
    public float Speed = 1.0f; //���ǵ�
    public int bulletcount = 0; //ī��Ʈ��
    public bool isbullet = false; //����üũ
    public float fireInterval = 0.2f; // �߻� ����
    public BulletType bulletTypeToUse = BulletType.Stone;



    public Animator animator;  //����ü ������Ʈ �ִϸ��̼�
    private AudioSource _source; //����ü �����?
    private AudioClip _clip; //��Ʈ����

    public float rayDistance = 20; //����ü ���� �Ÿ�
    public LayerMask targetLayer;

    public bool isWallHit = false; //�� �浹 ���� 
    public bool iscastlehit = false; //�� �浹 ����

   
    // Start is called before the first frame update
    void Start()
    {
        if (isbullet)
        {
            StartCoroutine(FireBullets());
        }

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = Vector2.left; //�������� ���̻���

        RaycastHit2D[] hit2D = Physics2D.RaycastAll(transform.position, dir, rayDistance, targetLayer);


        Debug.DrawRay(transform.position, dir * rayDistance, Color.red); //���� ����׿�?���� ���̰��ϴ� �ڵ�

        foreach (RaycastHit2D hit in hit2D)
        {
            Debug.Log("충돌???�브?�트: " + hit.collider.name);
            if (hit.collider.CompareTag("Wall"))
            {
                Debug.Log("�?충돌");
                break; //   Ž ߴ�?
            }

            if (hit.collider.CompareTag("Castle"))
            {
                Debug.Log("??충돌");
            }
        }

    }
    IEnumerator FireBullets()
    {
        for (int i = 0; i < bulletcount; i++)
        {
            SpwawnBullet(bulletTypeToUse);
            yield return new WaitForSeconds(fireInterval);
        }
    }
    public void SpwawnBullet(BulletType type)
    {
        if (bulletdatas == null || bulletdatas.Count == 0 || (int)type >= bulletdatas.Count)
        {
            Debug.LogError("Bullet data is not properly set up!");
            return;
        }

        GameObject bulletObj = Instantiate(bulletprefab, transform.position, Quaternion.identity);
        Bullet bullet = bulletObj.GetComponent<Bullet>();
        if (bullet != null)
        {
            bullet.bulletData = bulletdatas[(int)type];
        }
    }
}
