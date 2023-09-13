using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakEffect : MonoBehaviour
{
    public ParticleSystem particle;

    public Sprite targetSprite;
        
    private void Start()
    {
        if (!targetSprite.texture.isReadable) { Debug.LogError("Sprite texture is not readable, please enable Read/Write Enabled in the Texture Import Settings."); }
    }

    public void Break()
    {
        var t = targetSprite.texture;

        int x = Mathf.FloorToInt(targetSprite.textureRect.x);
        int y = Mathf.FloorToInt(targetSprite.textureRect.y);
        int width = Mathf.FloorToInt(targetSprite.textureRect.width);
        int height = Mathf.FloorToInt(targetSprite.textureRect.height);

        var pixels = t.GetPixels(x, y, width, height);
        int pixelCounter = 0;
        var emitParams = new ParticleSystem.EmitParams();
        emitParams.startSize = 0.06f;

        for (int i = 0; i < targetSprite.texture.height; i++)
        {
            for (int o = 0; o < targetSprite.texture.width; o++)
            {
                emitParams.startColor = pixels[pixelCounter];
                emitParams.position = new Vector3(o * 0.06f, i * 0.06f, 0);
                particle.Emit(emitParams, 1);
                pixelCounter++;
            }
        }

        particle.Play();
    }
}
