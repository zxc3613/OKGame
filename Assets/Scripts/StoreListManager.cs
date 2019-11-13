using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IStoreListManager
{
    void DidSelectAdd(StoreListManager storeListManager);
}
public class StoreListManager : MonoBehaviour, IImagePanel
{
    Contact contact;
    Contacts? contacts;
    Sprite[] sprites;
    IStoreListManager storeListDelegate;

    [Header("Prefab")]
    [SerializeField] GameObject popupPanelPrefab;
    [SerializeField] GameObject imagePanelPrefab;
    [SerializeField] GameObject playViewManagerprefab;
    [SerializeField] GameObject imagesPrefab;
    [Header("ScrollView")]
    [SerializeField] GameObject playScrollView;
    [SerializeField] GameObject killScrollView;
    [SerializeField] GameObject defenseScrollView;
    [SerializeField] GameObject storeScrollView;
    [Header("Content")]
    [SerializeField] RectTransform playContent;
    [SerializeField] RectTransform killContent;
    [SerializeField] RectTransform defenseContent;
    [SerializeField] RectTransform storeContent;

    float imageHeight = 250;
    List<Sprite> spritesListPlay = new List<Sprite>();
    List<Sprite> spritesListKill = new List<Sprite>();
    List<Sprite> spritesListDefense = new List<Sprite>();
    List<Sprite> spritesListStore = new List<Sprite>();

    List<Sprite> spritesList = new List<Sprite>();
    List<ImagePanel> imagesList = new List<ImagePanel>();

    public delegate void AddContact(Contact contact);
    public AddContact addContactCallback;

    //addContactCallback(contact);
    public Action<Sprite> didSelectImage;

    private void Awake()
    {
        sprites = Resources.LoadAll<Sprite>("Play");
        AddImagePlay();
        sprites = Resources.LoadAll<Sprite>("kill");
        AddImageKill();
        sprites = Resources.LoadAll<Sprite>("Defense");
        AddImageDefense();
        sprites = Resources.LoadAll<Sprite>("Store");
        AddImageStore();

        playScrollView.SetActive(false);
        killScrollView.SetActive(false);
        defenseScrollView.SetActive(false);
        storeScrollView.SetActive(false);
    }
    public void AddImagePlay()
    {
        for (int i = 0; i < sprites.Length; i++)
        {
            ImagePanel imagePanel = Instantiate(imagePanelPrefab, playContent).GetComponent<ImagePanel>();
            imagePanel.photoImageSprite = sprites[i];
            imagePanel.imagePanelDelegate = this;
            spritesListPlay.Add(sprites[i]);
            imagesList.Add(imagePanel);
            spritesList.Add(sprites[i]);
        }

        if (spritesListPlay.Count > 0)
        {
            playContent.sizeDelta = new Vector2(0, spritesListPlay.Count / 2 * imageHeight + spritesListPlay.Count % 2 * imageHeight);
        }
        else playContent.sizeDelta = Vector2.zero;
    }
    public void AddImageKill()
    {
        for (int i = 0; i < sprites.Length; i++)
        {
            ImagePanel imagePanel = Instantiate(imagePanelPrefab, killContent).GetComponent<ImagePanel>();
            imagePanel.photoImageSprite = sprites[i];
            imagePanel.imagePanelDelegate = this;
            spritesListKill.Add(sprites[i]);
            imagesList.Add(imagePanel);
            spritesList.Add(sprites[i]);
        }

        if (spritesListKill.Count > 0)
        {
            killContent.sizeDelta = new Vector2(0, spritesListKill.Count / 2 * imageHeight + spritesListKill.Count % 2 * imageHeight);
        }
        else killContent.sizeDelta = Vector2.zero;
    }
    public void AddImageDefense()
    {
        for (int i = 0; i < sprites.Length; i++)
        {
            ImagePanel imagePanel = Instantiate(imagePanelPrefab, defenseContent).GetComponent<ImagePanel>();
            imagePanel.photoImageSprite = sprites[i];
            imagePanel.imagePanelDelegate = this;
            spritesListDefense.Add(sprites[i]);
            imagesList.Add(imagePanel);
            spritesList.Add(sprites[i]);
        }

        if (spritesListDefense.Count > 0)
        {
            defenseContent.sizeDelta = new Vector2(0, spritesListDefense.Count / 2 * imageHeight + spritesListDefense.Count % 2 * imageHeight);
        }
        else defenseContent.sizeDelta = Vector2.zero;
    }
    public void AddImageStore()
    {
        for (int i = 0; i < sprites.Length; i++)
        {
            ImagePanel imagePanel = Instantiate(imagePanelPrefab, storeContent).GetComponent<ImagePanel>();
            imagePanel.photoImageSprite = sprites[i];
            imagePanel.imagePanelDelegate = this;
            spritesListStore.Add(sprites[i]);
            imagesList.Add(imagePanel);
            spritesList.Add(sprites[i]);
        }

        if (spritesListStore.Count > 0)
        {
            storeContent.sizeDelta = new Vector2(0, spritesListStore.Count / 2 * imageHeight + spritesListStore.Count % 2 * imageHeight);
        }
        else storeContent.sizeDelta = Vector2.zero;
    }

