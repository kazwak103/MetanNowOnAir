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
    private int _userId;
    [SerializeField]private TextMeshProUGUI _tmpComment;
    [SerializeField]private TextMeshProUGUI _tmpOptionMsg;
    private CommnetCategory _commentCategory = CommnetCategory.NORMAL;
    [SerializeField]private CommentCategoryList _commentCategoryList;
    private Boolean _isSaidThank = false;

    // Start is called before the first frame update
    void Start()
    {
        // ユーザー名、IDを設定
        var userInfo = _userList.userList[UnityEngine.Random.Range(0, _userList.userList.Count)];
        _tmpUser.text = userInfo.userName;
        _userId = userInfo.id;
        
        // コメントを設定
        _tmpComment.text = _commnetList.list[UnityEngine.Random.Range(0, _commnetList.list.Count)].CommentWord;
        _commentCategory = CommnetCategory.NORMAL;

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
        _userId = commentCtrl._userId;
        _tmpUser.text = commentCtrl._tmpUser.text;
        _tmpUser.color = commentCtrl._tmpUser.color;
        _commentCategory = commentCtrl._commentCategory;
        _tmpOptionMsg.text = commentCtrl._tmpOptionMsg.text;
        _tmpOptionMsg.color = commentCtrl._tmpOptionMsg.color;
        _isSaidThank = commentCtrl._isSaidThank;

    }

    // 新規のコメントを作成する。
    // 主に最新のコメントを作成するのに使用する    
     public void SetComment(CommnetList commnetList, UserList userList, Boolean isSupachaPostable){

        // コメント、ユーザーを設定する
        _tmpComment.text = commnetList.list[UnityEngine.Random.Range(0, commnetList.list.Count)].CommentWord;
        UserInfo userInfo = userList.userList[UnityEngine.Random.Range(0, userList.userList.Count)];
        _userId = userInfo.id;
        _tmpUser.text = userInfo.userName;

        CommnetCategoryValue commnetCategoryValue = _commentCategoryList.GetCommnetCategoryValue(CommnetCategory.NORMAL);
        if (isSupachaPostable) {
            switch (UnityEngine.Random.Range(0,5))
            {
                case 0:
                // スーパーチャット
                commnetCategoryValue = _commentCategoryList.GetCommnetCategoryValue(CommnetCategory.SUPER_CHAT);
                break;
                case 1:
                // 赤スパ
                commnetCategoryValue = _commentCategoryList.GetCommnetCategoryValue(CommnetCategory.SUPER_CHAT_RED);
                break;
                case 2:
                // メンバーシップ登録
                commnetCategoryValue = _commentCategoryList.GetCommnetCategoryValue(CommnetCategory.MEMBERSHIP);
                break;
                case 3:
                // メンバーシップギフト
                commnetCategoryValue = _commentCategoryList.GetCommnetCategoryValue(CommnetCategory.MENBERSHIP_GIFT);
                break;
                default:
                break;
            }
        }

        // 選択されたチケットの種類にあわせて設定する
        _commentBox.GetComponent<Renderer>().material.color = commnetCategoryValue.CommentBoxColor;
        _commentCategory = commnetCategoryValue.category;
        _tmpComment.color = commnetCategoryValue.CommentColor;
        _tmpUser.color = commnetCategoryValue.UserNameColor;
        _tmpOptionMsg.text = commnetCategoryValue.OptionMessage;
        _tmpOptionMsg.color = commnetCategoryValue.OprionMessageColor;
    }

    public CommnetCategory GetCommnetCategory(){
        return _commentCategory;
    }

    public void thank(){
        _isSaidThank = true;
    }

    public Boolean isSaidThank(){
        return _isSaidThank;
    }
}
