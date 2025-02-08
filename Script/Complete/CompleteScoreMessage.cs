using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CompleteScoreMessage : MonoBehaviour
{

    [SerializeField]private TextMeshProUGUI _completeScore;
    // Start is called before the first frame update
    void Start()
    {
        _completeScore.text = GameManager._score + "人が視聴しました";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
