using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuCursol : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x, 0.65F, 0.0F);        
    }

    // Update is called once per frame
    void Update()
    {
        // メニューカーソルの移動
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            transform.position = new Vector3(transform.position.x, 0.65F, 0.0F);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            transform.position = new Vector3(transform.position.x, -0.8F, 0.0F);
        }
        else if (Input.GetKeyDown(KeyCode.Space)) {
            SceneManager.LoadScene("GameScene");
        }
    }
}
