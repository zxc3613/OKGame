using System.Collections.Generic;
using System;

public struct Contacts
{
    public List<Contact> contactList;
    public List<Contact> contactLists;
    public List<Contact> contactListss;
    public List<Contact> contactListsss;
    public Contacts(List<Contact> contacts)
    {
        this.contactList = contacts;
        this.contactLists = contacts;
        this.contactListss = contacts;
        this.contactListsss = contacts;
    }
}

[System.Serializable]
public struct Contact : IComparable<Contact>
{
    public string name;
    public string photoFileName;

    public int CompareTo(Contact other)
    {
        return this.name.CompareTo(other.name);
    }
}
