using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PopupPanel : MonoBehaviour
{
    public delegate void PopupDelegate();
    public PopupDelegate popupDelegate;

    Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void OnCilckOK()
    {
        popupDelegate.Invoke();
    }

    public void Close()
    {
        animator.SetTrigger("close");
    }

    public void OnDestroys()
    {
        Destroy(gameObject);
    }
}
