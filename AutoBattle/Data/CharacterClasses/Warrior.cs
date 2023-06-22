using System;

public class Warrior : CharacterClass
{
    public Warrior() 
    {
        name = "Warrior";
        type = CharacterClassType.Warrior;
        baseHealth = 220;
        baseDamage = 20;
        manaRecovery = 20;
        attackRange = 1;
        skill = new Stab();
        skillImplementation = StabImplementation;
    }

    public void StabImplementation(Character performer, Character target)
    {
        int randomDamage = RandomHelper.GetRandomInt(0, skill.damage);

        Console.ForegroundColor = performer.team.color;
        Console.WriteLine($"({performer.identifier}) {performer.name} performed a {skill.name} against ({target.identifier}) {target.name} dealing {randomDamage} and applying {skill.effect.name}");
        Console.ResetColor();

        target.TakeDamage(randomDamage);
        target.SubscribeStatusEffect(skill.effect.effectImplementation);
    }
}