using Capa_Entidad;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{
    public class FileUploader : IFileUploader
    {
        private readonly IOptions<AppSetting> _options;

        public FileUploader(IOptions<AppSetting> options )
        {
            _options = options;
        }
        public async Task<string> UploadAsync(string base64String, string filename)
        {
            try
            {
                var bytes = Convert.FromBase64String(base64String);
                var path = Path.Combine(_options.Value.StorageConfiguration.Path, filename);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await fileStream.WriteAsync(bytes, 0, bytes.Length);
                }

                return $"{_options.Value.StorageConfiguration.PublicUrl}{filename}";
            }
            catch (Exception ex)
            {

                //logger.LogCritical(ex.Message);
                return string.Empty;
            }

        }
    }
}
