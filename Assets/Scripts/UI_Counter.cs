using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Counter : MonoBehaviour
{
    [SerializeField]
    private Text alive;
    [SerializeField]
    private Text dead;
    [SerializeField]
    private Text currentSpeed;
    [SerializeField]
    private Text escaped;

    private int aliveCount = 0;
    private int escapedCount = 0;
    private int deadCount = 0;
    private float speedMult = 1f;

    private void Start()
    {
        currentSpeed.text = speedMult.ToString() + " X";
        dead.text = deadCount.ToString() + " Dead";
        alive.text = aliveCount.ToString() + " Alive";
        escaped.text = escapedCount.ToString() + " Escaped";
    }

    internal void AliveCount(int value)
    {
        aliveCount += value;
        alive.text = aliveCount.ToString() + " Alive";
    }

    internal void DeadCount(int value)
    {
        deadCount += value;
        aliveCount -= value;
        dead.text = deadCount.ToString() + " Dead";
        alive.text = aliveCount.ToString() + " Alive";
    }

    internal void EscapedCount(int value)
    {
        escapedCount += value;
        escaped.text = escapedCount.ToString() + " Escaped";
    }

    internal void SpeedChange(float value)
    {
        speedMult += value;
        currentSpeed.text = speedMult.ToString() + " X";
    }
}
