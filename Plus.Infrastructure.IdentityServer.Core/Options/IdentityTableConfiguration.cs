
namespace Plus.Infrastructure.IdentityServer.Core.Options
{
    
    public class IdentityTableConfiguration
    {
       
        public IdentityTableConfiguration(string name)
        {
            Name = name;
        }
        
        public IdentityTableConfiguration(string name, string schema)
        {
            Name = name;
            Schema = schema;
        }
      
        public string Name { get; set; }
        
        public string Schema { get; set; }
    }
}