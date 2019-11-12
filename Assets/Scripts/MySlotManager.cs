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

        playViewManager.GetComponent<SlotListManager>();
        foreach (Images images in playViewManager.imagesList)
        {
            images.ActiveDelete = true;
        }
    }

}
