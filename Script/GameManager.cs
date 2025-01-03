using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]private List<CommentControl> _commentCtrlList;
    [SerializeField]private CommnetList _commentList;
    [SerializeField]private UserList _userList;
    [SerializeField]private float _lotateCycle = 2.0F;
    private float _lastLotateTime = 0.0F;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(Time.time + " : " + _lastLotateTime + " : " + _lotateCycle);
        if (Time.time > _lastLotateTime + _lotateCycle){
            // コメントをスクロールさせる
            for(int i = 0; i < _commentCtrlList.Count; i++){
                CommentControl ctrl = _commentCtrlList[i];
                // 一番下のコメント以外の場合、次のコメントに書き換える
                if (i < _commentCtrlList.Count-1){
                    ctrl.RotateComment(_commentCtrlList[i+1]);

                }else{
                    //　一番下のコメントの場合、新しいコメントに書き換える
                    ctrl.SetComment(_commentList, _userList);
                }
            }
            _lastLotateTime = Time.time;
        }
    }
}
