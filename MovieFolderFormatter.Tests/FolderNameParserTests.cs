using AutoFixture;
using AutoFixture.AutoMoq;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;
using FluentAssertions;

namespace MovieFolderFormatter.Tests
{
    [TestClass]
    public class FolderNameParserTests
    {
        private IFixture fixture;
        private FolderNameParser Sut =>
                fixture.Create<FolderNameParser>();

        [TestInitialize]
        public void Init()
        {
            fixture = new Fixture()
            .Customize(new AutoMoqCustomization());
        }

        [TestMethod]
        public void Parse_WithParsedYear_ReturnsYear()
        {
            // Arrange.
            var folderName = fixture.Create<string>();
            var year = fixture.Create<int>();

            fixture.Freeze<Mock<IYearParser>>()
                .Setup(s => s.Parse(folderName))
                .Returns((year, It.IsAny<string>()));

            // Act.
            var actual = Sut.Parse(folderName);

            // Assert.
            actual.Year.Should().Be(year);
        }

        [TestMethod]
        public void Parse_WithParsedYear_ReturnsNormalizedTitle()
        {
            // Arrange.
            var rawTitle = fixture.Create<string>();
            var matchedYearPart = fixture.Create<string>();
            var postfix = fixture.Create<string>();
            var folderName = $"{rawTitle}{matchedYearPart}{postfix}";

            fixture.Freeze<Mock<IYearParser>>()
                .Setup(s => s.Parse(folderName))
                .Returns((It.IsAny<int>(), matchedYearPart));

            var expected = fixture.Create<string>();

            fixture.Freeze<Mock<ITitleNormalizer>>()
                .Setup(s => s.Normalize(rawTitle))
                .Returns(expected);

            // Act.
            var actual = Sut.Parse(folderName);

            // Assert.
            actual.Title.Should().Be(expected);
        }
    }
}
