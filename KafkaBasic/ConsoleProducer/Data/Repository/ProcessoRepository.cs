using ConsoleProducer.Data.Context;
using Dapper;

namespace ConsoleProducer.Data.Repository;

public class ProcessoRepository : IProcessoRepository
{
    private readonly ApplicationDbContext _context;

    public ProcessoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<dynamic> GetById(long prodcessoId)
    {
        var query = string.Empty;
        return await _context.Connection.QueryAsync<dynamic>(query);
    }

    public async Task<dynamic> GetByProcessNumber(string processNumber)
    {
        var query = string.Empty;
        return await _context.Connection.QueryAsync<dynamic>(query);
    }
}