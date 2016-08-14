using wwwmy.Config;

namespace wwwmy.Models
{
    public class TestViewModel 
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }

        public TestConfig Options { get; set; }
    }
} 