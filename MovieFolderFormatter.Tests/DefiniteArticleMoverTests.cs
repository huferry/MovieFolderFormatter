using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MovieFolderFormatter.Tests
{
    [TestClass]
    public class DefiniteArticleMoverTests
    {
        private IFixture fixture;
        private DefiniteArticleMover Sut =>
                fixture.Create<DefiniteArticleMover>();

        [TestInitialize]
        public void Init()
        {
            fixture = new Fixture()
            .Customize(new AutoMoqCustomization());
        }

        [TestMethod]
        public void Process_StartWithDefiniteArticle_MovesToBack()
        {
            // Arrange.
            var raw = "The Bad And Ugly";

            // Act.
            var actual = Sut.Process(raw);

            // Assert.
            actual.Should().Be("Bad And Ugly, The");
        }

        [TestMethod]
        public void Process_WithoutDefinitArticle_ShouldNotChange()
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
