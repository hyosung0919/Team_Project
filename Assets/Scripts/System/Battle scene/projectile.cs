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



    public Animator animator;  //����ü ������Ʈ �ִϸ��̼�
    private AudioSource _source; //����ü �����
    private AudioClip _clip; //��Ʈ����

    public float rayDistance = 20; //����ü ���� �Ÿ�
    public LayerMask targetLayer;

    public bool isWallHit = false; //�� �浹 ���� 
    public bool iscastlehit = false; //�� �浹 ����

   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = Vector2.left; //�������� ���̻���

        RaycastHit2D[] hit2D = Physics2D.RaycastAll(transform.position, dir, rayDistance, targetLayer);


        Debug.DrawRay(transform.position, dir * rayDistance, Color.red); //���� ����׿� ���� ���̰��ϴ� �ڵ�

        foreach (RaycastHit2D hit in hit2D)
        {
            Debug.Log("�浹�� ������Ʈ: " + hit.collider.name);
            if (hit.collider.CompareTag("Wall"))
            {
                Debug.Log("�� ����");
                // Destroy(hit.collider.gameObject);
                break; // ���� ������ Ž�� �ߴ�
            }

            if (hit.collider.CompareTag("Castle"))
            {
                Debug.Log("�� ����");
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
