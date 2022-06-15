using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinCamera : MonoBehaviour
{
    public Shader _replShader;
    private Camera _camera;

    // Start is called before the first frame update
    private void Awake()
    {
        _replShader = Shader.Find("Unlit/Texture");
        _camera = GetComponent<Camera>();

        if(_replShader)
        {
            _camera.SetReplacementShader(_replShader, "RenderType");
        }
    }

    // Update is called once per frame
    private void OnDisable()
    {
        _camera.ResetReplacementShader();
    }
}
