using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall : MonoBehaviour
{
    [SerializeField]
    private int maxHp = 100;
    private int currentHp;

    // Í¹Ş¾Æ¿ï¿½ï¿½ï¿?ï¿½×°ï¿½ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½'

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
        Debug.Log($"ë²½ì´ {damage}???°ë?ì§€ë¥?ë°›ì•˜?µë‹ˆ?? ?¨ì? HP: {currentHp}");

        if (currentHp <= 0)
        {
            Debug.Log("ë²½ì´ ?Œê´´?˜ì—ˆ?µë‹ˆ??");
            Destroy(gameObject);
        }
    }
}
