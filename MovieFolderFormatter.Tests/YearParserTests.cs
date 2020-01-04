using MovieFolderFormatter;
using FluentAssertions;
using AutoFixture;
using AutoFixture.AutoMoq;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MovieFolderFormatter.Tests
{
    [TestClass]
    public class YearParserTests
    {
        private IFixture fixture;
        private YearParser Sut =>
                fixture.Create<YearParser>();

        [TestInitialize]
        public void Init()
        {
            fixture = new Fixture()
            .Customize(new AutoMoqCustomization());
        }

        [TestMethod]
        [DataRow(2010)]
        [DataRow(2020)]
        [DataRow(1984)]
        public void Parse_WithYearBetweenBracket_ReturnsYear(int expected)
        {
            // Arrange.
            var folderName = $"movie title [{expected}] suffix";

            // Act.
            var actual = Sut.Parse(folderName);

            // Assert.
            actual.Value.Should().Be($"[{expected}]");
            actual.Groups[1].Value.Should().Be($"{expected}");
        }

        [TestMethod]
        [DataRow(2010)]
        [DataRow(2020)]
        [DataRow(1984)]
        public void Parse_WithYearBetweenParenthesis_ReturnsYear(int expected)
        {
            // Arrange.
            var folderName = $"movie title ({expected}) suffix";

            // Act.
            var actual = Sut.Parse(folderName);

            // Assert.
            actual.Value.Should().Be($"({expected})");
            actual.Groups[1].Value.Should().Be($"{expected}");
        }

        [TestMethod]
        public void Parse_WithYearWithout_ReturnsYear()
        {
            // Arrange.
            var folderName = $"movie title 1993 suffix";

            // Act.
            var actual = Sut.Parse(folderName);

            // Assert.
            actual.Should().BeNull();
        }

    }

    internal class NewClass
    {
        public NewClass()
        {
        }

        public override bool Equals(object obj)
        {
            return obj is NewClass other;
        }

        public override int GetHashCode()
        {
            return 0;
        }
    }
}
