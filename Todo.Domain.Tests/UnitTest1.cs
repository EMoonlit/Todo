using System;
using Todo.Domain.Entities;
using Todo.Domain.ValueObjects;
using Xunit;

namespace Todo.Domain.Tests;

public class UnitTest1
{
    private const string FakeFistName = "Kratos";
    private  const string FakeLastName = "God of War";
    private const string FakeEmail = "kratos22@god.com";
    private const string FakePhoneNumber = "11998765432";
        
    [Fact]
    public void ThrowIfFirstNameIsEmpty()
    {
        Exception actualException = Assert.Throws<NotificationError>(() => new User(
            "",
            FakeLastName,
            FakeEmail,
            FakePhoneNumber));
        Assert.Equal("User, FirstName is required \n", actualException.Message);
    }
    
    [Fact]
    public void ThrowIfLastNameIsEmpty()
    {
        
        Exception actualException = Assert.Throws<NotificationError>(() => new User(FakeFistName,
            "",
            FakeEmail,
            FakePhoneNumber));
        Assert.Equal("User, LastName is required \n", actualException.Message);
    }
    
    [Fact]
    public void ThrowIfEmailIsEmpty()
    {
        
        Exception actualException = Assert.Throws<NotificationError>(() => new User(FakeFistName,
            FakeLastName,
            null,
            FakePhoneNumber));
        Assert.Equal("User, Email is required \n", actualException.Message);
    }

    [Fact]
    public void ShouldReturnExceptionWhenAnyFieldAreInvalid()
    {
        Exception actualException = Assert.Throws<NotificationError>(() => new User("",
            "",
            null,
            ""));
        Assert.Equal(
            "User, FirstName is required \n" +
            "User, LastName is required \n" +
            "User, Email is required \n", actualException.Message);
        
        
    }
}