using Castle.Core.Logging;
using Customer.Api.Controllers;
using Customer.Application.Queries;
using Customer.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace Customer.Test;

public class CustomerControllerTests
{
    private readonly Mock<IMediator> _mediatorMock;
    private readonly Mock<ILogger<CustomerController>> _loggerMock;
    private readonly CustomerController _controller;

    public CustomerControllerTests()
    {
        _mediatorMock = new Mock<IMediator>();
        _loggerMock = new Mock<ILogger<CustomerController>>();
        _controller = new CustomerController(_mediatorMock.Object, _loggerMock.Object);
    }
    [SetUp]
    public void Setup()
    {
        
    }

    [Test]
    public void GetCustomers_ReturnsOk_WithCustomers()
    {
        // Arrange
        var fakeCustomers = new List<CustomerResponse>
        {
            new CustomerResponse { Id = 1, Name = "Alexis" },
            new CustomerResponse { Id = 2, Name = "Jhon" }
        };

        _mediatorMock
            .Setup(m => m.Send(It.IsAny<GetAllCustomersQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeCustomers);

        // Act
        var result = _controller.GetCustomers();
        Console.WriteLine($"********\n {result} \n******\n");
        Console.WriteLine($"********\n {result.GetType()} \n******\n");
        Console.WriteLine($"********\n {result.IsCompletedSuccessfully} \n******\n");
        Console.WriteLine($"********\n {result.Status} \n******\n");
        // Assert
            
    }
}