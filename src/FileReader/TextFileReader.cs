﻿using System.IO;
using FileReader.Interfaces;
using FileReader.Models;

namespace FileReader
{
    public class TextFileReader : ITextFileReader
    {
        private readonly IFile _file;

        public TextFileReader()
        {
            _file = new TextFile();
        }

        public string ReadTextFile()
        {
            using (var file = File.OpenText(_file.FilePath))
            {
                return file.ReadToEnd();
            }
        }
    }
}