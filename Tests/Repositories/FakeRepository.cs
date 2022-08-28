using Domain.Entities;
using Domain.Repositories;

namespace Tests.Repositories;

public class FakeRepository : ICartaoVirtualRepository
{
    public void AdicionarCartaoVirtual(CartaoVirtual cartaoVirtual)
    {
        // Intencionalmente vazio
    }

    public IEnumerable<CartaoVirtual> ListarCartaoVirtual(string email)
    {
        return new List<CartaoVirtual>();
    }
}