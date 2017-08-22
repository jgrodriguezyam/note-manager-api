using System.Configuration;

namespace NoteManager.Infrastructure.Files.ElementConfigs
{
    public class FileInstanceElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
        public string Name
        {
            get { return (string) base["name"]; }
            set { base["name"] = value; }
        }
    }
}