using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[SerializeField]
public class ChatCategoryInfo : ScriptableObject
{
    public ChatCategory Category;
    public String Caption;
    public String CommentBoxColroCode;
    public Color CommentBoxColor;
    public String CommentTextColorCode;
    public Color CommentTextColor;
    public String UserNameColorCode;
    public Color UserNameColor;    
    public String OptionMessage;
    public String OprionMessageColorCode;
    public Color OprionMessageColor;
    public String DefaultMessage;
    public AudioClip Voice;
}
