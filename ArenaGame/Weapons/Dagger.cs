using ArenaGame;

public class Dagger : IWeapon
{
    public string Name { get; set; }
    public double AttackDamage { get; private set; }
    public double BlockingPower { get; private set; }

    public Dagger(string name)
    {
        Name = name;
        AttackDamage = 30; 
        BlockingPower = 1; 
    }

   
    public double TriggerSpecialAbility(Hero hero)
    {
       
        return 0;
    }
}
