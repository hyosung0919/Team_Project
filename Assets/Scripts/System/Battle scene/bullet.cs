using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public BulletData bulletData;
    private float moveSpeed = 5f;

    void Update()
    {
        // 총알을 왼쪽으로 이동
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wall"))
        {
            wall wallComponent = other.GetComponent<wall>();
            if (wallComponent != null)
            {
                wallComponent.TakeDamage(bulletData.Bulletdamage);
            }
            Destroy(gameObject); // 총알 제거
        }
    }
}
