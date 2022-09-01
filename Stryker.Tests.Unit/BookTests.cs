using FluentAssertions;
using Test;
using Xunit;

namespace Stryker.Tests.Unit;

public class BookTests
{
    [Fact]
    public void Can_be_able_to()
    {
        // Arrange
        var sut = new Book(100, "sjoerd");

        // Act
        sut.TurnPage();

        // Assert
        sut.CurrentPage.Should().Be(1);
    }

    [Fact]
    public void Can_be_able_to1()
    {
        // Arrange
        var sut = new Book(100, "sjoerd");

        // Act
        sut.TurnPage();
        sut.TurnBackPage();

        // Assert
        sut.CurrentPage.Should().Be(0);
    }
}
