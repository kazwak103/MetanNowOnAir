using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class CommentCategoryButton : MonoBehaviour
{
    [SerializeField]private CommnetCategoryValue _category;
    [SerializeField]private GameObject _commentBoard;
    [SerializeField]private TextMeshProUGUI _buttonCaption;
    // Start is called before the first frame update
    void Start()
    {
        _commentBoard.GetComponent<Renderer>().material.color = _category.CommentBoxColor;
        _buttonCaption.color = _category.OprionMessageColor;
        _buttonCaption.text = _category.Caption;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
