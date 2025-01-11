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
    private AudioSource _source;

    void Start()
    {
        _chatButton.GetComponent<Renderer>().material.color = _chatCategoryInfo.CommentBoxColor;
        _buttonCaption.color = _chatCategoryInfo.OprionMessageColor;
        _buttonCaption.text = _chatCategoryInfo.Caption;
        _source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click(){
        if (!GameManager._currentPeriod.Equals(GameManager.Period.COMMENT)){
            return;
        }
        var catCategory = _buttonCaption.text;
        Debug.Log("ChatCategoryButtonAction.Click: "+ catCategory + "　が押されました。");
        // Debug.Log("ChatCategoryButtonAction.Click: カテゴリー　：　"+ GameManager._targetUser.UserName);
        PlayVoice();
        if (_chatCategoryInfo.Category.Equals(GameManager._targetCategory)){
            GameManager.AddScore();
        }
        else {
            GameManager.LostScore();
        }
        GameManager._currentPeriod = GameManager.Period.USER;
    }
    public void PlayVoice(){
        Debug.Log(_chatCategoryInfo.Voice.name);
        _source.clip = _chatCategoryInfo.Voice;
        _source.Play();
    }

}
