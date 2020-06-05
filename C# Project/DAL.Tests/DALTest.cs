using System;
using DAL.Entities;
using DAL.Repositories;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;

namespace DAL.Tests
{
    [TestFixture]
    public class DALTest
    {
        private IRepository<LocalPoint> _regionRepository;
        private Mock<DbSet<LocalPoint>> _mockDbSet;
        private Mock<DbContext> _mockContext;

        [SetUp]
        public void SetUp()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<DbContext>()
                .Options;
            _mockContext = new Mock<DbContext>(opt);
            _mockDbSet = new Mock<DbSet<LocalPoint>>();

            _mockContext
                .Setup(context =>
                    context.Set<LocalPoint>(
                    ))
                .Returns(_mockDbSet.Object);

            _regionRepository = new Repository<LocalPoint>(_mockContext.Object);
        }

        [Test]
        public void Repository_CalledInsertOneTime_True()
        {
            // Arrange
            var expectedLocalPoint = new Mock<LocalPoint>().Object;

            //Act
            _regionRepository.Insert(expectedLocalPoint);

            // Assert
            _mockDbSet.Verify(
                dbSet => dbSet.Add(
                    expectedLocalPoint
                ), Times.Once());
        }

        [Test]
        public void Repository_CalledRemove_True()
        {
            // Arrange
            var id = Guid.NewGuid();

            var expectedLocalPoint = new LocalPoint { Id = id };
            _mockDbSet.Setup(mock => mock.Find(expectedLocalPoint.Id)).Returns(expectedLocalPoint);

            // Act

            var findedLocalPoint = _regionRepository.GetById(id);
            _regionRepository.Remove(findedLocalPoint);

            // Assert
            _mockDbSet.Verify(
                dbSet => dbSet.Find(
                    expectedLocalPoint.Id
                ), Times.Once());

            _mockDbSet.Verify(
                dbSet => dbSet.Remove(
                    expectedLocalPoint
                ), Times.Once());
        }
    }
}