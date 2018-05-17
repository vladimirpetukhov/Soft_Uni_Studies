
using NeedForSpeed.Interfaces;
using System;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;
public class ParametersGatherer
{
    

    public object[] ReturnParsedParams(object type,IList<string> arguments)
    {
        MethodInfo methodTaker = type
            .GetType()
            .GetMethods()
            .First();
        ParameterInfo[] getParams = methodTaker.GetParameters();

        string[] nonParsedParams = arguments.Skip(1).ToArray();

        object[] parsedParams = new object[getParams.Length];

        for (int i = 0; i < getParams.Length; i++)
        {
            Type currentParamType = getParams[i].ParameterType; //Take type of the current param in method

            string toConvert = nonParsedParams[i];  //Take first param to converting

            parsedParams[i] = Convert.ChangeType(toConvert, currentParamType);  //Convert and add to parsedParams
        }

        return parsedParams;
    }
}

