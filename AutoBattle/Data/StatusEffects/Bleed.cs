using System;

public class Bleed : StatusEffect
{
    private int bleedBaseDamage;
    private int roundsBleeding;

    public Bleed(int bleedBaseDamage, int roundsBleeding)
    {
        name = "Bleed";
        effectImplementation = bleedImplementation;
        this.bleedBaseDamage = bleedBaseDamage;
        this.roundsBleeding = roundsBleeding;
    }

    public void bleedImplementation(Character target)
    {
        if (roundsBleeding <= 0)
        {
            target.UnsubscribeStatusEffect(effectImplementation);
            return;
        }
        roundsBleeding--;

        int randomDamage = RandomHelper.GetRandomInt(1, bleedBaseDamage);

        Console.ForegroundColor = target.team.color;
        Console.WriteLine($"({target.identifier}) {target.name} bled losing {randomDamage} health.");
        Console.ResetColor();
        
        target.TakeDamage(randomDamage);
    }
}