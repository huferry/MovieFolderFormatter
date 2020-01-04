using FluentAssertions;
using AutoFixture;
using AutoFixture.AutoMoq;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MovieFolderFormatter.Tests
{

    [TestClass]
    public class MovieFolderFormatterTests
    {
        private IFixture fixture;
        private MovieFolderFormatter Sut =>
                fixture.Create<MovieFolderFormatter>();

        [TestInitialize]
        public void Init()
        {
            fixture = new Fixture()
            .Customize(new AutoMoqCustomization());
        }

        [TestMethod]
        public void Format_WithAnyFolderName_FormatFromParser()
        {
            // Arrange.
            var folderName = fixture.Create<string>();
            var title = fixture.Create<string>();
            var year = fixture.Create<int>();

            var parser = fixture.Freeze<Mock<IFolderNameParser>>()
                    .Setup(s => s.Parse(folderName))
                    .Returns(new Movie
                    {
                        Title = title,
                        Year = year
                    });

            // Act.
            var actual = Sut.Format(folderName);

            // Assert.
            actual.Should().Be($"{title} [{year}]");
        }
    }
}
