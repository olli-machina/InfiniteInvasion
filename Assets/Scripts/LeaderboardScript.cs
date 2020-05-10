using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardScript : MonoBehaviour
{
    public Text first, second, third, fourth, fifth, sixth, seventh, eighth, ninth, tenth;

    // Start is called before the first frame update
    void Start()
    {
        first.text = GameManager.singleton.highScores[0].ToString();
        second.text = GameManager.singleton.highScores[1].ToString();
        third.text = GameManager.singleton.highScores[2].ToString();
        fourth.text = GameManager.singleton.highScores[3].ToString();
        fifth.text = GameManager.singleton.highScores[4].ToString();
        sixth.text = GameManager.singleton.highScores[5].ToString();
        seventh.text = GameManager.singleton.highScores[6].ToString();
        eighth.text = GameManager.singleton.highScores[7].ToString();
        ninth.text = GameManager.singleton.highScores[8].ToString();
        tenth.text = GameManager.singleton.highScores[9].ToString();
    }
}
