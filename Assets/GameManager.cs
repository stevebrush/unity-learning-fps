using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        Application.targetFrameRate = 30;
        QualitySettings.vSyncCount = 0;
    }
}
