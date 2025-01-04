using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class KeyController : MonoBehaviour
{

    [SerializeField]public UserButtonAction _TButton;
    [SerializeField]public UserButtonAction _LButton;
    [SerializeField]public UserButtonAction _RButton;
    [SerializeField]public UserButtonAction _BButton;
    [SerializeField]private UserList _uList;

    //private bool isClicked = false;

    // Start is called before the first frame update
    void Start()
    {
        // SetUserButtonCaption(-1);
        _TButton._gTmp.text = "";
        _LButton._gTmp.text = "";
        _RButton._gTmp.text = "";
        _BButton._gTmp.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        int userId = -1;
        if (Input.GetKeyDown(KeyCode.A)){
            userId  = _LButton.click();
        }else if (Input.GetKeyDown(KeyCode.D)){
            userId = _RButton.click();
        }else if (Input.GetKeyDown(KeyCode.W)){
            userId = _TButton.click();
        }else if (Input.GetKeyDown(KeyCode.S)){
            userId = _BButton.click();
        }
    }
}
