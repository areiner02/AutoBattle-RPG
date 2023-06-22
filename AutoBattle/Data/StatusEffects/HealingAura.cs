using System;

public class HealingAura : StatusEffect
{
    private int baseHealing = 10;
    private int roundsHealing;

    public HealingAura(int roundsHealing)
    {
        name = "Healing Aura";
        effectImplementation = healingAuraImplementation;
        this.roundsHealing = roundsHealing;
    }

    public void healingAuraImplementation(Character target)
    {
        if(roundsHealing <= 0)
        {
            target.UnsubscribeStatusEffect(effectImplementation);
            return;
        }
        roundsHealing--;

        int randomHeal = RandomHelper.GetRandomInt(1, baseHealing);

        Console.ForegroundColor = target.team.color;
        Console.WriteLine($"({target.identifier}) {target.name} was healed {randomHeal} by the Healing Aura.");
        Console.ResetColor();

        target.Heal(randomHeal);
    }
}