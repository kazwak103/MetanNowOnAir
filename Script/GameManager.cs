using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    public enum Period {
        USER,
        COMMENT,
    }
    static public Period _currentPeriod {get; set;}
    static public UserInfo _targetUser {get; set;}

    // ユーザーボタン
    [SerializeField]public UserButtonAction _TButton;
    [SerializeField]public UserButtonAction _LButton;
    [SerializeField]public UserButtonAction _RButton;
    [SerializeField]public UserButtonAction _BButton;

    [SerializeField]private List<CommentControl> _commentCtrlList;
    [SerializeField]private CommnetList _commentList;
    [SerializeField]private UserList _userList;
    [SerializeField]private float _lotateCycle = 2.0F;
    static private int score = 100;
    [SerializeField]private TextMeshProUGUI _scoreText;
    private float _lastLotateTime = 0.0F;
    // Start is called before the first frame update
    void Start()
    {
        _currentPeriod = Period.USER;
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(Time.time + " : " + _lastLotateTime + " : " + _lotateCycle);
        if (Time.time > _lastLotateTime + _lotateCycle){
            Boolean isSupachaPostable = true;
            // コメントをスクロールさせる
            for(int i = 0; i < _commentCtrlList.Count; i++){
                CommentControl ctrl = _commentCtrlList[i];
                // コメントが消えるまでにに反応できなかった場合、ポイントをマイナス
                if (i==0 && !(ctrl.GetCommnetCategory().Equals(CommnetCategory.NORMAL)) && !(ctrl.isSaidThank())){
                    Debug.Log("GameManager.Update : スルーしました");
                    LostScore();
                    _currentPeriod = Period.USER;
                }
                // 一番下のコメント以外の場合、次のコメントに書き換える
                if (i < _commentCtrlList.Count-1){
                    ctrl.RotateComment(_commentCtrlList[i+1]);
                    if (!ctrl.GetCommnetCategory().Equals(CommnetCategory.NORMAL) && !ctrl.isSaidThank()){
                        isSupachaPostable = false;
                    }
                }else{
                    //　一番下のコメントの場合、新しいコメントに書き換える
                    UserInfo userInfo = ctrl.SetComment(_commentList, _userList, isSupachaPostable);
                    if (!ctrl.GetCommnetCategory().Equals(CommnetCategory.NORMAL)){
                        _targetUser = userInfo;
                        SetUserButtonCaption(_targetUser.id);
                        _currentPeriod = Period.USER;
                    }
                }
            }
            _scoreText.text = score + " 人が視聴中";
            _lastLotateTime = Time.time;
        }
    }

    // ユーザーボタンにユーザー情報を設定する
    private void SetUserButtonCaption(int userId){
        Debug.Log("GameManager.SetUserButtonCaption: userId："+userId);
        UserButtonAction[] ubList = {_TButton, _LButton, _RButton, _BButton};
        List<int> selected = new List<int>();
        foreach(UserButtonAction act in ubList){
            int buttonUserId = -1;
            int index = -1;
            // ユーザーが重複しないようにする
            do {
                index = UnityEngine.Random.Range(0,_userList.userList.Count);
                buttonUserId = _userList.userList[index].id;
            } while(selected.Contains(buttonUserId));
            selected.Add(buttonUserId);
            act.SetUserInfo(_userList.userList[index]);
        }
        // コメントしたユーザーのIDが設定されていなかった場合、
        // どれか一つのボタンを書き換える
        if (!selected.Contains(userId)){
            Debug.Log("GameManager.SetUserButtonCaption: 書き換え：" + _userList.userList.Find(u=>u.id==userId).UserName);
            UserButtonAction act = ubList[UnityEngine.Random.Range(0,ubList.Length)];
            act.SetUserInfo(_userList.userList.Find(u=>u.id==userId));
        }
    }

    static public void LostScore(){
        score -= 5;
    }

    static public void AddScore(){
        score += 10;
    }
    
}
