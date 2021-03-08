using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static TMPro.TextMeshPro;

public class DisplayFPS : MonoBehaviour
{
    public int Fps { get; private set; }
    public TMP_Text fpsText;
    private float _interval = 0;
    
    private void Awake()
    {
#if UNITY_EDITOR
        Debug.unityLogger.logEnabled = false;
#else
                Debug.unityLogger.logEnabled=false;
#endif
        Application.targetFrameRate = 60;
    }
    
    private void Update()
    {
        _interval += Time.deltaTime;
        if (!(_interval > 2)) return;
        Fps = (int)(1f / Time.unscaledDeltaTime);
        fpsText.text = "FPS: "+ Fps.ToString();
        _interval = 0;
    }
}
