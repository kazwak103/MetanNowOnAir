using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[CreateAssetMenu]
[SerializeField]
public class UserInfo : ScriptableObject
{
    public int id;                  // ID
    public String userName;         // ユーザー名
    public AudioClip audio;         // 音声ファイル
}
