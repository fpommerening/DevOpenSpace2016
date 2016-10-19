using System;
using System.Collections;

namespace FP.DevSpace2016.PicFlow.Contracts
{
    public class EnvironmentVariable
    {
        public static string GetValueOrDefault(string key, string defaultValue)
        {
            foreach (DictionaryEntry de in Environment.GetEnvironmentVariables())
            {
                if (de.Key?.ToString() == key)
                {
                    return de.Value.ToString();
                }
            }
            return defaultValue;
        }
    }
}
