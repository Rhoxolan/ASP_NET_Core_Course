namespace _2023._01._23_PW.Extensions
{
    public static class ConfigurationManagerExtensions
    {
        public static IConfigurationBuilder AddStudentConfigs(this ConfigurationManager configuration)
            => configuration.AddJsonFile("student.json")
            .AddXmlFile("student.xml");
    }
}
