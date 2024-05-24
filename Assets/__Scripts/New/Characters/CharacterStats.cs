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

    public string DisplayText()
    {
        return $"Damage: {Damage}\n" +
               $"Health: {Health}\n" +
               $"Crit Chance: {CritChance*100}%\n" +
               $"Speed: {Speed}\n";
    }
        

    public static CharacterStats operator +(CharacterStats a, CharacterStats b)
    {
        return new CharacterStats(a.Damage + b.Damage, a.Health + b.Health, a.Speed + b.Speed, a.CritChance + b.CritChance);
    }
}