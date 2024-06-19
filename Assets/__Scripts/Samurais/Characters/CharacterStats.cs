[System.Serializable]
public class CharacterStats
{
    public int Damage;
    public int MaxHealth;
    public int Armor;
    public float CritChance;

    public CharacterStats() { }

    public CharacterStats(int damage, int maxHealth, int armor, float critChance)
    {
        Damage = damage;
        MaxHealth = maxHealth;
        Armor = armor;
        CritChance = critChance;
    }

    public CharacterStats(CharacterStats other)
    {
        Damage = other.Damage;
        MaxHealth = other.MaxHealth;
        Armor = other.Armor;
        CritChance = other.CritChance;
    }  

    public static CharacterStats operator +(CharacterStats a, CharacterStats b)
    {
        return new CharacterStats(
            a.Damage + b.Damage, 
            a.MaxHealth + b.MaxHealth, 
            a.Armor + b.Armor, 
            a.CritChance + b.CritChance);
    }

    public static CharacterStats operator *(CharacterStats a, int level)
    {
        return new CharacterStats(
            a.Damage * level, 
            a.MaxHealth * level, 
            a.Armor * level, 
            a.CritChance * level);
    }
}