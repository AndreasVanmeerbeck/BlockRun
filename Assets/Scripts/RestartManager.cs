using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartManager : MonoBehaviour
{

    private UIManager _uiManager;
    CanvasGroup retry;

    // Start is called before the first frame update
    void Start()
    {
        retry = GameObject.Find("Retry").GetComponent<CanvasGroup>();
        retry.transform.position = new Vector3(-1000, 0, 0);
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        retry = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_uiManager._gameOver == true)
        {
            transform.position = new Vector3(722, 1282, 0);

        }
    }
}
