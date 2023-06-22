using System;

public class Mage : CharacterClass
{
    public Mage() 
    {
        name = "Mage";
        type = CharacterClassType.Mage;
        baseHealth = 150;
        baseDamage = 20;
        manaRecovery = 20;
        attackRange = 1;
        skillImplementation = iceChamberImplementation;
    }

    public void iceChamberImplementation(Character performer, Character target)
    {
        skill = new IceChamber();

        int randomDamage = RandomHelper.GetRandomInt(0, skill.damage);

        Console.ForegroundColor = performer.team.color;
        Console.WriteLine($"({performer.identifier}) {performer.name} performed a {skill.name} against ({target.identifier}) {target.name} dealing {randomDamage} and applying {skill.effect.name}");
        Console.ResetColor();

        target.TakeDamage(randomDamage);
        target.SubscribeStatusEffect(skill.effect.effectImplementation);
    }
}