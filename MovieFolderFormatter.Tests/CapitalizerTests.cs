using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MovieFolderFormatter.Tests
{
    [TestClass]
    public class CapitalizerTests
    {
        private IFixture fixture;
        private Capitalizer Sut =>
                fixture.Create<Capitalizer>();

        [TestInitialize]
        public void Init()
        {
            fixture = new Fixture()
            .Customize(new AutoMoqCustomization());
        }

        [TestMethod]
        public void Process_WithAllCaps_CapitalizeFirstLetters()
        {
            // Arrange.
            var raw = "2001 SPACE ODYSSEY";

            // Act.
            var actual = Sut.Process(raw);

            // Assert.
            actual.Should().Be("2001 Space Odyssey");
        }

        [TestMethod]
        public void Process_WithAbbreviation_ShouldCapitalize()
        {
            // Arrange.
            var raw = "g.i. joe";

            // Act.
            var actual = Sut.Process(raw);

            // Assert.
            actual.Should().Be("G.I. Joe");
        }
    }
}
