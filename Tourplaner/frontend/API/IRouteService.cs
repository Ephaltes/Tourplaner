namespace frontend.API
{
    public interface IRouteService
    {
        public byte[] GetRouteImage(string origin, string destination);
    }
}