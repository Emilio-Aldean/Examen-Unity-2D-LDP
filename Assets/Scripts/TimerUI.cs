using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{
    public Text timerText;
    public FallingObjectsManager objectManager;

    void Update()
    {
        timerText.text = "Time: " + Mathf.Ceil(objectManager.timer).ToString();
    }
}

