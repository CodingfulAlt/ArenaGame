using ArenaGame;

public class Sword : IWeapon
{
    public string Name { get; set; }
    public double AttackDamage { get; private set; }
    public double BlockingPower { get; private set; }

    public Sword(string name)
    {
        Name = name;
        AttackDamage = 20;  
        BlockingPower = 10; 
    }

   
    public double TriggerSpecialAbility(Hero hero)
    {
       
        return 0;
    }
}
