using Domain.Commands.Inputs;
using Domain.Commands.Results;
using Domain.Handlers;
using Tests.Repositories;

namespace Tests.HandlerTests;

[TestClass]
public class GerarCartaoVirtualHandlerTests
{
    [TestMethod]
    public void DeveRetornarEmailInvalido()
    {
        var command = new GerarCartaoVirtualCommand();
        command.Email = "teste.teste.com";

        var gerarCartaoHandler = new GerarCartaoVirtualHandler(new FakeRepository());
        var result = gerarCartaoHandler.Handle(command);

        Assert.AreEqual("Email inválido", result.Message);
    }

    [TestMethod]
    public void DeveRetornarSucesso()
    {
        var command = new GerarCartaoVirtualCommand();
        command.Email = "renan.brnrd@gmail.com";

        var gerarCartaoHandler = new GerarCartaoVirtualHandler(new FakeRepository());
        var result = gerarCartaoHandler.Handle(command);

        Assert.AreEqual(true, result.Success);
    }
}