using System;
using wwwmy.Interfaces.Repositories;

namespace wwwmy.DataLayer
{
    public class TestRepo : ITestRepo
    {
        public string TestRepoMethod(string parameter)
        {
            return parameter;
        }
    }
}