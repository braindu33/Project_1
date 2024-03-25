using System;
using System.Collections;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animation openAndClose;

    private void Start()
    {
        openAndClose = GetComponent<Animation>();
    }

    public void Play()
    {
        StartCoroutine(PlayAnimation(openAndClose, 3.0f));
    }

    /*public void Stop()
    {
        StopCoroutine(PlayAnimation(openAndClose, 2.0f));
    }*/
    
    public IEnumerator PlayAnimation(Animation anim, float duration)
    {
        anim.Play("OPenDoor");
        yield return new WaitForSeconds(duration);
        anim.Stop();
    }
}