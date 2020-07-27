using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameScoreManager : MonoBehaviour
{
    public TextMeshProUGUI score;

    void Update()
    {
        score.text = PlatformController.platformContr.platformCount.ToString();
    }
}
