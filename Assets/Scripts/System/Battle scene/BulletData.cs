using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bullet Data", menuName = "Scripttable Object/Bullet Data", order = int.MaxValue)]
public class BulletData : ScriptableObject
{
    //����ü �����Ͱ� �������̵� ��������
    [SerializeField]
    private string _bulletname; 
    public string Bulletname { get { return _bulletname; } }

    [SerializeField]
    private int _bulletdamage;
    public int Bulletdamage { get { return _bulletdamage; } }

    [SerializeField]
    private int _bulletspeed;
    public int Bulletspeed { get { return _bulletspeed; } }

    public BulletData bulletdata { get; set; }
}
