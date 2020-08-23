using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    // Variables and References
    public static float scoreValue = 0;
    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "" + scoreValue.ToString();
        Debug.Log(scoreText.text);
        Debug.Log(LaserBeam.groundCount);
    }
}
