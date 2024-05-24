using CarQuery__Test.Domain.Models;
using CarQuery__Test.Domain.Services;
using CarQuery__Test.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarQuery__Test.Controllers
{

    [Route("Person")]
    public class PersonController : ControllerBase 
    {

        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet] //Get all persons
        public async Task<IActionResult> GetAllPersons()
        {
            try
            {
                var persons = await _personService.GetAllPersonsAsync();
                if (persons == null || !persons.Any())
                {
                    return NotFound("No person found.");
                }
                return Ok(persons);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpGet("{id}")] //Get person by id
        public async Task<IActionResult> GetPerson(int id)
        {
            try
            {
                var person = await _personService.GetPersonByIdAsync(id);
                if (person == null)
                {
                    return NotFound($"Person not found.");
                }
                return Ok(person);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost] //Create a new person
        public async Task<IActionResult> CreatePerson([FromBody] Person person)
        {
            try
            {
                var createdPerson = await _personService.CreatePersonAsync(person);
                if (createdPerson == null)
                {
                    return BadRequest("Invalid JSON format");
                }
                else
                {
                    return Ok($"Person created successfully.");
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")] //Update a person
        public async Task<IActionResult> UpdatePerson(int id, [FromBody] Person person)
        {

            try
            {
                var updatedPerson = await _personService.UpdatePersonAsync(id, person);
                if (updatedPerson == null)
                {
                    return NotFound($"Failed to update person.");
                }
                return Ok($"Person updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")] //Delete a person
        public async Task<IActionResult> DeletePerson(int id)
        {
            try
            {
                var result = await _personService.DeletePersonAsync(id);
                if (result == false)
                {
                    return NotFound($"Person not found.");
                }
                return Ok($"Person ID ({id}) deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }

    
}
