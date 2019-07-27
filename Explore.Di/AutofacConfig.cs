using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace Explore.Di
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();


            var containerr = builder.Build();

        }
    }
}
