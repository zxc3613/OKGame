using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Images : MonoBehaviour
{
    [SerializeField] GameObject packPanel;
    public Image characterphoto;
    Button imageButton;

    public Sprite characterPhotoSprite
    {
        get { return this.characterphoto.sprite; }
        set { this.characterphoto.sprite = value; }
    }


    private void Start()
    {
        imageButton = GetComponent<Button>();
    }
}
