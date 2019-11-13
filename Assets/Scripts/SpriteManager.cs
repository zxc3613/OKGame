using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    //한번 불러왔던 이미지는 더 안불러 오기 위해 딕셔너리
    private static Dictionary<string, Sprite> cachedSprites = new Dictionary<string, Sprite>();

    public static Sprite[] Load()
    {
        Sprite[] sprites = Resources.LoadAll<Sprite>("Play");
        foreach (Sprite sprite in sprites)
        {
            if (!cachedSprites.ContainsKey(sprite.name))
            {
                cachedSprites.Add(sprite.name, sprite);
            }
        }
        return sprites;
    }
    public static Sprite GetSprite(string name)
    {
        //없을때 불러 오는것
        if (!cachedSprites.ContainsKey(name))
        {
            Sprite sprite = Resources.Load<Sprite>("Play/" + name);
            if (sprite == null) sprite = Resources.Load<Sprite>("Kill/" + name);
            if (sprite == null) sprite = Resources.Load<Sprite>("Defense/" + name);
            if (sprite == null) sprite = Resources.Load<Sprite>("store/" + name);

            if (sprite) cachedSprites.Add(sprite.name, sprite);

            return sprite;
        }
        else
        {
            return cachedSprites[name];
        }
    }
}