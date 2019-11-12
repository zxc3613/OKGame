using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PackManager : MonoBehaviour
{
    private void Start()
    {
        //gameObject.SetActive(false);
    }
    public void OnPackButton()
    {
        Destroy(gameObject);
    }
}
