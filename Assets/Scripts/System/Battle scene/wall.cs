using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall : MonoBehaviour
{
    [SerializeField]
    public float wallHp =50.0f;
    [SerializeField]
    public int wallLevel = 1;

    //�������� �����͹޾ƿ��� �װ����� �� ����'

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DestroyedWall()
    {
        Destroy(gameObject);
    }
}
