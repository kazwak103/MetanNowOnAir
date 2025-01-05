using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class ChatCategoryButtonAction : MonoBehaviour
{
    [SerializeField]private ChatCategoryInfo _chatCategoryInfo;
    [SerializeField]private GameObject _chatButton;
    [SerializeField]private TextMeshProUGUI _buttonCaption;
    // Start is called before the first frame update
    void Start()
    {
        _chatButton.GetComponent<Renderer>().material.color = _chatCategoryInfo.CommentBoxColor;
        _buttonCaption.color = _chatCategoryInfo.OprionMessageColor;
        _buttonCaption.text = _chatCategoryInfo.Caption;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
