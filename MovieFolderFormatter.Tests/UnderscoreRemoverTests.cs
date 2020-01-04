using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MovieFolderFormatter.Tests
{
    [TestClass]
    public class UnderscoreRemoverTests
    {
        private IFixture fixture;
        private UnderscoreRemover Sut =>
                fixture.Create<UnderscoreRemover>();

        [TestInitialize]
        public void Init()
        {
            fixture = new Fixture()
            .Customize(new AutoMoqCustomization());
        }

        [TestMethod]
        public void Normalize_WithUnderscore_ReplacesWithSpace()
        {
            // Arrange.
            var raw = "2001_Space_Odyssey";

            // Act.
            var actual = Sut.Process(raw);

            // Assert.
            actual.Should().Be("2001 Space Odyssey");
        }
    }
}