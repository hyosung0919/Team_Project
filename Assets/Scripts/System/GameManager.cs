using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //������ ���ҽ�
    public GameObject WallPrefab;                      //�� ������
    public Sprite[] WallImages;                          //�� �̹��� �迭
    //���� Transform
    public Transform deckArea;                          //�� ����
    public Transform handArea;                          //���п���
    //UI ���
    public Button drawButton;                           //��ο� ��ư
    public TextMeshProUGUI deckCountText;               //���� �� �� �� ǥ�� �ؽ�Ʈ
    //���� ��
    public float wallSpacing = 2.0f;                    //�� ����
    public int maxHandSize = 6;                         //�ִ� ���� ũ��
    
    //�迭 ����
    public GameObject[] deckWalls;                      //�� �� �迭
    public int deckCount;                               //���� ���� �ִ� ���� ��

    public GameObject[] handWalls;                      //���� �迭
    public int handCount;                               //���� ���п� �ִ� ���� ��

    //�̸� ���ǵ� �� ��� (���ڸ�)
    public int[] prefedinedDeck = new int[]
    {
        1,1,1,1,1,1,1,1,
        2,2,2,2,2,2,
        3,3,3,3,
        4,4
    };

    void Start()
    {
        //�迭 �ʱ�ȭ
        deckWalls = new GameObject[prefedinedDeck.Length];
        handWalls = new GameObject[maxHandSize];

        //�� �ʱ�ȭ �� ����
        InitializeDeck();
        ShuffleDeck();

        if(drawButton != null)              //��ư ������ üũ
        {
            drawButton.onClick.AddListener(OnDrawButtonClicked);        //���� ��� ��ư�� ������OnDrawButtonClicked �Լ� ����
        }
    }
    void ShuffleDeck()                                  //Fisher-Yates ���� �˰����
    {
        for(int i = 0; i < deckCount - 1; i++)
        {
            int j = Random.Range(i, deckCount);
            //�迭 �� ī�� ��ȯ
            GameObject temp = deckWalls[i];
            deckWalls[i] = deckWalls[j];
            deckWalls[j] = temp;
        }
    }
    //�� �ʱ�ȭ - ������ �� ����
    void InitializeDeck()
    {
        deckCount = prefedinedDeck.Length;

        for (int i = 0; i <prefedinedDeck.Length; i++)
        {
            int value = prefedinedDeck[i];                  //�� �� ��������
            //�̹��� �ε��� ���(���� ���� �ٸ� �̹��� ���)
            int imageIndex = value - 1;                     //���� 1���� �����ϹǷ� �ε��� 0����
            if(imageIndex >= WallImages.Length || imageIndex < 0)
            {
                imageIndex = 0;                     //�̹����� �����ϰų� �ε����� �߸��� ��� ù ��° �̹��� ���
            }
            //�� ������Ʈ ���� (�� ��ġ)
            GameObject newWallObj = Instantiate(WallPrefab, deckArea.position, Quaternion.identity);
            newWallObj.transform.SetParent(deckArea);
            newWallObj.SetActive(false);            //ó������ ��Ȱ��ȭ
            //�� ������Ʈ �ʱ�ȭ
            Wall wallComp = newWallObj.GetComponent<Wall>();
            if(wallComp != null)
            {
                wallComp.InitWall(value, WallImages[imageIndex]);
            }
            deckWalls[i] = newWallObj;              //�迭�� ����
        }
    }

    //���� ���� �Լ�
    public void ArrangeHand()
    {
        if (handCount == 0)                  //�տ� ���� ������ ������ �ʿ� ���� ������ return
            return;

        float StartX = -(handCount - 1) * wallSpacing / 2;          //ī�� �߾� ������ ���� ������ ���

        for (int i = 0; i < handCount; i++)
        {
            if (handWalls[i] != null)
            {
                Vector3 newPos = handArea.position + new Vector3(StartX + i * wallSpacing, 0, -0.005f);
                handWalls[i].transform.position = newPos;
            }
        }
    }

    void OnDrawButtonClicked()          //��ο� ��ư Ŭ���� ������ �� �̱�
    {
        DrawWallToHand();
    }
    public void DrawWallToHand()        //������ ���� �̾� ���з� �̵�
    {
        if (handCount >= maxHandSize)   //���а� ���� á���� Ȯ��
        {
            Debug.Log("���а� ���� á���ϴ�!");
            return;
        }
        if (deckCount <= 0)             //���� ���� �����ִ��� Ȯ��
        {
            Debug.Log("���� �� �̻� ī�尡 �����ϴ�.");
            return;
        }
        GameObject drawnWall = deckWalls[0];        //������ �� ���� ���� ��������

        for(int i = 0; i < deckCount - 1; i++)      //�� �迭 ���� (������ ��ĭ�� ����)
        {
            deckWalls[i] = deckWalls[i + 1];
        }
        deckCount--;

        drawnWall.SetActive(true);                  //�� Ȱ��ȭ
        handWalls[handCount] = drawnWall;           //���п� �� �߰�
        handCount++;

        drawnWall.transform.SetParent(handArea);    //���� �θ� ���и� �������� ����

        ArrangeHand();                              //���� ����
    }
}
