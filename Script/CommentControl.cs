using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CommentControl : MonoBehaviour
{
    [SerializeField]private GameObject _commentBox;
    [SerializeField]private CommnetList _commnetList;
    [SerializeField]private UserList _userList;
    [SerializeField]private TextMeshProUGUI _tmpUser;
    public UserInfo _userInfo {get; set;}
    [SerializeField]private TextMeshProUGUI _tmpComment;
    [SerializeField]private TextMeshProUGUI _tmpOptionMsg;
    public ChatCategory _chatCategory {get; set;}= ChatCategory.NORMAL;
    [SerializeField]private ChatCategoryList _chatCategoryList;
    private bool _isSaidThank = false;
    

    // Start is called before the first frame update
    void Start()
    {
        // ユーザー名、IDを設定
        var userInfo = _userList.userList[UnityEngine.Random.Range(0, _userList.userList.Count)];
        _tmpUser.text = userInfo.UserName;
        
        // コメントを設定
        _tmpComment.text = _commnetList.list[UnityEngine.Random.Range(0, _commnetList.list.Count)].CommentWord;
        _chatCategory = ChatCategory.NORMAL;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 渡されたコメントの内容に書き換える
    // コメントをスクロールさせるために使用する
    public void RotateComment(CommentControl commentCtrl ){

        // １つ前のコメントの設定をこのコメントに設定する
        _commentBox.GetComponent<Renderer>().material.color = commentCtrl.GetComponent<Renderer>().material.color;
        _tmpComment.text =commentCtrl._tmpComment.text;
        _tmpComment.color = commentCtrl._tmpComment.color;
        _userInfo = commentCtrl._userInfo;
        _tmpUser.text = commentCtrl._tmpUser.text;
        _tmpUser.color = commentCtrl._tmpUser.color;
        _chatCategory = commentCtrl._chatCategory;
        _tmpOptionMsg.text = commentCtrl._tmpOptionMsg.text;
        _tmpOptionMsg.color = commentCtrl._tmpOptionMsg.color;
        _isSaidThank = commentCtrl._isSaidThank;

    }

    // 新規のコメントを作成する。
    // 主に最新のコメントを作成するのに使用する    
     public void SetComment(CommnetList commnetList, UserList userList, Boolean isSupachaPostable){

        // コメント、ユーザーを設定する
        _tmpComment.text = commnetList.list[UnityEngine.Random.Range(0, commnetList.list.Count)].CommentWord;
        _userInfo = userList.userList[UnityEngine.Random.Range(0, userList.userList.Count)];
        _tmpUser.text = _userInfo.UserName;

        ChatCategoryInfo chatCategoryInfo = _chatCategoryList.GetChatCategoryInfo(ChatCategory.NORMAL);
        if (isSupachaPostable) {
            switch (UnityEngine.Random.Range(0,4))
            {
                case 0:
                // スーパーチャット
                chatCategoryInfo = _chatCategoryList.GetChatCategoryInfo(ChatCategory.SUPER_CHAT);
                break;
                case 1:
                // 赤スパ
                chatCategoryInfo = _chatCategoryList.GetChatCategoryInfo(ChatCategory.SUPER_CHAT_RED);
                break;
                case 2:
                // メンバーシップ登録
                chatCategoryInfo = _chatCategoryList.GetChatCategoryInfo(ChatCategory.MEMBERSHIP);
                break;
                case 3:
                // メンバーシップギフト
                chatCategoryInfo = _chatCategoryList.GetChatCategoryInfo(ChatCategory.MENBERSHIP_GIFT);
                break;
                default:
                break;
            }
        }
        Debug.Log("チャットのカテゴリー : " + chatCategoryInfo.Caption);

        // 選択されたチャットのカテゴリーにあわせて設定する
        _commentBox.GetComponent<Renderer>().material.color = chatCategoryInfo.CommentBoxColor;
        _chatCategory = chatCategoryInfo.Category;
        _tmpComment.color = chatCategoryInfo.CommentTextColor;
        _tmpUser.color = chatCategoryInfo.UserNameColor;
        _tmpOptionMsg.text = chatCategoryInfo.OptionMessage;
        _tmpOptionMsg.color = chatCategoryInfo.OprionMessageColor;

        //デフォルトメッセージが設定されている場合は書き換える
        if (!String.IsNullOrEmpty(chatCategoryInfo.DefaultMessage)){
            _tmpComment.text = chatCategoryInfo.DefaultMessage;
        }
    }

    public void Thank(){
        _isSaidThank = true;
    }

    public bool IsSaidThank(){
        return _isSaidThank;
    }

    public int GetPoint(int userId){
        int point = 0;
        if (userId == _userInfo.id && _isSaidThank){
            return 100;
        }
        return point;
    }
}
