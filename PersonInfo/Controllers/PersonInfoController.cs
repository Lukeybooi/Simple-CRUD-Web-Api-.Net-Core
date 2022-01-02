using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PersonInfo.Dtos;
using PersonInfo.Enums;
using PersonInfo.Helpers;
using PersonInfo.Models;
using PersonInfo.Repository;
using System;
using System.Collections.Generic;

namespace PersonInfo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonInfoController : ControllerBase
    {
        private readonly IPersonRepo _repository;
        private readonly IMapper _mapper;

        public PersonInfoController(IPersonRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult<Person> CreatePerson(PersonCreateDto person)
        {
            var newPerson = _repository.CreatePerson(_mapper.Map<Person>(person));
            if (!_repository.SaveChanges()) { return BadRequest(); }

            return CreatedAtRoute(nameof(GetPersonById), new { Id = newPerson.Id },
                ManualMapping.MapReadPerson(newPerson));
        }

        [HttpGet]
        public ActionResult<IEnumerable<PersonReadDto>> GetAllPeople()
        {
            return Ok(ManualMapping.MapReadPerson(_repository.GetAllPeople()));
        }

        [HttpGet("{id}", Name = "GetPersonById")]
        public ActionResult<IEnumerable<PersonReadDto>> GetPersonById(Guid id)
        {
            var person = ManualMapping.MapReadPerson(_repository.GetPersonById(id));

            if (person == null) { return NotFound(); }

            return Ok(person);
        }

        [HttpPut("{id}")]
        public ActionResult UpdatePerson(Guid id, PersonCreateDto person)
        {
            _repository.UpdatePerson(new Person
            {
                Id = id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Dob = (DateTime)person.Dob,
                Gender = (Gender)person.Gender,
                Race = person?.Race != 0 ? person.Race : Race.Other
            });
            if (!_repository.SaveChanges()) { return NotFound(); }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePersonById(Guid id)
        {
            _repository.DeletePerson(id);
            if (!_repository.SaveChanges()) { return NotFound(); }

            return NoContent();
        }

        [HttpPost("{amt}")]
        public ActionResult AddDummyData(string amt)
        {
            short value;
            short.TryParse(amt, out value);

            _repository.AddDummyData(value);
            if (!_repository.SaveChanges()) { return NotFound(); }

            return NoContent();
        }
    }
}
