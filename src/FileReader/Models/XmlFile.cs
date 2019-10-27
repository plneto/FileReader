﻿using FileReader.Constants;

namespace FileReader.Models
{
    internal class XmlFile : IFile
    {
        public XmlFile()
        {
            FilePath = FilePaths.XmlFilePath;
        }

        public string FilePath { get; }
    }
}