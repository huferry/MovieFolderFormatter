using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MovieFolderFormatter.Tests
{
    [TestClass]
    public class DotsRemoverTests
    {
        private IFixture fixture;
        private DotsRemover Sut =>
                fixture.Create<DotsRemover>();

        [TestInitialize]
        public void Init()
        {
            fixture = new Fixture()
            .Customize(new AutoMoqCustomization());
        }

        [TestMethod]
        public void Process_WithDots_RemovesDots()
        {
            // Arrange.
            var raw = "2001.Space.Odyssey";

            // Act.
            var actual = Sut.Process(raw);

            // Assert.
            actual.Should().Be("2001 Space Odyssey");
        }

        [TestMethod]
        public void Process_WithAbbreviation_ShouldNotRemoveDots()
        {
            // Arrange.
            var raw = "G.I. Joe";

            // Act.
            var actual = Sut.Process(raw);

            // Assert.
            actual.Should().Be("G.I. Joe");
        }
    }
}
