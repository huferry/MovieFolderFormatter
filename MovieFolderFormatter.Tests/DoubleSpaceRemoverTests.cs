using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MovieFolderFormatter.Tests
{
    [TestClass]
    public class DoubleSpaceRemoverTests
    {
        private IFixture fixture;
        private DoubleSpaceRemover Sut =>
                fixture.Create<DoubleSpaceRemover>();

        [TestInitialize]
        public void Init()
        {
            fixture = new Fixture()
            .Customize(new AutoMoqCustomization());
        }

        [TestMethod]
        public void Process_WithDoubleSpaces_RemovesDoubleSpaces()
        {
            // Arrange.
            var raw = "2001  Space     Odyssey";

            // Act.
            var actual = Sut.Process(raw);

            // Assert.
            actual.Should().Be("2001 Space Odyssey");
        }
    }
}