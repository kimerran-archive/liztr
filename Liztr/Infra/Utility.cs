using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Liztr.Infra
{
    public static class Utility
    {
        public static string ToSeoFriendly(string title, int maxLength)
        {
            var match = Regex.Match(title.ToLower(), "[\\w]+");
            StringBuilder result = new StringBuilder("");
            bool maxLengthHit = false;
            while (match.Success && !maxLengthHit)
            {
                if (result.Length + match.Value.Length <= maxLength)
                {
                    result.Append(match.Value + "-");
                }
                else
                {
                    maxLengthHit = true;
                    // Handle a situation where there is only one word and it is greater than the max length.
                    if (result.Length == 0) result.Append(match.Value.Substring(0, maxLength));
                }
                match = match.NextMatch();
            }
            // Remove trailing '-'
            if (result[result.Length - 1] == '-') result.Remove(result.Length - 1, 1);
            return result.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="status">Determines if request is successful</param>
        /// <param name="result">The object</param>
        /// <param name="allowed">Are you allowed to modify it</param>
        /// <returns></returns>
        public static object CreateJson(bool status, object result, bool allowed)
        {
            return new
            {
                s = status,
                r = result,
                a = allowed
            };
        }
    }
}