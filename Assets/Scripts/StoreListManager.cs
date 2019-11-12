using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreListManager : MonoBehaviour, IImagePanel
{
    Contact contact;
    Contacts? contacts;


    [SerializeField] GameObject popupPanelPrefab;
    [SerializeField] GameObject imagePanelPrefab;


    List<ImagePanel> imagesList = new List<ImagePanel>();

    public delegate void AddContact(Contact contact);
    public AddContact addContactCallback;

    //addContactCallback(contact);
    public Action<Sprite> didSelectImage;

    private void Awake()
    {
        Sprite[] sprites = SpriteManager.Load();
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

    public void DidSelectImagePanel(ImagePanel imagePanel)
    {
        if (contacts.HasValue)
        {
            PopupPanel popupPanel = Instantiate(popupPanelPrefab).GetComponent<PopupPanel>();
            popupPanel.popupDelegate = () =>
            {
                int imageIndex = imagesList.IndexOf(imagePanel);
                List<Contact> contactList = contacts.Value.contactList;
                contactList.Add(imagePanel.GetComponent<Contact>());
            };
        }
    }

    public void OnClose()
    {
        Destroy(gameObject);
    }

}
