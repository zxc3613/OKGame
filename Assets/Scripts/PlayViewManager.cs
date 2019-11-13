using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayViewManager : MonoBehaviour, IStoreListManager
{
    Contacts? contacts;

    [SerializeField] GameObject imagesPrefab;
    [SerializeField] GameObject storeListPrefab;

    public RectTransform playContent;
    public RectTransform killContent;
    public RectTransform defenseContent;
    public RectTransform storeContent;

    public List<Images> imagesList = new List<Images>();
    public List<Sprite> spriteList = new List<Sprite>();

    List<Contact> spritesListPlay = new List<Contact>();
    List<Contact> spritesListKill = new List<Contact>();
    List<Contact> spritesListDefense = new List<Contact>();
    List<Contact> spritesListStore = new List<Contact>();

    float imageHeight = 160;

    private void Start()
    {
        contacts = FileManager<Contacts>.Load("Kname");
        LoadData();
    }
    void AddListPlay(Contact contact)
    {
        Images images = Instantiate(imagesPrefab, playContent).GetComponent<Images>();
        images.characterPhotoSprite = SpriteManager.GetSprite(contact.photoFileName);

        if (spritesListPlay.Count > 0)
        {
            Contacts contactsValue = contacts.Value;
            playContent.sizeDelta = new Vector2(spritesListPlay.Count * imageHeight, 0);
        }
        else
        {
            playContent.sizeDelta = Vector2.zero;
        }
    }
    void AddListKill(Contact contact)
    {
        Images images = Instantiate(imagesPrefab, killContent).GetComponent<Images>();
        images.characterPhotoSprite = SpriteManager.GetSprite(contact.photoFileName);

        if (spritesListKill.Count > 0)
        {
            Contacts contactsValue = contacts.Value;
            killContent.sizeDelta = new Vector2(spritesListKill.Count * imageHeight, 0);
        }
        else
        {
            killContent.sizeDelta = Vector2.zero;
        }
    }
    void AddListDefense(Contact contact)
    {
        Images images = Instantiate(imagesPrefab, defenseContent).GetComponent<Images>();
        images.characterPhotoSprite = SpriteManager.GetSprite(contact.photoFileName);

        if (spritesListDefense.Count > 0)
        {
            Contacts contactsValue = contacts.Value;
            defenseContent.sizeDelta = new Vector2(spritesListDefense.Count * imageHeight, 0);
        }
        else
        {
            defenseContent.sizeDelta = Vector2.zero;
        }
    }
    void AddListStore(Contact contact)
    {
        Images images = Instantiate(imagesPrefab, storeContent).GetComponent<Images>();
        images.characterPhotoSprite = SpriteManager.GetSprite(contact.photoFileName);

        if (spritesListStore.Count > 0)
        {
            Contacts contactsValue = contacts.Value;
            storeContent.sizeDelta = new Vector2(spritesListStore.Count * imageHeight, 0);
        }
        else
        {
            storeContent.sizeDelta = Vector2.zero;
        }
    }

    void LoadData()
    {
        if (contacts.HasValue)
        {
            Contacts contactsValue = contacts.Value;
            contactsValue.contactList.Sort();

            for (int i = 0; i < contactsValue.contactList.Count; i++)
            {
                AddListPlay(contactsValue.contactList[i]);
                //AddListKill(contactsValue.contactList[i]);
                //AddListDefense(contactsValue.contactList[i]);
                //AddListStore(contactsValue.contactList[i]);
            }
        }
    }
    //높이 재조정
    //void AdjustContent()
    //{
    //    if (contacts.HasValue)
    //    {
    //        Contacts contactsValue = contacts.Value;
    //        content.sizeDelta = new Vector2(contactsValue.contactList.Count * imageHeight, 0);
    //    }
    //    else
    //    {
    //        content.sizeDelta = Vector2.zero;
    //    }
    //}
    public void OnBackButton()
    {
        Destroy(gameObject);
    }

    //추가
    void AddContact(Contact contact, int k)
    {
        if (contacts.HasValue)
        {
            if (k == 1)
            {
                Contacts playContactList = contacts.Value;
                playContactList.contactList.Add(contact);
                spritesListPlay.Add(contact);
            }
            if (k == 2)
            {
                Contacts killContactList = contacts.Value;
                killContactList.contactList.Add(contact);
                spritesListKill.Add(contact);
            }
            if (k == 3)
            {
                Contacts defenseContactList = contacts.Value;
                defenseContactList.contactList.Add(contact);
                spritesListDefense.Add(contact);
            }
            if (k == 4)
            {
                Contacts stroreContactList = contacts.Value;
                stroreContactList.contactList.Add(contact);
                spritesListStore.Add(contact);
            }
        }
        else
        {
            if (k == 1)
            {
                List<Contact> playContactList = new List<Contact>();
                playContactList.Add(contact);
                spritesListPlay.Add(contact);

                contacts = new Contacts(playContactList);
            }
            if (k == 2)
            {
                List<Contact> killContactList = new List<Contact>();
                killContactList.Add(contact);
                spritesListKill.Add(contact);

                contacts = new Contacts(killContactList);
            }
            if (k == 3)
            {
                List<Contact> defenseContactList = new List<Contact>();
                defenseContactList.Add(contact);
                spritesListDefense.Add(contact);

                contacts = new Contacts(defenseContactList);
            }
            if (k == 4)
            {
                List<Contact> stroreContactList = new List<Contact>();
                stroreContactList.Add(contact);
                spritesListStore.Add(contact);

                contacts = new Contacts(stroreContactList);
            }
        }
    }

    public void OnStoreButton()
    {
        StoreListManager storeListManager = Instantiate(storeListPrefab, transform).GetComponent<StoreListManager>();
        storeListManager.storeListDelegate = this;
    }

    public void DidSelectAdd(StoreListManager storeListManager)
    {
        Contact newContact = new Contact();
        newContact.photoFileName = storeListManager.spritesList[storeListManager.h].name;
        AddContact(newContact, storeListManager.j);

        if (storeListManager.j == 1)
        {
            AddListPlay(newContact);
        }
        if(storeListManager.j == 2)
        {
            AddListKill(newContact);
        }
        if(storeListManager.j == 3)
        {
            AddListDefense(newContact);
        }
        if(storeListManager.j == 4)
        {
            AddListStore(newContact);
        }
    }
}
