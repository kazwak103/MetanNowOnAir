using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class CommentCategoryButton : MonoBehaviour
{
    [SerializeField]private CommnetCategoryValue _category;
    [SerializeField]private GameObject _gObj;
    [SerializeField]private TextMeshProUGUI _tmp;
    // Start is called before the first frame update
    void Start()
    {
        _gObj.GetComponent<Renderer>().material.color = _category.CommentBoxColor;
        _tmp.color = _category.CommentColor;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
