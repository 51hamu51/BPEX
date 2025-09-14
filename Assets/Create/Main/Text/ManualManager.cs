using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualManager : MonoBehaviour
{
    /// <summary>
    /// 詳細の説明
    /// </summary>
    public GameObject detailPanel;

    /// <summary>
    /// 説明OnOffのパネル
    /// </summary>
    public GameObject headerPanel;
    void Start()
    {
        detailPanel.SetActive(true);
        headerPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            detailPanel.SetActive(!detailPanel.active);
            headerPanel.SetActive(!headerPanel.active);
        }
    }
}
