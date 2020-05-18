using System;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace LBC.Configuration.Configs
{
    public static class ConfigLoader
    {
        public static Config LoadConfiguration()
        {
            Config configuration = null;

            var assembly = typeof(IConfiguration).GetTypeInfo().Assembly;
            string configName = "";

#if DEV
            configName = "config-dev.json";
#elif PROD
            configName = "config-prod.json";
#endif

            Stream embeddedResourceStream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{configName}");

            if (embeddedResourceStream == null)
                return null;

            using (var streamReader = new StreamReader(embeddedResourceStream))
            {
                var jsonString = streamReader.ReadToEnd();

                configuration = JsonConvert.DeserializeObject<Config>(jsonString);

                if (configuration == null)
                    return null;

            }

            return configuration;
        }
    }
}
