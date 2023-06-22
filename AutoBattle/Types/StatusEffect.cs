public class StatusEffect
{
    public string name;
    public delegate void effectDelegate(Character target);
    public effectDelegate effectImplementation;
}