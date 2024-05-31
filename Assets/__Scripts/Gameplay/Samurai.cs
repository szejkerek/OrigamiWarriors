using UnityEngine;

public abstract class Samurai : MonoBehaviour
{
    public Character Character { get; private set; }
    SamuraiStylizer samuraiStylizer;

    private void Awake()
    {
        samuraiStylizer = GetComponent<SamuraiStylizer>();
    }

    public void SetCharacterData(Character character)
    {
        this.Character = character; 
        character.SamuraiVisuals.Apply(samuraiStylizer.Renderers, character);
    }
}
