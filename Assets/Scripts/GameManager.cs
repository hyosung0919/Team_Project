using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //프리팹 리소스
    public GameObject WallPrefab;                      //벽 프리팹
    public Sprite[] WallImages;                          //벽 이미지 배열
    //영역 Transform
    public Transform deckArea;                          //덱 영역
    public Transform handArea;                          //손패영역
    //UI 요소
    public Button drawButton;                           //드로우 버튼
    public TextMeshProUGUI deckCountText;               //남은 덱 벽 수 표시 텍스트
    //설정 값
    public float wallSpacing = 2.0f;                    //벽 간격
    public int maxHandSize = 6;                         //최대 손패 크기
    
    //배열 선언
    public GameObject[] deckWalls;                      //덱 벽 배열
    public int deckCount;                               //현재 덱에 있는 벽의 수

    public GameObject[] handWalls;                      //손패 배열
    public int handCount;                               //현재 손패에 있는 벽의 수

    //미리 정의된 벽 목록 (숫자만)
    public int[] prefedinedDeck = new int[]
    {
        1,1,1,1,1,1,1,1,
        2,2,2,2,2,2,
        3,3,3,3,
        4,4
    };

    void Start()
    {
        //배열 초기화
        deckWalls = new GameObject[prefedinedDeck.Length];
        handWalls = new GameObject[maxHandSize];

        //덱 초기화 및 셔플
        InitializeDeck();
        ShuffleDeck();

        if(drawButton != null)              //버튼 유아이 체크
        {
            drawButton.onClick.AddListener(OnDrawButtonClicked);        //있을 경우 버튼을 누르면OnDrawButtonClicked 함수 동작
        }
    }
    void ShuffleDeck()                                  //Fisher-Yates 셔플 알고리즘
    {
        for(int i = 0; i < deckCount - 1; i++)
        {
            int j = Random.Range(i, deckCount);
            //배열 내 카드 교환
            GameObject temp = deckWalls[i];
            deckWalls[i] = deckWalls[j];
            deckWalls[j] = temp;
        }
    }
    //덱 초기화 - 정해진 벽 생성
    void InitializeDeck()
    {
        deckCount = prefedinedDeck.Length;

        for (int i = 0; i <prefedinedDeck.Length; i++)
        {
            int value = prefedinedDeck[i];                  //벽 값 가져오기
            //이미지 인덱스 계산(값에 따라 다른 이미지 사용)
            int imageIndex = value - 1;                     //값이 1부터 시작하므로 인덱스 0부터
            if(imageIndex >= WallImages.Length || imageIndex < 0)
            {
                imageIndex = 0;                     //이미지가 부족하거나 인덱스가 잘못된 경우 첫 번째 이미지 사용
            }
            //벽 오브젝트 생성 (덱 위치)
            GameObject newWallObj = Instantiate(WallPrefab, deckArea.position, Quaternion.identity);
            newWallObj.transform.SetParent(deckArea);
            newWallObj.SetActive(false);            //처음에는 비활성화
            //벽 컴포넌트 초기화
            Wall wallComp = newWallObj.GetComponent<Wall>();
            if(wallComp != null)
            {
                wallComp.InitWall(value, WallImages[imageIndex]);
            }
            deckWalls[i] = newWallObj;              //배열에 저장
        }
    }

    //손패 정렬 함수
    public void ArrangeHand()
    {
        if (handCount == 0)                  //손에 벽이 없으면 정렬이 필요 없기 때문에 return
            return;

        float StartX = -(handCount - 1) * wallSpacing / 2;          //카드 중앙 정렬을 위한 오프셋 계산

        for (int i = 0; i < handCount; i++)
        {
            if (handWalls[i] != null)
            {
                Vector3 newPos = handArea.position + new Vector3(StartX + i * wallSpacing, 0, -0.005f);
                handWalls[i].transform.position = newPos;
            }
        }
    }

    void OnDrawButtonClicked()          //드로우 버튼 클릭시 덱에서 벽 뽑기
    {
        DrawWallToHand();
    }
    public void DrawWallToHand()        //덱에서 벽을 뽑아 손패로 이동
    {
        if (handCount >= maxHandSize)   //손패가 가득 찼는지 확인
        {
            Debug.Log("손패가 가득 찼습니다!");
            return;
        }
        if (deckCount <= 0)             //덱에 벽이 남아있는지 확인
        {
            Debug.Log("덱에 더 이상 카드가 없습니다.");
            return;
        }
        GameObject drawnWall = deckWalls[0];        //덱에서 맨 위에 벽을 가져오기

        for(int i = 0; i < deckCount - 1; i++)      //덱 배열 정리 (앞으로 한칸씩 당기기)
        {
            deckWalls[i] = deckWalls[i + 1];
        }
        deckCount--;

        drawnWall.SetActive(true);                  //벽 활성화
        handWalls[handCount] = drawnWall;           //손패에 벽 추가
        handCount++;

        drawnWall.transform.SetParent(handArea);    //벽의 부모를 손패를 영역으로 설정

        ArrangeHand();                              //손패 정령
    }
}
