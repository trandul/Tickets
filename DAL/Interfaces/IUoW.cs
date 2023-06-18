namespace DAL.Interfaces
{
    public interface IUoW
    {
        ITicketRepository TicketRepository { get; }
    }
}
