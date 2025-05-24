using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bullet Data", menuName = "Scripttable Object/Bullet Data", order = int.MaxValue)]
public class BulletData : ScriptableObject
{
    //투사체 데이터값 오버라이드 받을꺼임
    [SerializeField]
    private string _bulletname; 
    public string Bulletname { get { return _bulletname; } }

    [SerializeField]
    private int _bulletdamage;
    public int Bulletdamage { get { return _bulletdamage; } }

    [SerializeField]
    private int _bulletspeed;
    public int Bulletspeed { get { return _bulletspeed; } }

    public object bulletdata { get; internal set; }
}
