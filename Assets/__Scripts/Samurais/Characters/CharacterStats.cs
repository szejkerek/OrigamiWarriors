[System.Serializable]
public class CharacterStats
{
    public int Damage;
    public int Health;
    public int Speed;
    public float CritChance;

    public CharacterStats() { }

    public CharacterStats(int damage, int health, int speed, float critChance)
    {
        Damage = damage;
        Health = health;
        Speed = speed;
        CritChance = critChance;
    }

    public CharacterStats(CharacterStats other)
    {
        Damage = other.Damage;
        Health = other.Health;
        Speed = other.Speed;
        CritChance = other.CritChance;
    }  

    public static CharacterStats operator +(CharacterStats a, CharacterStats b)
    {
        return new CharacterStats(a.Damage + b.Damage, a.Health + b.Health, a.Speed + b.Speed, a.CritChance + b.CritChance);
    }

    public static CharacterStats operator *(CharacterStats a, int level)
    {
        return new CharacterStats(a.Damage * level, a.Health * level, a.Speed * level, a.CritChance * level);
    }
}