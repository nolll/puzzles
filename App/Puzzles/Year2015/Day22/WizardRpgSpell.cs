namespace App.Puzzles.Year2015.Day22;

public class WizardRpgSpell
{
    private readonly int _damage;
    private readonly int _armor;
    private readonly int _timer;
    private readonly int _healing;
    private readonly int _recharge;

    public string Name { get; }
    public int Cost { get; }
        
    public WizardRpgSpell(string name, int cost, int damage, int armor, int healing, int recharge, int timer)
    {
        Name = name;
        Cost = cost;
        _damage = damage;
        _armor = armor;
        _healing = healing;
        _recharge = recharge;
        _timer = timer;
    }

    public WizardRpgEffect GetEffect()
    {
        return new WizardRpgEffect(Name, _damage, _armor, _healing, _recharge, _timer);
    }
}