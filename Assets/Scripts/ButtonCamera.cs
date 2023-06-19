using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCamera : MonoBehaviour
{
    [SerializeField] private Image renderTarget;
    [SerializeField] private Material cameraRenderMaterial;
    [SerializeField] private RenderTexture renderTexture;
    void Start()
    {
        Camera cam = GetComponent<Camera>();
        Material mat = new Material(cameraRenderMaterial);
        RenderTexture texture = new RenderTexture(renderTexture);
        
        mat.mainTexture = texture;
        cam.targetTexture = texture;
        renderTarget.material = mat;

    }

}
