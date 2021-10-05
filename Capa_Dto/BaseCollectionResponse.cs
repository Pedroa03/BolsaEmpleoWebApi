using System.Collections.Generic;

namespace Capa_Dto
{
    public class BaseCollectionResponse<TDtoClass>
    {
        public ICollection<TDtoClass> Collection { get; set; }
        public int TotalPages { get; set; }

        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
    }
}