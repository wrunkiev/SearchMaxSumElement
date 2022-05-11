using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SearchMaxSumElement
{
    public class FileService : IFileService
    {
        private ValidatorInput _validator;
        public string[] GetFileContent(string path)
        {
            _validator = new ValidatorInput();
            string validPath = _validator.ValidateFilePath(path);
            return File.ReadAllLines(validPath); 
        }        
    }
}
