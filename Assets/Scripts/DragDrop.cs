using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour                   //ī�� �巡�� �� ��� ó���� ���� Ŭ����
{
    public bool isDragging = false;                     //�巡�� ������ �Ǻ��ϴ� Bool ��
    public Vector3 startPosition;                       //�巡�� ���� ��ġ
    public Transform startParent;                       //�巡�� ���� �� �ִ� ����(Area)

    private GameManager gameManager;                    //���ӸŴ����� ���� �Ѵ�.
    void Start()
    {
        startPosition = transform.position;             //���� ��ġ�� �θ� ����
        startParent = transform.parent;

        gameManager = FindObjectOfType<GameManager>();      //���� �Ŵ��� ����
    }

    void Update()
    {
        if (isDragging)          //�巡�� ���̸� ���콺 ��ġ�� ī�� �̵�
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            transform.position = mousePos;
        }
    }

    void OnMouseDown()          //���콺 Ŭ�� �� �巡�� ����
    {
        isDragging = true;

        startPosition = transform.position;             //���� ��ġ�� �θ� ����
        startParent = transform.parent;

        GetComponent<SpriteRenderer>().sortingOrder = 10;           //�巡�� ���� ī�尡 �ٸ� ī�庸�� �տ� ���̵��� �Ѵ�.
    }

    void OnMouseUp()            //���콺 ��ư ���� ��
    {
        isDragging = false;
        GetComponent<SpriteRenderer>().sortingOrder = 1;            //�巡�� ���� ī�尡 �ٸ� ī�庸�� �տ� ���̵��� �Ѵ�.

        ReturnToOriginalPosition();
    }

    void ReturnToOriginalPosition()             //���� ��ġ�� ���ư��� �Լ�
    {
        transform.position = startPosition;
        transform.SetParent(startParent);

        if (gameManager != null)
        {
            if (startParent == gameManager.handArea)
            {
                gameManager.ArrangeHand();
            }
        }
    }

    bool IsOverArea(Transform area)                 //ī�尡 Ư�� ���� ���� �ִ��� Ȯ��
    {
        if (area == null)
        {
            return false;
        }

        //������ �ݶ��̴��� ������
        Collider2D areaCollider = area.GetComponent<Collider2D>();
        if (areaCollider == null)
            return false;

        //ī�尡 ���� �ȿ� �ִ��� Ȯ��
        return areaCollider.bounds.Contains(transform.position);
    }
}
