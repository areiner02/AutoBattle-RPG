using System;

public class Cleric : CharacterClass
{
    public Cleric() 
    {
        name = "Cleric";
        type = CharacterClassType.Cleric;
        baseHealth = 250;
        baseDamage = 15;
        manaRecovery = 15;
        attackRange = 1;
        skill = new Heal();
        skillImplementation = HealImplementation;
    }

    public void HealImplementation(Character performer, Character target)
    {
        int randomHeal = RandomHelper.GetRandomInt(0, skill.damage);

        Console.ForegroundColor = performer.team.color;
        Console.WriteLine($"({performer.identifier}) {performer.name} healed {randomHeal} and applied {skill.effect.name}");
        Console.ResetColor();

        performer.Heal(randomHeal);
        performer.SubscribeStatusEffect(skill.effect.effectImplementation);
    }
}