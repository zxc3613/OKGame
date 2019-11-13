using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MySlotManager : MonoBehaviour
{
    [SerializeField] GameObject oneSlotList;
    [SerializeField] GameObject twoSlotList;
    [SerializeField] GameObject threeSlotList;
    [SerializeField] GameObject packPanelPrefab;

    [SerializeField] Button imagesButton;

    [SerializeField] RectTransform packPanel;

    [SerializeField] PlayViewManager playViewManager;

    public void OnOneButton()
    {
        oneSlotList.gameObject.SetActive(true);
        twoSlotList.gameObject.SetActive(false);
        threeSlotList.gameObject.SetActive(false);
    }
    public void OnTwoButton()
    {
        oneSlotList.gameObject.SetActive(false);
        twoSlotList.gameObject.SetActive(true);
        threeSlotList.gameObject.SetActive(false);
    }
    public void OnThreeButton()
    {
        oneSlotList.gameObject.SetActive(false);
        twoSlotList.gameObject.SetActive(false);
        threeSlotList.gameObject.SetActive(true);
    }

    public void OnPackOpen()
    {
        PackManager packManager = Instantiate(packPanelPrefab, packPanel).GetComponent<PackManager>();
        ActiveDelete = true;
    }
    private void Start()
    {
        ActiveDelete = false;
    }
    public bool ActiveDelete
    {
        get
        {
            return packPanelPrefab.gameObject.activeSelf;
        }
        set
        {
            packPanelPrefab.gameObject.SetActive(value);

            if (value)
            {
                imagesButton.interactable = true;
            }
            else
            {
                imagesButton.interactable = false;
            }
        }
    }

}
