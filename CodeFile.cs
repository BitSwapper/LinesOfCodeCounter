using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinesOfCodeCounter;
public class CodeFile
{
    FileInfo fileInfo;
    public string fileLocation;
    public string fileName;
    public string fileExtension;
    public string longestLineOfCodeTxtInfo;
    public long totalLinesOfCode = 0;
    public long totalCharacterCount = 0;
    public long longestLineOfCode = 0;

    public CodeFile(FileInfo fileInfo)
    {
        this.fileInfo = fileInfo;

        if(fileInfo.Name.Length == 0) return;
        if(fileInfo.Name.Contains("."))
            fileName = fileInfo.Name.Substring(0, fileInfo.Name.LastIndexOf("."));
        else
            fileName = fileInfo.Name;

        fileLocation = fileInfo.DirectoryName;
        fileExtension = fileInfo.Extension;
        ReadFile();
    }

    void ReadFile()
    {
        int longestThisFIle = -1;
        foreach(var line in File.ReadAllLines(fileInfo.FullName))
        {
            int currentLineLen = line.Length;
            if(currentLineLen > longestThisFIle)
                longestThisFIle = currentLineLen;

            totalLinesOfCode++;
            totalCharacterCount += currentLineLen;
        }
        longestLineOfCode = longestThisFIle;
    }
}