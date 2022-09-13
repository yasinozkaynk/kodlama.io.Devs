using Application.Features.programmingLanguage.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.programmingLanguage.Model
{
    public  class ProgrammingLanguageListModel:BasePageableModel
    {
        public IList<ProgrammingLanguageListDto> items { get; set; }
    }
}
