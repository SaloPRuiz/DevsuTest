using DevsuBackEnd.Controllers;
using DevsuBackEnd.Domain.Contracts.Services;
using DevsuBackEnd.Domain.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace DevsuBackEnd.Tests;

public class ClienteControllerTests
{
    private readonly Mock<IClienteService> _mockService;
    private readonly ClienteController _controller;

    public ClienteControllerTests()
    {
        _mockService = new Mock<IClienteService>();
        _controller = new ClienteController(_mockService.Object);
    }
    
    // GET /api/cliente
    [Fact]
    public async Task GetAllClients_ShouldReturnOk_WithClientList()
    {
        var clients = new List<ClienteModel>
        {
            new() { ClienteId = 1, Nombre = "Juan" },
            new() { ClienteId = 2, Nombre = "Ana" }
        };

        _mockService.Setup(s => s.GetAllAsync(null)).ReturnsAsync(clients);
        
        var result = await _controller.GetAllClients(null);
        
        var okResult = result as OkObjectResult;
        okResult.Should().NotBeNull();
        var data = okResult!.Value as IEnumerable<ClienteModel>;
        data.Should().HaveCount(2);
    }
    
    // GET /api/cliente/{id}
    [Fact]
    public async Task GetClientById_ShouldReturnOk_WhenClientExists()
    {
        var expectedClient = new ClienteModel { ClienteId = 1, Nombre = "Carlos", Identificacion = "12345678" };
        _mockService.Setup(s => s.GetByIdAsync(1)).ReturnsAsync(expectedClient);
        
        var result = await _controller.GetClientById(1);
        
        var okResult = result as OkObjectResult;
        okResult.Should().NotBeNull();
        okResult!.Value.Should().BeEquivalentTo(expectedClient);
    }
    
    
    [Fact]
    public async Task GetClientById_ShouldReturnNotFound_WhenClientDoesNotExist()
    {
        _mockService.Setup(s => s.GetByIdAsync(99)).ReturnsAsync((ClienteModel?)null);
        
        var result = await _controller.GetClientById(99);
        
        result.Should().BeOfType<NotFoundObjectResult>();
    }
    
    // PUT /api/cliente/{id}
    [Fact]
    public async Task UpdateClient_ShouldReturnOk_WhenClientIsUpdated()
    {
        var updatedClient = new ClienteModel { ClienteId = 1, Nombre = "Pedro" };
        _mockService.Setup(s => s.UpdateAsync(1, updatedClient)).ReturnsAsync(updatedClient);
        
        var result = await _controller.UpdateClient(1, updatedClient);
        
        var okResult = result as OkObjectResult;
        okResult.Should().NotBeNull();
        okResult!.Value.Should().BeEquivalentTo(updatedClient);
    }
    
    // DELETE /api/cliente/{id}
    [Fact]
    public async Task DeleteClient_ShouldReturnNoContent_WhenClientIsDeleted()
    {
        _mockService.Setup(s => s.DeleteAsync(1)).ReturnsAsync(true);
        
        var result = await _controller.DeleteClient(1);

        result.Should().BeOfType<NoContentResult>();
    }

    [Fact]
    public async Task DeleteClient_ShouldReturnNotFound_WhenClientDoesNotExist()
    {
        _mockService.Setup(s => s.DeleteAsync(999)).ReturnsAsync(false);

        var result = await _controller.DeleteClient(999);

        result.Should().BeOfType<NotFoundObjectResult>();
    }
}