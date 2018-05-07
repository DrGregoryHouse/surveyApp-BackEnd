using Business.Interfaces;
using DataAccess.Interfaces;
using Domain.Entities;
using System;

namespace Business.Implementations
{
    /// <summary>
    /// Service layer for CRUD methods of Option.
    /// </summary>
    public class OptionService : IOptionService
    {
        private readonly IOptionRepo _dataRepository;
        /// <summary>
        /// Initializa a new instance of <see cref="T:Business.Implementations.OptionRepository"/>
        /// </summary>
        /// <param name="dataRepository"></param>
        public OptionService(IOptionRepo dataRepository)
        {
            _dataRepository = dataRepository;
        }
        /// <summary>
        /// Business rules for create an Option.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>int id</returns>
        public int Create(Option entity)
        {
            if (entity.Id <= 0) return 0;
            if (string.IsNullOrEmpty(entity.Text) || string.IsNullOrWhiteSpace(entity.Text)) return 0;
            bool OptionTextExist = _dataRepository.Exist(entity.Text);
            if (OptionTextExist) return 0;
            int id = _dataRepository.Create(entity);
            return id;
        }
        /// <summary>
        /// Gets an Option from a given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Option</returns>
        public Option Read(int id)
        {
            if (id <= 0) return null;
            Option option = _dataRepository.Read(id);
            if (option != null) return null;
            return option;
        }
        /// <summary>
        /// Update properties and fields on a <see cref="T:Domain.Entities.Option"/>.
        /// </summary>
        /// <param name="entity"><see cref="T:Domain.Entities.Option"/></param>
        /// <returns>boolean value</returns>
        public bool Update(Option entity)
        {
            if (entity.Id <= 0) return false;
            if (string.IsNullOrEmpty(entity.Text) || string.IsNullOrWhiteSpace(entity.Text)) return false;
            bool OptionTextExist = _dataRepository.Exist(entity.Text);
            if (OptionTextExist) return false;
            bool response = _dataRepository.Update(entity);
            return response;
        }
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
