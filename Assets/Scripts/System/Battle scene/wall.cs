using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall : MonoBehaviour
{
    [SerializeField]
    private int maxHp = 100;
    private int currentHp;

    // ͹޾ƿ���?�װ����� �� ����'

    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;
        Debug.Log($"벽이 {damage}???��?지�?받았?�니?? ?��? HP: {currentHp}");

        if (currentHp <= 0)
        {
            Debug.Log("벽이 ?�괴?�었?�니??");
            Destroy(gameObject);
        }
    }
}
