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
            var description = type.GetCustomAttribute<ApiDescriptionAttribute>();
            if (description == null)
                return null;

            return description.Description;
        }

        public string[] GetApiMethodNames()
        {
            Type type = typeof(T);
            var methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance);

            var names = new List<string>();
            foreach (var method in methods)
            {
                if (method.GetCustomAttribute<ApiMethodAttribute>() != null)
                    names.Add(method.Name);
            }

            return names.ToArray();
        }

        public string GetApiMethodDescription(string methodName)
        {
            Type type = typeof(T);
            var method = type.GetMethod(methodName);
            if (method == null) return null;

            var description = method.GetCustomAttribute<ApiDescriptionAttribute>();

            if (description == null) return null;
            return description.Description;
        }

        public string[] GetApiMethodParamNames(string methodName)
        {
            Type type = typeof(T);
            var method = type.GetMethod(methodName);
            if (method == null) return null;

            var ListOfParam = method.GetParameters();

            var names = new List<string>();
            foreach (var param in ListOfParam)
            {
                names.Add(param.Name);
            }

            return names.ToArray();
        }

        public string GetApiMethodParamDescription(string methodName, string paramName)
        {
            Type type = typeof(T);
            var method = type.GetMethod(methodName);
            if (method == null) return null;

            var paramInfo = GetParamInfo(method, paramName);
            if (paramInfo == null) return null;

            var description = paramInfo.GetCustomAttribute<ApiDescriptionAttribute>();
            if (description == null) return null;

            return description.Description;
        }

        public ApiParamDescription GetApiMethodParamFullDescription(string methodName, string paramName)
        {
            Type type = typeof(T);
            var method = type.GetMethod(methodName);
            if (method == null)
                return DefaultParamDescription(paramName);

            var paramInfo = GetParamInfo(method, paramName);
            if (paramInfo == null) return DefaultParamDescription(paramName);

            return GetApiParamDescription(paramInfo, paramName);
        }

        public ApiMethodDescription GetApiMethodFullDescription(string methodName)
        {
            Type type = typeof(T);
            var method = type.GetMethod(methodName);
            if (method == null) return null;

            if (method.GetCustomAttribute<ApiMethodAttribute>() == null)
                return null;    // ApiMethodAttribute is missing

            var fullMethodDescription = DefaultApiMethodDescription(methodName);

            var description = method.GetCustomAttribute<ApiDescriptionAttribute>();
            if (description != null)
                fullMethodDescription.MethodDescription.Description = description.Description;

            // Add parameters' descriptions
            var paramInfoArray = method.GetParameters();

            var paramDescriptionArray = new List<ApiParamDescription>();
            foreach (var paramInfo in paramInfoArray)
            {
                paramDescriptionArray.Add(GetApiParamDescription(paramInfo, paramInfo.Name));
            }

            fullMethodDescription.ParamDescriptions = paramDescriptionArray.ToArray();

            // Add return description
            if (method.ReturnType == typeof(void))
                fullMethodDescription.ReturnDescription = null;
            else
            {
                var returnParamInfo = method.ReturnParameter;
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

        private ParameterInfo GetParamInfo(MethodInfo methodInfo, string paramName)
            => methodInfo.GetParameters().FirstOrDefault(p => p.Name == paramName);

        private ApiParamDescription DefaultParamDescription(string paramName)
            => new ApiParamDescription
            {
                ParamDescription = new CommonDescription(paramName),
                Required = false,
                MinValue = null,
                MaxValue = null
            };

        private ApiMethodDescription DefaultApiMethodDescription(string methodName)
            => new ApiMethodDescription
            {
                MethodDescription = new CommonDescription(methodName)
            };

        private ApiParamDescription GetApiParamDescription(ParameterInfo paramInfo, string paramName)
        {
            var fullParamDescription = DefaultParamDescription(paramName);

            var paramDescription = paramInfo.GetCustomAttribute<ApiDescriptionAttribute>();
            if (paramDescription != null)   // Parameter has description attribute
                fullParamDescription.ParamDescription.Description = paramDescription.Description;

            var paramIsRequired = paramInfo.GetCustomAttribute<ApiRequiredAttribute>();
            if (paramIsRequired != null)    // Parameter has requiredness attribute
                fullParamDescription.Required = paramIsRequired.Required;

            var paramIntValidation = paramInfo.GetCustomAttribute<ApiIntValidationAttribute>();
            if (paramIntValidation != null) // Parameter has int validation
            {
                fullParamDescription.MinValue = paramIntValidation.MinValue;
                fullParamDescription.MaxValue = paramIntValidation.MaxValue;
            }

            return fullParamDescription;
        }
    }
}