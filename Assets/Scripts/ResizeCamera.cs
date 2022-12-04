using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeCamera : MonoBehaviour
{
    private float DesignOrthographicSize;
    private float DesignAspect;
    private float DesignWidth;

    private float wantedSize;

    public void Awake()
    {
        DesignOrthographicSize = Camera.main.orthographicSize;
        DesignAspect = 1920f / 1080f;
        DesignWidth = DesignOrthographicSize * DesignAspect;

        if(Camera.main.aspect < DesignAspect)
            Resize();
    }

    public void Resize()
    {
        wantedSize = Mathf.CeilToInt(DesignWidth / Camera.main.aspect) ;
        Camera.main.orthographicSize = wantedSize;
    }

}
