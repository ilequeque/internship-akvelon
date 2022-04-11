using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Documentation
{
    public class Specifier<T> : ISpecifier
    {
        public string GetApiDescription()
        {
            Type type = typeof(T);
            var descriptionAttr = type.GetCustomAttribute<ApiDescriptionAttribute>();
            if (descriptionAttr == null)
                return null;

            return descriptionAttr.Description;
        }

        public string[] GetApiMethodNames()
        {
            Type type = typeof(T);
            var methodInfoArray = type.GetMethods(BindingFlags.Instance | BindingFlags.Public);

            var methodNames = new List<string>();
            foreach (var methodInfo in methodInfoArray)
            {
                if (methodInfo.GetCustomAttribute<ApiMethodAttribute>() != null)
                    methodNames.Add(methodInfo.Name);
            }

            return methodNames.ToArray();
        }

        public string GetApiMethodDescription(string methodName)
        {
            var methodInfo = GetMethodInfo(methodName);
            if (methodInfo == null)
                return null;    // Method does not exist

            var methodDescription = methodInfo.GetCustomAttribute<ApiDescriptionAttribute>();
            if (methodDescription == null)
                return null;    // Method exists, but does not have description attribute  

            return methodDescription.Description;
        }

        public string[] GetApiMethodParamNames(string methodName)
        {
            var methodInfo = GetMethodInfo(methodName);
            if (methodInfo == null)
                return null;    // Method does not exist

            var methodParams = methodInfo.GetParameters();

            var paramNames = new List<string>();
            foreach (var paramInfo in methodParams)
            {
                paramNames.Add(paramInfo.Name);
            }

            return paramNames.ToArray();
        }

        public string GetApiMethodParamDescription(string methodName, string paramName)
        {
            var methodInfo = GetMethodInfo(methodName);
            if (methodInfo == null)
                return null;    // Method does not exist

            var paramInfo = GetParamInfo(methodInfo, paramName);
            if (paramInfo == null)
                return null;    // Parameter with paramName does not exist

            var paramDescription = paramInfo.GetCustomAttribute<ApiDescriptionAttribute>();
            if (paramDescription == null)
                return null;    // Parameter does not have description attribute

            return paramDescription.Description;
        }

        public ApiParamDescription GetApiMethodParamFullDescription(string methodName, string paramName)
        {
            var methodInfo = GetMethodInfo(methodName);
            if (methodInfo == null)
                return DefaultParamDescription(paramName);    // Method does not exist

            var paramInfo = GetParamInfo(methodInfo, paramName);
            if (paramInfo == null)
                return DefaultParamDescription(paramName);    // Parameter with paramName does not exist

            // At this point, method and parameter do exist          
            return GetApiParamDescription(paramInfo, paramName);
        }

        public ApiMethodDescription GetApiMethodFullDescription(string methodName)
        {
            var methodInfo = GetMethodInfo(methodName);
            if (methodInfo.GetCustomAttribute<ApiMethodAttribute>() == null)
                return null;    // ApiMethodAttribute is missing

            var fullMethodDescription = DefaultApiMethodDescription(methodName);

            var description = methodInfo.GetCustomAttribute<ApiDescriptionAttribute>();
            if (description != null)
                fullMethodDescription.MethodDescription.Description = description.Description;

            // Add parameters' descriptions
            var paramInfoArray = methodInfo.GetParameters();

            var paramDescriptionArray = new List<ApiParamDescription>();
            foreach (var paramInfo in paramInfoArray)
            {
                paramDescriptionArray.Add(GetApiParamDescription(paramInfo, paramInfo.Name));
            }

            fullMethodDescription.ParamDescriptions = paramDescriptionArray.ToArray();

            // Add return description
            if (methodInfo.ReturnType == typeof(void))
                fullMethodDescription.ReturnDescription = null;
            else
            {
                var returnParamInfo = methodInfo.ReturnParameter;
                var returnIntValidation = returnParamInfo.GetCustomAttribute<ApiIntValidationAttribute>();

                var returnDescription = new ApiParamDescription
                {
                    ParamDescription = new CommonDescription(),
                    Required = returnParamInfo.GetCustomAttribute<ApiRequiredAttribute>()?.Required ?? false,
                    MinValue = returnIntValidation?.MinValue ?? null,
                    MaxValue = returnIntValidation?.MaxValue ?? null
                };

                fullMethodDescription.ReturnDescription = returnDescription;
            }

            return fullMethodDescription;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="methodName"></param>
        /// <returns></returns>
       
    }
}