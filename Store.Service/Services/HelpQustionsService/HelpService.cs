using AutoMapper;
using Store.Data.Entities;
using Store.Repository.Interfaces;
using Store.Services.Mapping.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Services.HelpQustionsService
{
    public class HelpService : IHelpService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public HelpService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<helpQuestionsDto> CreatehelpQuestionsAsync(helpQuestionsDto helpQuestionsDto)
        {
            if (helpQuestionsDto == null)
                throw new ArgumentNullException("Not Found");
            try
            {
                var helpQuestions = _mapper.Map<HelpQuestions>(helpQuestionsDto);
                await _unitOfWork.HelpQuestions.AddAsync(helpQuestions);
                await _unitOfWork.SaveChanges();
                return _mapper.Map<helpQuestionsDto>(helpQuestions);
            }
            catch (Exception ex)
            {

                throw new Exception("Creating Failed", ex);
            }
        }

        public async Task<helpQuestionsDto> DeletehelpQuestionsAsync(int? Id)
        {
            if (Id is null)
                throw new ArgumentNullException("Id is Null");
            try
            {
                var helpQuestions = await _unitOfWork.HelpQuestions.GetByIdAsync(Id);
                if (helpQuestions is null)
                    throw new Exception("Id is null");
                await _unitOfWork.HelpQuestions.DeleteAsync(helpQuestions);
                await _unitOfWork.SaveChanges();
                return _mapper.Map<helpQuestionsDto>(helpQuestions);
            }
            catch (Exception ex)
            {

                throw new Exception("Delete Failed", ex);
            }
        }

        public async Task<IEnumerable<helpQuestionsDto>> GetAllhelpQuestionsAsync()
        {
            var helpQuestions = await _unitOfWork.HelpQuestions.GetAllAsync();
            return _mapper.Map<IEnumerable<helpQuestionsDto>>(helpQuestions);
        }


        public async Task<helpQuestionsDto> GethelpQuestionsByIdAsync(int? Id)
        {
            if (Id is null)
                throw new ArgumentNullException("Id is Null");
            try
            {
                var helpQuestions = await _unitOfWork.HelpQuestions.GetByIdAsync(Id);
                if (helpQuestions is null)
                    throw new Exception("helpQuestions Not Found");
                return _mapper.Map<helpQuestionsDto>(helpQuestions);
            }
            catch (Exception ex)
            {

                throw new Exception("helpQuestions Not Found", ex);
            }
        }

        public async Task<helpQuestionsDto> UpdatehelpQuestionsAsync(int? id, helpQuestionsDto helpQuestionsDto)
        {
            if (helpQuestionsDto == null)
                throw new ArgumentNullException(nameof(helpQuestionsDto), "HelpQuestionId cannot be null.");

            try
            {
                var helpQuestions = await _unitOfWork.HelpQuestions.GetByIdAsync(id);
                if (helpQuestions == null)
                    throw new Exception($"helpQuestions with Id {id} not found.");
                _mapper.Map(helpQuestionsDto, helpQuestions);
                await _unitOfWork.HelpQuestions.UpdateAsync(helpQuestions);
                await _unitOfWork.SaveChanges();
                return _mapper.Map<helpQuestionsDto>(helpQuestions);
            }
            catch (Exception ex)
            {

                throw new Exception("Update Failed", ex);
            }


        }
    }
}
