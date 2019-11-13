using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PackManager : MonoBehaviour, ISlotList
{
    [SerializeField] GameObject slotPrefab;
    private void Start()
    {
        //gameObject.SetActive(false);
    }
    public void OnButton()
    {
        
    }

    public void OnPackButton()
    {
        Destroy(gameObject);
    }

    public void DidSelectSlot(MySlotManager mySlotManager)
    {
        throw new System.NotImplementedException();
    }
}
