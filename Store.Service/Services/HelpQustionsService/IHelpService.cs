using Store.Services.Mapping.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Services.HelpQustionsService
{
    public interface IHelpService
    {
        Task<helpQuestionsDto> CreatehelpQuestionsAsync(helpQuestionsDto helpQuestionsDto);
        Task<helpQuestionsDto> UpdatehelpQuestionsAsync(int? id, helpQuestionsDto helpQuestionsDto);
        Task<helpQuestionsDto> DeletehelpQuestionsAsync(int? Id);
        Task<helpQuestionsDto> GethelpQuestionsByIdAsync(int? Id);
        Task<IEnumerable<helpQuestionsDto>> GetAllhelpQuestionsAsync();
    }
}
