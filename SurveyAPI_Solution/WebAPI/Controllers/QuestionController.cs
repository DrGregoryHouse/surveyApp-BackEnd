using Business.Implementations;
using Business.Interfaces;
using Data.Implementations;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI_REST.Controllers
{
    /// <summary>
    /// Question Controller for Web API.
    /// </summary>
    [RoutePrefix("api/question")]
    public class QuestionController : ApiController
    {
        private readonly IQuestionService _service;
        public QuestionController()
        {
            QuestionRepo repository = new QuestionRepo();
            _service = new QuestionService(repository);
        }
        /// <summary>
        /// Create a question.
        /// </summary>
        /// <param name="questionDTO"></param>
        /// <returns>IHttpActionResult</returns>
        [Route("")]
        [HttpPost]
        public IHttpActionResult Post([FromBody]QuestionDTO questionDTO)
        {
            if (questionDTO == null) return BadRequest("Request is null");

            Question question = new Question
            {
                Text = questionDTO.Text,
                CreatedDate = questionDTO.CreatedDate,
                ModifiedDate = null,
                IsActive = true,
                QuestionTypeId = questionDTO.QuestionTypeId
            };
            int id = _service.Create(question);
            if (id <= 0) return BadRequest("unable to create question.");
            var payload = new { Id = id };
            return Ok(payload);
        }
        /// <summary>
        /// Search for an entity in database given its ID
        /// </summary>
        /// <param name="id">int id [FromUri]</param>
        /// <returns>IHttpActionResult</returns>
        [Route("{id:int}")]
        [HttpGet]
        public IHttpActionResult Get([FromUri] int id)
        {
            Question question = _service.Read(id);

            if (question == null) return BadRequest("Request is null");

            QuestionDTO questionDTO = new QuestionDTO
            {
                Text = question.Text,
                CreatedDate = question.CreatedDate,
                ModifiedDate = question.ModifiedDate,
                IsActive = question.IsActive,
                QuestionTypeId = question.QuestionTypeId
            };
            return Ok(questionDTO);
        }
        /// <summary>
        /// Update an entity on database given its ID.
        /// </summary>
        /// <param name="id">int id [FromUri]</param>
        /// <param name="questionDTO">QuestionDTO [FromBody]</param>
        /// <returns></returns>
        [Route("{id:int}")]
        [HttpPut]
        public IHttpActionResult Update([FromUri] int id, [FromBody] QuestionDTO questionDTO)
        {
            if (questionDTO == null) return BadRequest("Item is null");
            Question newQuestion = new Question
            {
                Text = questionDTO.Text,
                IsActive = questionDTO.IsActive,
                QuestionTypeId = questionDTO.QuestionTypeId,
                CreatedDate = questionDTO.CreatedDate,
                ModifiedDate = questionDTO.ModifiedDate
            };
            bool result = _service.Update(newQuestion);
            if (!result) return BadRequest("Unable to update question");
            return Ok();
        }
        [Route("{id:int}")]
        [HttpDelete]
        public IHttpActionResult Delete([FromUri] int id)
        {
            var result = _service.Delete(id);

            if (!result) return BadRequest("Unable to delete question");

            return Ok();
        }
        [Route("")]
        [HttpGet]
        public IHttpActionResult ReadAll()
        {
            ICollection<Question> list = _service.ReadAll();

            if (list == null) return BadRequest("Request is null");

            ICollection<QuestionDTO> listDTO = list.Select(u => new QuestionDTO
            {
                Text = u.Text,
                CreatedDate = u.CreatedDate,
                ModifiedDate = u.ModifiedDate,
                IsActive = u.IsActive,
                QuestionTypeId = u.QuestionTypeId,
            }).ToList();
            return Ok(listDTO);
        }

        //[Route("{id:int}/survey/{survey_id:int}")]
        //[HttpPost]
        //public IHttpActionResult AddQuestionToSurvey([FromBody]int survey_id, [FromUri]int id)
        //{
        //    bool response = _service.AddQuestionToSurvey(survey_id, id);

        //    if (!response) return BadRequest("Unable to add question to survey");

        //    return Ok("question added to survey succesfully");
        //}
    }
}

