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
    public String UserName;         // ユーザー名
    public AudioClip Voice;         // 音声ファイル
}
