using System;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Profiles;
using BLL.Services;
using BLL.Services.Interfaces;
using CCL.Security;
using CCL.Security.Identity;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork.Interfaces;
using Moq;
using NUnit.Framework;

namespace BLL.Tests
{
    public class LocalPointServiceTest
    {
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private Mock<IMapper> _mockMapper;

        [SetUp]
        public void Setup()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockMapper = new Mock<IMapper>();
        }

        [Test]
        public void LocalPointServiceCtor_NullConstructionParams_ExceptionThrows()
        {
            // Arrange
            IUnitOfWork nullUnitOfWork = null;
            IMapper nullMapper = null;

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => new LocalPointService(nullUnitOfWork, nullMapper));
        }

        [Test]
        public void LocalPointServiceRemoveLocalPoint_UserIsUser_ThrowMethodAccessException()
        {
            // Arrange
            var user = new User(Guid.NewGuid(), Guid.NewGuid().ToString());
            Authorization.SetUser(user);

            ILocalPointService regionService = new LocalPointService(_mockUnitOfWork.Object, _mockMapper.Object);

            // Act
            // Assert
            Assert.ThrowsAsync<MethodAccessException>(() => regionService.RemoveLocalPoint(Guid.NewGuid()));
        }

        [Test]
        public async Task GetLocalPoint_LocalPointFromDAL_CorrectMappingToLocalPointDTO()
        {
            // Arrange
            var user = new Administrator(Guid.NewGuid(), Guid.NewGuid().ToString());
            Authorization.SetUser(user);

            var itemId = Guid.NewGuid();
            var regionServiceService = GetLocalPointService(itemId);

            // Act
            var actualStreetDto = await regionServiceService.GetLocalPointAsync(itemId);

            // Assert
            Assert.True(
                actualStreetDto.Id == itemId
                && actualStreetDto.Name == "testName"
                && actualStreetDto.Description == "testDescription"
            );
        }

        private ILocalPointService GetLocalPointService(Guid itemId)
        {
            var mockContext = new Mock<IUnitOfWork>();
            var expectedLocalPoint = new LocalPoint()
            {
                Id = itemId,
                Name = "testName",
                Description = "testDescription"
            };
            var mockDbSet = new Mock<IRepository<LocalPoint>>();

            mockDbSet.Setup(mock => mock.GetByIdAsync(itemId)).ReturnsAsync(expectedLocalPoint);

            mockContext
                .Setup(context =>
                    context.Repository<LocalPoint>())
                .Returns(mockDbSet.Object);
            mockContext.Setup(mock => mock.GetByIdAsync<LocalPoint>(itemId)).ReturnsAsync(expectedLocalPoint);
            var cfg = new MapperConfiguration(a => a.AddProfile<LocalPointProfile>());

            ILocalPointService regionService = new LocalPointService(mockContext.Object, new Mapper(cfg));

            return regionService;
        }

    }
}