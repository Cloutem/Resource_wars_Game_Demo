using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Scenes_Manager : MonoBehaviour
{
    public static Scenes_Manager instance;
    public GameObject Deck;
    Image GuoDu;
    AsyncOperation asyncScene;
    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
        if (transform.GetChild(0).GetComponent<Image>() == null)
        {
            Debug.LogError("请将创建一个拥有Image组件的对象并将它放在场景管理器的顺序的第一个");
            return;
        }
        GuoDu = transform.GetChild(0).GetComponent<Image>();
    }
    void Start()
    {
        GuoDu.color = Color.clear;
    }
    void Update()
    {
        if (asyncScene != null)
        {
            if (asyncScene.progress >= 0.8)
            {
                asyncScene.allowSceneActivation = true;
                asyncScene = null;
                GuoDu.DOColor(new Color(0, 0, 0, 0), 1f).OnComplete(() => { GuoDu.enabled = false; });
            }
            else
            {
                DOTween.KillAll(true);
                DOTween.Clear(true);
            }
        }
    }
        
    public void Jump_Scenes(int index)
    {
        GuoDu.enabled = true;
        GuoDu.color = new Color(0,0,0,0);
        GuoDu.DOColor(new Color(0, 0, 0, 1), 1f).OnComplete(() => {
            asyncScene = SceneManager.LoadSceneAsync(index);
            asyncScene.allowSceneActivation = false;
        });
    }
}
