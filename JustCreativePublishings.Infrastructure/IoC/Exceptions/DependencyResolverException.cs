using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustCreativePublishings.Infrastructure.IoC.Exceptions
{
    public class DependencyResolverException : Exception
    {
        public DependencyResolverException(string message, Exception innerException) : base(message, innerException){}

        public DependencyResolverException(string message) : base(message){}
    }
}
