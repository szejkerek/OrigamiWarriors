using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SamuraiRenderers
{
    public SpriteRenderer Helmet_B;
    public SpriteRenderer Helmet_F;
    public SpriteRenderer Face_F;
    public SpriteRenderer Head;
    public SpriteRenderer Weapon;
    public SpriteRenderer Chestplate;
    public SpriteRenderer Pants;    
}

[System.Serializable]
public class SamuraiImages
{
    public Image Helmet_B;
    public Image Helmet_F;
    public Image Face_F;
    public Image Head;
    public Image Weapon;
    public Image Chestplate;
    public Image Pants;

    public void SetActive(bool active)
    {
       Helmet_B.gameObject.SetActive(active);
       Helmet_F.gameObject.SetActive(active);
       Face_F.gameObject.SetActive(active);
       Head.gameObject.SetActive(active);
       Weapon.gameObject.SetActive(active);
       Chestplate.gameObject.SetActive(active);
       Pants.gameObject.SetActive(active);
    }
}