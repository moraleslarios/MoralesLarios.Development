using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using MoralesLarios.Development.Configuration;

namespace MoralesLarios.Development.Tests.Configuration
{
    public class ConfigTests
    {
        [Fact]
        public void prueba1()
        {
            object nodes = Config.ConfigNodes;
        }


    }
}
