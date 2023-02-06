using BestPractice.Api.Models;
using BestPractice.Api.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BestPractice.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IContactService _contactService;
        private readonly ILogger<ContactController> _logger;

        public ContactController(IConfiguration configuration, IContactService contactService, ILogger<ContactController> logger)
        {
            _configuration = configuration;
            _contactService = contactService;
            _logger = logger;
        }
        [HttpGet]
        public string Get()
        {
            _logger.LogTrace("LogTrace -> Get method is called");
            _logger.LogDebug("LogDebug ->Get method is called");
            _logger.LogInformation("LogInformation ->Get method is called");
            _logger.LogWarning("LogWarning ->Get method is called");
            _logger.LogError("LogError ->Get method is called");

            return _configuration.GetValue<string>("SecretKey");
        }


        [ResponseCache(Duration = 5 )]
        [HttpGet("{id}")]
        public ContactDVO GetContactById(int id)
        {

            return _contactService.GetContactById(id);
        }
        [HttpPost]
        public ContactDVO CreateContact(ContactDVO contact)
        {
            //Create contact on DB
            return contact;
        }
    }
}
