namespace ConsoleProducer.Data.Repository
{
    public  interface IProcessoRepository
    {
        Task<dynamic> GetById(long prodcessoId);
        Task<dynamic> GetByProcessNumber(string processNumber);
    }
}
