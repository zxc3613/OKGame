using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayViewManager : MonoBehaviour
{
    Contacts? contacts;

    [SerializeField] GameObject imagesPrefab;
    [SerializeField] GameObject storeListPrefab;
    [SerializeField] RectTransform content;
    public List<Images> imagesList = new List<Images>();
    float imageHeight = 160;

    void AddList(Contact contact, int index)
    {
        Images images = Instantiate(imagesPrefab).GetComponent<Images>();

        images.characterPhotoSprite = SpriteManager.GetSprite(contact.photoFileName);
        imagesList.Add(images);
    }

    //높이 재조정
    void AdjustContent()
    {
        if (contacts.HasValue)
        {
            Contacts contactsValue = contacts.Value;
            content.sizeDelta = new Vector2(contactsValue.contactList.Count * imageHeight, 0);
        }
        else
        {
            content.sizeDelta = Vector2.zero;
        }
    }
    public void OnBackButton()
    {
        Destroy(gameObject);
    }

    public void OnStoryButton()
    {

    }
    //추가
    void AddContact(Contact contact)
    {
        if (contacts.HasValue)
        {
            Contacts contactsValue = contacts.Value;
            contactsValue.contactList.Add(contact);
        }
        else
        {
            List<Contact> contactsList = new List<Contact>();
            contactsList.Add(contact);

            contacts = new Contacts(contactsList);
        }
    }
    public void OnStoreButton()
    {
        StoreListManager storeListManager = Instantiate(storeListPrefab, transform).GetComponent<StoreListManager>();
    }

}
