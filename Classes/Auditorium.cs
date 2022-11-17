namespace DependencyInjection1.Classes;

public class Auditorium
{
    private int _number;
    private int _capacity;
    private Guid _guid;

    public Auditorium(int number, int capacity)
    {
        _guid = Guid.NewGuid();
        _number = number;
        _capacity = capacity;
    }

    public int Number { get => _number; set => _number = value; }
    public int Capacity { get => _capacity; set => _capacity = value; }
    public Guid Guid { get => _guid; }

    public bool TryEnter(Ticket ticket)
    {
        throw new NotImplementedException();
    }
}
