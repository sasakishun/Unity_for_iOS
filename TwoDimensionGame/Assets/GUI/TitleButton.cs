using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButton : MonoBehaviour {
    Vector3 m_MaxSize = Vector3.one;
    Vector3 m_MinSize = new Vector3(0.5f, 0.5f, 0.5f);//Vector3.zero;
    float m_AngularFrequency = 1.0f;
    float m_Time;

    //void Awake()
    void Start()
    {
        m_Time = 0.0f;
    }

    void Update()
    {
        m_Time += m_AngularFrequency * Time.deltaTime;
        transform.localScale = Vector3.Lerp(m_MinSize, m_MaxSize, 0.5f * Mathf.Sin(m_Time) + 0.5f);
    }

    public void OnClick()
    {
        Debug.Log("Start button click!");
        SceneManager.LoadScene("Playing");
    }
}
