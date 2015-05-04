using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UISplashFade : MonoBehaviour {

    public float fadeInDelay;
    public float fadeOutDelay;
    
    CanvasRenderer rendererer;
    Image image;

	void Start () {
        image = this.GetComponent<Image>();
        rendererer = this.GetComponent<CanvasRenderer>();
        rendererer.SetAlpha(0.0F);
        DisplayImage(image, fadeInDelay, fadeOutDelay);
	}
	
	void Update () {
        
	}

    private void DisplayImage(Image img, float fadeInDelay, float fadeOutDelay)
    {
        StartCoroutine(DelayedFadeIn(img, fadeInDelay, fadeOutDelay));
    }

    private IEnumerator DelayedFadeIn(Image img, float fadeInDelay, float fadeOutDelay)
    {
        yield return new WaitForSeconds(fadeInDelay);
        img.CrossFadeAlpha(1.0F, 1.0F, false);
        StartCoroutine(DelayedFadeOut(img, fadeOutDelay));
    }

    private IEnumerator DelayedFadeOut(Image img, float delay)
    {
        yield return new WaitForSeconds(delay);
        img.CrossFadeAlpha(0.0F, 1.0F, false);
    }
}
