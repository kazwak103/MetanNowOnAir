using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public enum Period {
        USER,
        COMMENT,
    }
    static public Period _currentPeriod {get; set;}
    static public UserInfo _targetUser {get; set;}
    static public ChatCategory _targetCategory {get; set;}

    // ユーザーボタン
    [SerializeField]public UserButtonAction _TButton;
    [SerializeField]public UserButtonAction _LButton;
    [SerializeField]public UserButtonAction _RButton;
    [SerializeField]public UserButtonAction _BButton;

    [SerializeField]private List<CommentControl> _commentCtrlList;
    static public CommentControl _targetCtrl {get; set;}
    [SerializeField]private CommnetList _commentList;
    [SerializeField]private UserList _userList;
    [SerializeField]private float _lotateCycle = 2.0F;
    static private float _score = 100;
    [SerializeField]private TextMeshProUGUI _scoreText;
    private float _lastLotateTime = 0.0F;

    static private float DEFOULT_PITCH = 1.0F;
    // Start is called before the first frame update

    static private List<AudioClip> _voiceList = new List<AudioClip>();
    private AudioSource _source;
    void Start()
    {
        _currentPeriod = Period.USER;
        _source = GetComponent<AudioSource>();
        _source.pitch = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // 100人増えるごとにチャットの速度を上げる
        float speedUp = (_score - 100.0F) / 500.0F;
        if (speedUp < 0.0F){
            speedUp = 0.0F;
        }else if (speedUp > 0.5F){
            speedUp = 0.5F;
        }

        if (Time.time > _lastLotateTime + (_lotateCycle - speedUp)){
            Boolean isSupachaPostable = true;
            // コメントをスクロールさせる
            for(int i = 0; i < _commentCtrlList.Count; i++){
                CommentControl ctrl = _commentCtrlList[i];
                // コメントが消えるまでにに反応できなかった場合、ポイントをマイナス
                if (i==0 && !(ctrl._chatCategory.Equals(ChatCategory.NORMAL)) && !(ctrl.IsSaidThank())){
                    Debug.Log("GameManager.Update : スルーしました");
                    LostScore();
                    _currentPeriod = Period.USER;
                }
                // 一番下のコメント以外の場合、次のコメントに書き換える
                if (i < _commentCtrlList.Count-1){
                    ctrl.RotateComment(_commentCtrlList[i+1]);
                    // 通常のコメント　かつ　まだ表示されているスパチャ等にお礼をしていない場合、
                    // スパチャを投げられないようにする。
                    if (!ctrl._chatCategory.Equals(ChatCategory.NORMAL) && !ctrl.IsSaidThank()){
                        isSupachaPostable = false;
                        _targetCtrl = ctrl;
                    } 
                }else{
                    //　一番下のコメントの場合、新しいコメントに書き換える
                    ctrl.SetComment(_commentList, _userList, isSupachaPostable);
                    if (!ctrl._chatCategory.Equals(ChatCategory.NORMAL)){
                        _targetUser = ctrl._userInfo;
                        _targetCategory = ctrl._chatCategory;
                        SetUserButtonCaption(_targetUser.id);
                        _currentPeriod = Period.USER;
                        _targetCtrl = ctrl;
                    }
                }
            }
            _scoreText.text = _score + " 人が視聴中";
            _lastLotateTime = Time.time;
            if (_source is not null && !_source.isPlaying){
                StartCoroutine(PlayVoice());
            }

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
        _score -= 5.0F;
        if (_currentPeriod.Equals(Period.COMMENT)){
            _targetCtrl.Thank();
        }
    }

    static public void AddScore(){
        _score += 5.0F;
        if (_currentPeriod.Equals(Period.COMMENT)){
            _targetCtrl.Thank();
        }
    }

    static public void AddVoiceClip(AudioClip audioClip){
        _voiceList.Add(audioClip);
    }

    private IEnumerator PlayVoice(){
        Debug.Log("GameManager.PlayVoice");
        while (_voiceList.Count > 0){
            _source.clip = _voiceList[0];
            Debug.Log("GameManager.PlayVoice : " + _source.clip.name);
            float addPitch = (float)_voiceList.Count / 100.0F; 
            if (addPitch > 0.05F) {
                addPitch = 0.05F;
            }
            _source.pitch = 1.0F + addPitch;
            _source.Play();
            yield return new WaitWhile(()=>_source.isPlaying);
            _voiceList.Remove(_source.clip);
        }
    }
}
