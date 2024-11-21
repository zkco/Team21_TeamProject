using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class StagePopup : BasePopup
{
    public RectTransform cursor;  // 이동할 커서 RectTransform
    public List<RectTransform> stages;  // stages를 리스트로 관리
    private int currentIndex = 0; // 현재 위치 (0: Home, 1~3: Enemies)

    void Update()
    {
        // 오른쪽 화살표 입력
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("rightArrow");
            Managers.SoundManager.PlaySFX(SFXType.selectStage);
            currentIndex++; // 현재 위치 증가
            currentIndex = Mathf.Clamp(currentIndex, 0, stages.Count - 1); // 0 ~ stages.Count-1 사이로 제한
            MoveToNextPosition(); // 다음 위치로 이동
        }

        // 왼쪽 화살표 입력
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            Managers.SoundManager.PlaySFX(SFXType.selectStage);
            currentIndex--; // 현재 위치 감소
            currentIndex = Mathf.Clamp(currentIndex, 0, stages.Count - 1); // 0 ~ stages.Count-1 사이로 제한
            MoveToNextPosition(); // 이전 위치로 이동
        }

        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            OnClickPlayBtn();
        }
    }

    private void MoveToNextPosition()
    {
        // 현재 위치에 해당하는 RectTransform을 리스트에서 가져옴
        RectTransform target = stages[currentIndex];

        // 이동할 RectTransform이 null이 아닌지 확인
        if (target != null)
        {
            MoveToTarget(target);  // 타겟 RectTransform으로 이동
        }
    }

    private void MoveToTarget(RectTransform target)
    {
        // 현재 위치를 가져오고, Y축에 100을 더함
        Vector2 newPosition = target.anchoredPosition;
        newPosition.y += 100;  // Y축 100만큼 더하기

        // 커서의 위치를 설정
        cursor.anchoredPosition = newPosition;  // cursor의 위치를 변경
    }



    public void OnClickPlayBtn()
    {
        Managers.SoundManager.PlaySFX(SFXType.enterStage);
        if (currentIndex == 0)
        {
            SceneManagerEx.LoadScene(SceneType.Town);
        }
        else if (currentIndex == 1)
        {
            SceneManagerEx.LoadScene(SceneType.Stage1);
        }
        else if (currentIndex == 2)
        {
            SceneManagerEx.LoadScene(SceneType.Stage2);
        }
        else if (currentIndex == 3)
        {
            SceneManagerEx.LoadScene(SceneType.Stage3);
        }
    }
}




