using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SearchMaxSumElement
{
    public class ValidatorInput
    {
        public string ValidateFilePath(string input)
        {            
            if (String.IsNullOrWhiteSpace(input))
            {
                return "Input path empty or null";
            }
            else
            {
                FileInfo fileInf = new FileInfo(@input);
                if (fileInf.Exists)
                {
                    return input;
                }
                else
                {
                    return "File wasn't found";
                }
            }            
        }
    }
}
