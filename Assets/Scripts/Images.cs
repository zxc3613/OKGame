using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Images : MonoBehaviour
{
    [SerializeField] GameObject packPanel;
    Image characterphoto;
    Button imageButton;

    public Sprite characterPhotoSprite
    {
        get { return this.characterphoto.sprite; }
        set { this.characterphoto.sprite = value; }
    }

    public bool ActiveDelete
    {
        get
        {
            return packPanel.gameObject.activeSelf;
        }
        set
        {
            packPanel.gameObject.SetActive(value);

            if (value)
            {
                imageButton.interactable = true;
            }
            else
            {
                imageButton.interactable = false;
            }
        }
    }
    private void Start()
    {
        imageButton = GetComponent<Button>();
        this.ActiveDelete = false;
    }
}
