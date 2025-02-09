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

    public void Click(){
        if (!GameManager._current._currentPeriod.Equals(GameManager.CurrentStatus.Period.COMMENT)){
            return;
        }
        var catCategory = _buttonCaption.text;
        Debug.Log("ChatCategoryButtonAction.Click: "+ catCategory + "　が押されました。");
        GameManager.AddVoiceClip(_chatCategoryInfo.Voice);

        GameManager._current._selectedCategory = _chatCategoryInfo.Category;
        GameManager._current._currentPeriod = GameManager.CurrentStatus.Period.JUDGEMENT;
    }
}
