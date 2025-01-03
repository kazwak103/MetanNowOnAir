using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[SerializeField]
public class CommnetCategoryValue : ScriptableObject
{
    public CommnetCategory Category;
    public String Caption;
    public String CommentBoxColroCode;
    public Color CommentBoxColor;
    public String CommentColorCode;
    public Color CommentColor;
    public String UserNameColorCode;
    public Color UserNameColor;    
    public String OptionMessage;
    public String OprionMessageColorCode;
    public Color OprionMessageColor;
}
