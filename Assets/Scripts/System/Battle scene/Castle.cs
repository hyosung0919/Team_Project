using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour
{
    [SerializeField] public float maxCastleHp;
    [SerializeField] public float castleHp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DamageCastle()
    {

    }

    public void DestroyedCastle()
    {
        Destroy(gameObject);
    }
}
