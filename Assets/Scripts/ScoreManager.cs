using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update

    public static ScoreManager instance;

    private int score = 0;
    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void  ChangeScore(int value)
    {
        score += value;
        Debug.Log("Current Score: " + score);
    }
}
