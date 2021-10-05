namespace Capa_Negocio
{
    public class BaseResponse<T>
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public T Result { get; set; }
    }
}