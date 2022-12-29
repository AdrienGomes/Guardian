using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GuardianProject.Common.SpecificServices.Contract
{
    /// <summary>
    /// Base service contract that forms any services from mobile native code. It assumes any services could permissions from devices and need to ask them if they are not already granted
    /// </summary>
    /// <remarks> Any services should inherit from an implementation of that contract</remarks>
    public interface IBaseService
    {
        /// <summary>
        /// Requests permissions for associated service
        /// </summary>
        /// <param name="permissions">List of permission's code</param>
        Task RequestPermissionsAsync(IEnumerable<string> permissions);

        /// <summary>
        /// Aims to call a service method with a common default behavior and error handling. 
        /// It should use the <see cref="RequestPermissionsAsync(IEnumerable{string})"/> before calling the service method. 
        /// It should log error thanks to an <see cref="ILogger"/>
        /// </summary>
        /// <param name="method"> The service method to be called. Used as an <see cref="Action"/> : (param) => MethodWithParam(param) </param>
        /// <returns>It returns what the service method returns (this method is awaitable) </returns>
        /// <remarks> To use correctly a service, call any service method through this <see cref="Call(Action)"/> method</remarks>
        Task<object> Call(Func<object> method);

    }
}
