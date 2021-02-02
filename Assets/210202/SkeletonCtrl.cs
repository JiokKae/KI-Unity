using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SkeletonCtrl : MonoBehaviour
{
    public float colorH;
	public Renderer renderer;
    public float colorV = 18.75f;
    public bool RGBmode;
    [SerializeField]ParticleSystem swordEffect;

    void Start()
    {
    }

    void Update()
    {
        if(RGBmode)
		{
            colorH += Time.deltaTime * 200f;
            if (colorH >= 360f)
                colorH -= 360f;

            Color newColor = Color.HSVToRGB(colorH / 360f, 0.87f, colorV, true);
            renderer.materials[0].SetColor("_EmissionColor2", newColor);

            Color gradColor = Color.HSVToRGB((colorH - 30) / 360f, 0.87f, 1f);
            Color tailColor = new Color(1f, 1f, 1f, 0.6f);

            Gradient grad = new Gradient();
            grad.SetKeys(
                new GradientColorKey[] { new GradientColorKey(gradColor, 0.0f), new GradientColorKey(tailColor, 1.0f) },
                new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.6f, 1.0f) }
                );

            var col = swordEffect.colorOverLifetime;
            col.color = grad;
        }
		else
		{
            renderer.materials[0].SetColor("_EmissionColor2", new Color(18.0f, 0.3f, 0.3f));
        }
    }

    void RGB()
	{
        RGBmode = true;
	}
}

