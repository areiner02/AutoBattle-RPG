using System;

public class Stun : StatusEffect
{
    int roundsStunned;

    public Stun(int roundsStunned)
    {
        name = "Stun";
        effectImplementation = stunImplementation;
        this.roundsStunned = roundsStunned;
    }

    public void stunImplementation(Character target)
    {
        if (roundsStunned <= 0)
        {
            target.Stun(false);
            return;
        }
        roundsStunned--;

        Console.ForegroundColor = target.team.color;
        Console.WriteLine($"({target.identifier}) {target.name} is stunned inside the Ice Chamber.");
        Console.ResetColor();

        target.Stun(true);
    }
}