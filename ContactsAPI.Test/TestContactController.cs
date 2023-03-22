using AutoMapper;
using ContactAPI.AutoMapper;
using ContactAPI.Controllers;
using ContactAPI.DTO;
using ContactAPI.Interfaces;
using ContactAPI.Models;
using ContactsAPI.Test.MockData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;



namespace ContactsAPI.Test
{
    public class TestContactController
    {
       

        [Fact]
        public async Task GetAllAsync_ShouldReturn200()
        {
            //arrange
            var contactService = new Mock<IContactService>();
            var logger = new Mock<ILogger<ContactController>>();
            var autoMapper = new Mock<IMapper>();

            contactService.Setup(_ => _.GetContactsAsync()).ReturnsAsync(ContactMockData.GetContacts());
            var contactController = new ContactController(contactService.Object, logger.Object, autoMapper.Object);

            //act
            var result = await contactController.GetContacts();

            //assert

            Assert.IsType<OkObjectResult>(result.Result);

        }

        [Fact]
        public async Task GetAsync_ShouldReturn200()
        {
            // arrange
            var contactService = new Mock<IContactService>();
            var logger = new Mock<ILogger<ContactController>>();
            var autoMapper = new Mock<IMapper>();

            contactService.Setup(_ => _.GetContactByIdAsync(1)).Returns(ContactMockData.GetContact());
            var contactController = new ContactController(contactService.Object, logger.Object, autoMapper.Object);

            // act
            var result = await contactController.GetContact(1);

            //assert
            Assert.IsType<OkObjectResult>(result.Result);

        }

        [Fact]
        public async void Create_ReturnsCreatedAtActionResult()
        {
            // arrange
            var contactService = new Mock<IContactService>();
            var logger = new Mock<ILogger<ContactController>>();
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutomapperProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();

            var contact = new Contact
            {
                Id = 1,
                LastChangeTimestamp = 0,
                FirstName = "Oshadhi",
                LastName = "Liyanage",
                Salutation = "Miss",
                DisplayName = "Oshadhi",
                Birthday = new DateTime(1996, 05, 09, 9, 15, 0),
                Email = "gayangikaoshadhi@gmail.com",
                PhoneNumber = "1234567890",
            };
            contactService.Setup(_ => _.CreateContactAsync(contact)).Returns(ContactMockData.GetContact());
            var contactController = new ContactController(contactService.Object, logger.Object, mapper);

            var contactDto = mapper.Map<ContactDto>(contact);
            // act
            var result = await contactController.CreateContact(contactDto);

            // assert
            Assert.IsType<CreatedAtActionResult>(result.Result);

        }

        [Fact]
        public async void Update_ReturnsOkResult()
        {
            // arrange
            var contactService = new Mock<IContactService>();
            var logger = new Mock<ILogger<ContactController>>();
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutomapperProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();

            var contact = new Contact
            {
                Id = 1,
                LastChangeTimestamp = 0,
                FirstName = "Oshadhi",
                LastName = "Liyanage",
                Salutation = "Miss",
                DisplayName = "Oshadhi",
                Birthday = new DateTime(1996, 05, 09, 9, 15, 0),
                Email = "gayangikaoshadhi@gmail.com",
                PhoneNumber = "1234567890",
            };
            contactService.Setup(_ => _.UpdateContactAsync(contact)).Returns(ContactMockData.GetContact());
            var contactController = new ContactController(contactService.Object, logger.Object, mapper);

            // act
            var result = await contactController.UpdateContact(1, contact);

            // assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async void Delete_ReturnsNoContentResult()
        {
            // arrange
            var contactService = new Mock<IContactService>();
            var logger = new Mock<ILogger<ContactController>>();
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutomapperProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();

            contactService.Setup(_ => _.GetContactByIdAsync(1)).Returns(ContactMockData.GetContact());
            contactService.Setup(_ => _.DeleteContactAsync(1));
            var contactController = new ContactController(contactService.Object, logger.Object, mapper);

            // act
            var result = await contactController.DeleteContact(1);

             // assert
            Assert.IsType<NoContentResult>(result);

        }

    }

}
