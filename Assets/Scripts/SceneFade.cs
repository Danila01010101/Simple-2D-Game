using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


public class SceneFade : MonoBehaviour
{
    public void FadeIn()
    {
        gameObject.GetComponent<Image>().DOFade(1f, 3f);
    }
    public void FadeOut()
    {
        gameObject.GetComponent<Image>().DOFade(0f, 3f);
    }
}
