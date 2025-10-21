using HouseControl.Sunset;
using Microsoft.Extensions.Time.Testing;

namespace HouseControl.Library.Tests;

public class ScheduleHelperTests
{
    private TimeSpan timeZoneOffset = new(-2, 0, 0);

    [Fact]
    public void Now_ReturnsConfiguredTime()
    {
        // Arrange
        var helper = new ScheduleHelper(new FakeSunsetProvider());
        var now = new DateTimeOffset(2025, 11, 01, 14, 22, 22, timeZoneOffset);
        helper.HelperTimeProvider = new FakeTimeProvider(now);

        // Act
        var actual = helper.Now();

        // Assert
        Assert.Equal(now, actual);
    }

    [Fact]
    public void Tomorrow_ReturnsConfiguredTimePlusOneDay()
    {
        // Arrange
        var now =      new DateTimeOffset(2025, 11, 01, 14, 22, 22, timeZoneOffset);
        var expected = new DateTimeOffset(2025, 11, 02, 00, 00, 00, timeZoneOffset);
        var helper = new ScheduleHelper(new FakeSunsetProvider());
        helper.HelperTimeProvider = new FakeTimeProvider(now);

        // Act
        var actual = helper.Tomorrow();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void IsInFuture_WithFutureDate_ReturnsTrue()
    {
        // Arrange
        var now =        new DateTimeOffset(2025, 11, 01, 14, 22, 22, timeZoneOffset);
        var futureDate = new DateTimeOffset(2025, 11, 02, 14, 22, 22, timeZoneOffset);
        var helper = new ScheduleHelper(new FakeSunsetProvider());
        helper.HelperTimeProvider = new FakeTimeProvider(now);

        // Act
        var result = helper.IsInFuture(futureDate);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsInFuture_WithPastDate_ReturnsFalse()
    {
        // Arrange
        var now = new DateTimeOffset(2025, 11, 01, 14, 22, 22, timeZoneOffset);
        var pastDate = new DateTimeOffset(2025, 10, 30, 14, 22, 22, timeZoneOffset);
        var helper = new ScheduleHelper(new FakeSunsetProvider());
        helper.HelperTimeProvider = new FakeTimeProvider(now);

        // Act
        var result = helper.IsInFuture(pastDate);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsInFuture_WithCurrentDate_ReturnsFalse()
    {
        // Arrange
        var now = new DateTimeOffset(2025, 11, 01, 14, 22, 22, timeZoneOffset);
        var helper = new ScheduleHelper(new FakeSunsetProvider());
        helper.HelperTimeProvider = new FakeTimeProvider(now);

        // Act
        var result = helper.IsInFuture(now);

        // Assert
        Assert.False(result);
    }
}