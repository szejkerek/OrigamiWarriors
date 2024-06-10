using UnityEngine;
using UnityEngine.TextCore.Text;

public abstract class Samurai : MonoBehaviour
{
    public Character Character { get; private set; }
    SamuraiStylizer samuraiStylizer;
    SamuraiEffectsManager samuraiEffectsManager;

    public void SetCharacterData(Character character)
    {
        this.Character = character;
    }

    private void Start()
    {
        samuraiStylizer = GetComponent<SamuraiStylizer>();
        samuraiEffectsManager = GetComponent<SamuraiEffectsManager>();
        Character.SamuraiVisuals.Apply(samuraiStylizer.Renderers, Character);
        samuraiEffectsManager.Initialize(Character);
    }
}
