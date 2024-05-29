using UnityEngine;

[System.Serializable]
public class SamuraiVisuals
{
    SamuraiVisualsSO visualsSO;
    public int helmetBIndex;
    public int helmetFIndex;
    public int faceIndex;
    public int headIndex;
    public int weaponIndex;
    public int chestplateIndex;
    public int pantsIndex;

    public SamuraiVisuals(SamuraiVisualsSO visualsSO)
    {
        this.visualsSO = visualsSO;
        Randomize();
    }

    public void Apply(SamuraiRenderers renderer)
    {
        renderer.Helmet_B.sprite = visualsSO.Helmet_B[helmetBIndex];
        renderer.Helmet_F.sprite = visualsSO.Helmet_F[helmetFIndex];
        renderer.Face_F.sprite = visualsSO.Face_F[faceIndex];
        renderer.Head.sprite = visualsSO.Head[headIndex];
        renderer.Weapon.sprite = visualsSO.Weapon[weaponIndex];
        renderer.Chestplate.sprite = visualsSO.Chestplate[chestplateIndex];
        renderer.Pants.sprite = visualsSO.Pants[pantsIndex];
    }

    public void Randomize()
    {
        faceIndex = Random.Range(0, visualsSO.Face_F.Count);
        headIndex = Random.Range(0, visualsSO.Head.Count);
        weaponIndex = Random.Range(0, visualsSO.Weapon.Count);
        chestplateIndex = Random.Range(0, visualsSO.Chestplate.Count);
        pantsIndex = Random.Range(0, visualsSO.Pants.Count);
        helmetBIndex = Random.Range(0, visualsSO.Helmet_B.Count);
        helmetFIndex = Random.Range(0, visualsSO.Helmet_F.Count);
    }
}
