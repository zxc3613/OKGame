using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public interface ISlotList
{
    void DidSelectSlot(MySlotManager mySlotManager);
}
public class MySlotManager : MonoBehaviour
{
    [SerializeField] GameObject oneSlotList;
    [SerializeField] GameObject twoSlotList;
    [SerializeField] GameObject threeSlotList;
    [SerializeField] GameObject packPanelPrefab;

    [SerializeField] Button imagesButton;

    [SerializeField] RectTransform packPanel;

    [SerializeField] PlayViewManager playViewManager;

    public ISlotList slotDelegate;
    public Image slotImage;

    public Sprite SlotImageSprite
    {
        get { return slotImage.sprite; }
        set { this.slotImage.sprite = value; }
    }

    public void OnOneButton()
    {
        oneSlotList.gameObject.SetActive(true);
        twoSlotList.gameObject.SetActive(false);
        threeSlotList.gameObject.SetActive(false);

        slotDelegate.DidSelectSlot(this);
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
        ActiveDelete = true;
        PackManager packManager = Instantiate(packPanelPrefab, packPanel).GetComponent<PackManager>();
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
