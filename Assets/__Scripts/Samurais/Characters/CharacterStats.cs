[System.Serializable]
public class CharacterStats
{
    public int Damage;
    public int MaxHealth;
    public int Speed;
    public float CritChance;

    public CharacterStats() { }

    public CharacterStats(int damage, int maxHealth, int speed, float critChance)
    {
        Damage = damage;
        MaxHealth = maxHealth;
        Speed = speed;
        CritChance = critChance;
    }

    public CharacterStats(CharacterStats other)
    {
        Damage = other.Damage;
        MaxHealth = other.MaxHealth;
        Speed = other.Speed;
        CritChance = other.CritChance;
    }  

    public static CharacterStats operator +(CharacterStats a, CharacterStats b)
    {
        return new CharacterStats(a.Damage + b.Damage, a.MaxHealth + b.MaxHealth, a.Speed + b.Speed, a.CritChance + b.CritChance);
    }

    public static CharacterStats operator *(CharacterStats a, int level)
    {
        return new CharacterStats(a.Damage * level, a.MaxHealth * level, a.Speed * level, a.CritChance * level);
    }
}