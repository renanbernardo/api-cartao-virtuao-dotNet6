using Domain.Commands.Inputs;
using Domain.Commands.Results;
using Domain.Handlers;

namespace Tests.HandlerTests;

[TestClass]
public class GerarCartaoVirtualHandlerTests
{
    [TestMethod]
    public void DeveRetornarEmailInvalido()
    {
        var command = new GerarCartaoVirtualCommand();
        command.Email = "teste.teste.com";

        var gerarCartaoHandler = new GerarCartaoVirtualHandler();
        var result = gerarCartaoHandler.Handle(command);

        Assert.AreEqual("Email inválido", "");
    }

    [TestMethod]
    public void DeveRetornarSucesso()
    {
        var command = new GerarCartaoVirtualCommand();
        command.Email = "renan.brnrd@gmail.com";

        var gerarCartaoHandler = new GerarCartaoVirtualHandler();
        var result = gerarCartaoHandler.Handle(command);

        Assert.AreEqual(true, false);
    }
}