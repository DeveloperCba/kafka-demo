using ConsoleProducer.Models;

namespace ConsoleProducer.Data.Repository
{
    public  interface IProcessoRepository
    {
        Task<IEnumerable<OmniProcess>> GetById(long prodcessoId);
        Task<IEnumerable<OmniProcess>> GetByProcessNumber(string processNumber);
    }
}
