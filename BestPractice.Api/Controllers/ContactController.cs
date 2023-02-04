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

        public ContactController(IConfiguration configuration, IContactService contactService)
        {
            _configuration = configuration;
            _contactService = contactService;
        }

        [HttpGet]
        public string Get()
        {
            return _configuration.GetValue<string>("SecretKey");
        }
        [HttpGet("{id}")]
        public ContactDVO GetContactById(int id)
        {
            return _contactService.GetContactById(id);
        }
    }
}
