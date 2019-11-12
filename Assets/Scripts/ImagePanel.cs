using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IImagePanel
{
    void DidSelectImagePanel(ImagePanel imagePanel);
}
public class ImagePanel : MonoBehaviour
{
    [SerializeField] Image photoImage;
    public IImagePanel imagePanelDelegate;
 
    public Sprite photoImageSprite
    {
        get { return this.photoImage.sprite; }
        set { this.photoImage.sprite = value; }
    }

    public void OnCilckBuy()
    {
        imagePanelDelegate.DidSelectImagePanel(this);
    }

}
