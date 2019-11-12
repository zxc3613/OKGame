using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] GameObject playViewPrefab;
    [SerializeField] RectTransform content;

    public void OnPlayButton()
    {
        Open();
    }

    public void OnStoreButton()
    {

    }

    public void Open()
    {
        PlayViewManager playViewManager = Instantiate(playViewPrefab, content).GetComponent<PlayViewManager>();

    }
}
