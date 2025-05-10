using UnityEngine;
using DG.Tweening;

public class Goal : MonoBehaviour
{
    [SerializeField] Transform doorLeft;
    [SerializeField] Transform doorRight;

    bool ballNear = false;

    void Update()
    {
        if (ballNear) return;
        if (Vector3.Distance(transform.position, GameControler.Singleton.BallController.transform.position) < 10f)
        {
            ballNear = true;
            OpenDoors();
        }
    }

    void OpenDoors()
    {
        Vector3 leftEndValue = doorLeft.localEulerAngles;
        leftEndValue.y = 135;
        Vector3 rightEndValue = doorRight.localEulerAngles;
        rightEndValue.y = -135;

        doorLeft.DORotate(leftEndValue, 2f).SetEase(Ease.OutBounce);
        doorRight.DORotate(rightEndValue, 2f).SetEase(Ease.OutBounce);
    }
}