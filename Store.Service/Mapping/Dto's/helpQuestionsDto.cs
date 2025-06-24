using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Mapping.Dto_s
{
    public class helpQuestionsDto
    {
        public int helpQuestionId { get; set; }
        public string question_en { get; set; }
        public string question_ar { get; set; }
        public string answer_en { get; set; }
        public string answer_ar { get; set; }
    }
}
