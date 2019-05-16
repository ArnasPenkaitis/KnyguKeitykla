using Agiblock.Models;
using Agiblock.Repository.Interface;
using Agiblock.Services;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Agiblock.Tests.ServiceTests
{
    public class CompanyServiceTests
    {
        [Fact]
        public async Task ReturnsCompanyListWithSingleElement()
        {
            IQueryable<Company> queryableCompanies = new List<Company>() {new Company()}.AsQueryable();

            var repositoryMock = new Mock<IRepository>();
            repositoryMock.Setup(x => x.QueryAsync<Company>()).ReturnsAsync(queryableCompanies);

            var companyService = new CompanyService(repositoryMock.Object);

            var result = await companyService.GetEntities();
            repositoryMock.Verify(x => x.QueryAsync<Company>(), Times.Once);

            Assert.NotNull(result);
            Assert.Single(result);
        }

        [Fact]
        public async Task ReturnsEmptyCompanyList()
        {
            IQueryable<Company> queryableCompanies = new List<Company>().AsQueryable();

            var repositoryMock = new Mock<IRepository>();
            repositoryMock.Setup(x => x.QueryAsync<Company>()).ReturnsAsync(queryableCompanies);

            var companyService = new CompanyService(repositoryMock.Object);

            var result = await companyService.GetEntities();
            repositoryMock.Verify(x => x.QueryAsync<Company>(), Times.Once);

            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public async Task ReturnsCompanyListWithMultipleElements()
        {
            IQueryable<Company> queryableCompanies = new List<Company>
            {
                new Company(),
                new Company(),
                new Company()
            }.AsQueryable();

            var repositoryMock = new Mock<IRepository>();
            repositoryMock.Setup(x => x.QueryAsync<Company>()).ReturnsAsync(queryableCompanies);

            var companyService = new CompanyService(repositoryMock.Object);

            var result = await companyService.GetEntities();
            repositoryMock.Verify(x => x.QueryAsync<Company>(), Times.Once);

            Assert.NotNull(result);
            Assert.Equal(3, result.Count());
        }

        [Theory]
        [InlineData(1)]
        public async Task CompanyNotFound(int companyId)
        {
            Company company = null;
            var repositoryMock = new Mock<IRepository>();
            repositoryMock.Setup(x => x.QueryByIdAsync<Company>(companyId)).ReturnsAsync(company);

            var companyService = new CompanyService(repositoryMock.Object);

            var result = await companyService.GetEntityById(companyId);
            repositoryMock.Verify(x => x.QueryByIdAsync<Company>(companyId), Times.Once);

            Assert.Null(result);
        }

        [Theory]
        [InlineData(1)]
        public async Task CompanyFound(int companyId)
        {
            Company company = new Company();
            var repositoryMock = new Mock<IRepository>();
            repositoryMock.Setup(x => x.QueryByIdAsync<Company>(companyId)).ReturnsAsync(company);

            var companyService = new CompanyService(repositoryMock.Object);

            var result = await companyService.GetEntityById(companyId);
            repositoryMock.Verify(x => x.QueryByIdAsync<Company>(companyId), Times.Once);

            Assert.NotNull(result);
            Assert.IsType<Company>(result);
        }

        [Theory]
        [InlineData(1, "TestCompanyExtId1", "TestCompanyTradingName1", "TestCompanyLegalName1", 1, false, false, "123123123", null, null, null, false, true, false, true, null, null, null, false)]
        [InlineData(2, "TestCompanyExtId2", "TestCompanyTradingName2", "TestCompanyLegalName2", 2, false, true, "1231235123", "56456456", null, null, true, true, false, true, null, null, null, false)]
        [InlineData(3, "TestCompanyExtId3", "TestCompanyTradingName3", "TestCompanyLegalName3", 3, true, false, "1243123123", "123123", null, null, false, false, false, false, null, null, null, true)]
        public async Task CreateCompany(int id, string externalId, string tradingName, string legalName,
            int companyType, bool unused, bool isForwarder, string phone, string fax, int? addressId,
            int? mailAddressId, bool isCustomClearance, bool isActive, bool isCarrier, bool isWarehouse,
            string chamberOfCommerce, string chamberOfCommerceCi, string countryVAT, bool isExchangeBroker)
        {
            var company = new Company()
            {
                Id = id,
                ExternalId = externalId,
                TradingName = tradingName,
                LegalName = legalName,
                CompanyType = companyType,
                Unused = unused,
                IsForwarder = isForwarder,
                Phone = phone,
                Fax = fax,
                AddressId = addressId,
                MailAddressId = mailAddressId,
                IsCustomClearance = isCustomClearance,
                IsActive = isActive,
                IsCarrier = isCarrier,
                IsWarehouse = isWarehouse,
                ChamberOfCommerce = chamberOfCommerce,
                ChamberOfCommerceCi = chamberOfCommerceCi,
                CountryVAT = countryVAT,
                IsExchangeBroker = isExchangeBroker
            };

            var repositoryMock = new Mock<IRepository>();
            repositoryMock.Setup(x => x.CreateAsync(company)).ReturnsAsync(() => company);
            var companyService = new CompanyService(repositoryMock.Object);

            var result = await companyService.CreateEntity(company);

            repositoryMock.Verify(x => x.CreateAsync(It.IsAny<Company>()), Times.Once);
            Assert.Equal(company, result);
        }
    }
}
