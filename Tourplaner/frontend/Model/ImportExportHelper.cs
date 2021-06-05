using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using frontend.Extensions;
using Newtonsoft.Json;
using TourService.Entities;

namespace frontend.Model
{
    public class ImportExportHelper
    {
        public static async Task<bool> Export(RouteModel modelToExport, string path)
        {
            var entity = modelToExport.ToEntity();
            var output = JsonConvert.SerializeObject(entity, Formatting.Indented);
            await File.WriteAllTextAsync(path, output);
            return true;
        }

        public static async Task<List<RouteEntity>> Import(string[] fileToImport)
        {
            var ret = new List<RouteEntity>();

            foreach (var file in fileToImport)
            {
                if (!File.Exists(file))
                    continue;

                var text = await File.ReadAllTextAsync(file);
                var entity = JsonConvert.DeserializeObject<RouteEntity>(text);
                if (entity != null)
                    ret.Add(entity);
            }
            return ret;
        }
    }
}