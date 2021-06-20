using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TextBehavior : MonoBehaviour
{
    void Start()
    {
        FadeIn();
    }

    public void FadeIn()
    {
        gameObject.GetComponent<Text>().DOFade(1f, 3f);
    }
    public void FadeOut()
    {

        gameObject.GetComponent<Text>().DOFade(0f, 3f);
    }
}
