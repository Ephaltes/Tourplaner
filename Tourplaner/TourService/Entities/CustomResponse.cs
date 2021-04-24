namespace TourService.Entities
{
    public class CustomResponse
    {
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public bool IsSuccess => StatusCode == 200;
        public virtual bool HasData => false;
        
        public virtual object GetData() => null;
        public static CustomResponse<T> Success<T>(T data) =>  new () {StatusCode = 200, Data = data};

        public static CustomResponse<T> Error<T>(int statusCode,string errorMessage="")
        {
            return new() {ErrorMessage = errorMessage, StatusCode = statusCode};
        }
        
        public void BadRequest(string errorMessage)
        {
            StatusCode = 400;
            ErrorMessage = errorMessage;
        }
        
    }

    public class CustomResponse<T> : CustomResponse
    {
        public T Data { get; init; }
        public override bool HasData => true;
        public override object GetData() => Data;
    }

}