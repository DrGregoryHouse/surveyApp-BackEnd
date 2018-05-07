using Business.Implementations;
using Business.Interfaces;
using Data.Implementations;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    /// <summary>
    /// Survey Controller for Web API.
    /// </summary>
    [RoutePrefix("api/survey")]
    public class SurveyController : ApiController
    {
        private readonly ISurveyService _service;
        public SurveyController()
        {
            SurveyRepo repository = new SurveyRepo();
            _service = new SurveyService(repository);
        }
        /// <summary>
        /// Create a survey.
        /// </summary>
        /// <param name="surveyDTO"></param>
        /// <returns>IHttpActionResult</returns>
        [Route("")]
        [HttpPost]
        public IHttpActionResult Post([FromBody]SurveyDTO surveyDTO)
        {
            if (surveyDTO == null) return BadRequest("Request is null");
            Survey entity = new Survey
            {
                Title = surveyDTO.Title,
                Description = surveyDTO.Description,
                CreatedDate = surveyDTO.CreatedDate,
                ModifiedDate = null,
                IsActive = true,
                StatusId = surveyDTO.StatusId,
                //Status = surveyDTO.Status
            };
            int id = _service.Create(entity);
            if (id <= 0) return BadRequest("unable to create entity.");
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
            Survey entity = _service.Read(id);

            if (entity == null) return BadRequest("Request is null");

            SurveyDTO surveyDTO = new SurveyDTO
            {
                Title = entity.Title,
                Description = entity.Description,
                CreatedDate = entity.CreatedDate,
                ModifiedDate = entity.ModifiedDate,
                IsActive = entity.IsActive,
                StatusId = entity.StatusId,
                //Status = entity.Status
            };
            return Ok(surveyDTO);
        }

        [Route("")]
        [HttpGet]
        public IHttpActionResult ReadAll()
        {
            ICollection<Survey> list = _service.ReadAll();

            if (list == null) return BadRequest("Request is null");

            ICollection<SurveyDTO> listDTO = list.Select(u => new SurveyDTO
            {
                Title = u.Title,
                Description = u.Description,
                CreatedDate = u.CreatedDate,
                ModifiedDate = u.ModifiedDate,
                IsActive = u.IsActive,
                StatusId = u.StatusId,
                //Status = u.Status,
            }).ToList();
            return Ok(list);
        }

        /// <summary>
        /// Update an entity on database given its ID.
        /// </summary>
        /// <param name="id">int id [FromUri]</param>
        /// <param name="surveyDTO">SurveyDTO [FromBody]</param>
        /// <returns></returns>
        [Route("{id:int}")]
        [HttpPut]
        public IHttpActionResult Update([FromUri] int id, [FromBody] SurveyDTO surveyDTO)
        {
            if (surveyDTO == null) return BadRequest("Survey is null");
            Survey entity = new Survey
            {
                Title = surveyDTO.Title,
                Description = surveyDTO.Description,
                CreatedDate = surveyDTO.CreatedDate,
                ModifiedDate = surveyDTO.ModifiedDate,
                //IsActive = surveyDTO.IsActive,
                //StatusId = surveyDTO.StatusId,
                //Status = surveyDTO.Status,
            };
            bool result = _service.Update(entity);
            if (!result) return BadRequest("Unable to update entity");
            return Ok();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id:int}")]
        [HttpDelete]
        public IHttpActionResult Delete([FromUri] int id)
        {
            var result = _service.Delete(id);
            if (!result) return BadRequest("Unable to delete entity");
            return Ok();
        }
        /// <summary>
        /// Shows all Questions in a survey 
        /// </summary>
        /// <param name="id">int survey ID</param>
        /// <returns>HttpActionResult</returns>
        //[Route("{id:int}/questions/")]
        //[HttpGet]
        //public IHttpActionResult GetQuestionBySurvey([FromUri]int id)
        //{
        //    ICollection<Question> questionList = _service.GetQuestionsBySurveyId(id);

        //    if (questionList == null) return BadRequest("The item don't have tags");

        //    ICollection<QuestionDTO> questionListDTO = questionList.Select(u => new QuestionDTO
        //    {
        //        Text = u.Text,
        //        CreatedDate = u.CreatedDate,
        //        ModifiedDate = u.ModifiedDate,
        //        IsActive = u.IsActive,
        //        StatusId = u.StatusId,
        //        QuestionTypeId = u.QuestionTypeId
        //    }).ToList();

        //    return Ok(questionListDTO);
        //}
    }
}
