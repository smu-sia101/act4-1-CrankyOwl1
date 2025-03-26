using Microsoft.AspNetCore.Mvc;
using System;

namespace PetNameGenerator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetNameRequest
    {
        public string AnimalType { get; set; }
        public bool? TwoPart { get; set; }
    }
    public class PetNameController : ControllerBase
    {
       
        private string[] dogNames = { "Buddy", "Max", "Charlie", "Rocky", "Rex" };
        private string[] catNames = { "Whiskers", "Mittens", "Luna", "Simba", "Tiger" };
        private string[] birdNames = { "Tweety", "Sky", "Chirpy", "Raven", "Sunny" };

       [HttpPost("generate")]
        public IActionResult GenerateName(PetNameRequest request)
        {
          if (string.IsNullOrEmpty(request.AnimalType))
            {
                return BadRequest(new { error = "The 'animalType' field is required." });
            }

            string[] names = null;
            if (request.AnimalType.ToLower() == "dog")
            {
                names = dogNames;
            }
            else if (request.AnimalType.ToLower() == "cat")
            {
                names = catNames;
            }
            else if (request.AnimalType.ToLower() == "bird")
            {
                names = birdNames;
            }
            else
            {
                return BadRequest(new { error = "Invalid animal type. Allowed values: dog, cat, bird." });
            }

          
            if (request.TwoPart == true)
            {
                Random rand = new Random();
                string firstName = names[rand.Next(names.Length)];
                string secondName = names[rand.Next(names.Length)];
                return Ok(new { name = firstName + secondName });
            }

            Random random = new Random();
            string randomName = names[random.Next(names.Length)];
            return Ok(new { name = randomName });
        }
    }
  
}
