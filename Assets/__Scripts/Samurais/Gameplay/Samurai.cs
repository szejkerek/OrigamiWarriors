using UnityEngine;

public abstract class Samurai : MonoBehaviour
{
    public Character Character { get; private set; }
    SamuraiStylizer samuraiStylizer;

    public void SetCharacterData(Character character)
    {
        this.Character = character;
        samuraiStylizer = GetComponent<SamuraiStylizer>();
        character.SamuraiVisuals.Apply(samuraiStylizer.Renderers, character);
    }
}
