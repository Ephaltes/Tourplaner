using System.Threading.Tasks;

namespace TourService.RazorToString
{
    /// <summary>
    /// Rendering Engine to Display Razor View as string
    /// </summary>
    public interface IViewRenderService
    {
        /// <summary>
        /// Converts the Razor View into a string
        /// </summary>
        /// <param name="viewName">Name of the View</param>
        /// <param name="model">Model to be used by the View</param>
        /// <returns>html as string</returns>
        Task<string> RenderToStringAsync(string viewName, object model);
    }
}