    public void OnPlayButton()
    {
        playScrollView.SetActive(true);
        killScrollView.SetActive(false);
        defenseScrollView.SetActive(false);
        storeScrollView.SetActive(false);
    }
    public void OnKillButton()
    {
        playScrollView.SetActive(false);
        killScrollView.SetActive(true);
        defenseScrollView.SetActive(false);
        storeScrollView.SetActive(false);
    }
    public void OnDefenseButton()
    {
        playScrollView.SetActive(false);
        killScrollView.SetActive(false);
        defenseScrollView.SetActive(true);
        storeScrollView.SetActive(false);
    }
    public void OnStoreButton()
    {
        playScrollView.SetActive(false);
        killScrollView.SetActive(false);
        defenseScrollView.SetActive(false);
        storeScrollView.SetActive(true);
    }









    void LoadData()
    {
        if (contacts.HasValue)
        {
            Contacts contactsValue = contacts.Value;

            // 정렬
            contactsValue.contactList.Sort();

            for (int i = 0; i < contactsValue.contactList.Count; i++)
            {
                AddList(contactsValue.contactList[i], i);
            }
        }
    }

    void AddList(Contact contact, int index)
    {
        ImagePanel imagePanel = Instantiate(imagePanelPrefab).GetComponent<ImagePanel>();
        imagePanel.photoImageSprite = SpriteManager.GetSprite(contact.photoFileName);
        imagePanel.imagePanelDelegate = this;
        imagesList.Add(imagePanel);
    }
    [HideInInspector] public int h;
    public void DidSelectImagePanel(ImagePanel imagePanel)
    {
        if (playScrollView.activeSelf == true)
        {
            int imageIndex = imagesList.IndexOf(imagePanel);

            PopupPanel popupPanel = Instantiate(popupPanelPrefab, transform).GetComponent<PopupPanel>();
            popupPanel.Open();
            popupPanel.popupDelegate = () =>
            {
                h = imagesList.IndexOf(imagePanel);
                storeListDelegate.DidSelectAdd(this);
                popupPanel.Close();
                //////////////여기까지 했음///////////////////////////////////// 인터페이스 연결 해야됌.
                //PlayViewManager playViewManager = playViewManagerprefab.GetComponent<PlayViewManager>();
                //playViewManager = Instantiate(imagesPrefab, playViewManager.content).GetComponent<PlayViewManager>();
                //playViewManager.GetComponent<Image>().sprite = spritesList[imageIndex];
                //List<Contact> contactList = contacts.Value.contactList;
                //contactList.Add(imagePanel.GetComponent<Contact>());
            };
        }

    }

    public void OnClose()
    {
        Destroy(gameObject);
    }

}
