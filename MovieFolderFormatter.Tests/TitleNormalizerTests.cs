using AutoFixture;
using AutoFixture.AutoMoq;
using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MovieFolderFormatter.Tests
{

    [TestClass]
    public class TitleNormalizerTests
    {
        private IFixture fixture;
        private TitleNormalizer Sut =>
                fixture.Create<TitleNormalizer>();

        [TestInitialize]
        public void Init()
        {
            fixture = new Fixture()
            .Customize(new AutoMoqCustomization());
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("   ")]
        public void Normalize_WithEmptyOrNull_Throws(string title)
        {
            // Arrange.
            Action act = () => Sut.Normalize(title);

            // Act/Assert.
            act.Should().Throw<InvalidOperationException>();
        }
    }
}