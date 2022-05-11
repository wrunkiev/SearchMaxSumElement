using System;
using System.Collections.Generic;
using System.Text;

namespace SearchMaxSumElement
{
    public class ProgramManager : IProgramManager
    {
        private readonly IDocument _doc;
        private readonly IFileService _fileService;
        private readonly IWriter _wc;
        private readonly IDocumentHelper _dh;

        public ProgramManager()
        {
            _doc = new Document();
            _fileService = new FileService();
            _wc = new WriteConsole();
            _dh = new DocumentHelper();
        }

        public void Start(string[] args) 
        {
            string message;

            if (args.Length == 0)
            {
                PrintWelcome();
                message = _wc.ReadLine();
            }
            else
            {
                message = args[0];
            }

            string [] linesFromFile = _fileService.GetFileContent(message);
            _doc.Init(linesFromFile);

            PrintResult();
        }

        private void PrintWelcome()
        {
            _wc.WriteLine("Welcome to programm 'Search'");
            _wc.Write("Enter path to file: ");
        }

        private void PrintResult()
        {            
            var itemMax = _doc.GetDocumentMaxValue();
            var lineNumber = itemMax.lineNumber;
            
            var documentNonNumber = _doc.GetDocumentNonNumber();
            var stringNonNumber = _dh.GetStringNonNumber(documentNonNumber);           

            string result = @$"String number with max value: 
                ${lineNumber}

                List defective strings: 
                ${stringNonNumber}";

            _wc.WriteLine(result);
        }
    }
}
