using FileManagerApp.src.Models;

namespace FileManagerApp.src.Controllers
{
    public class FileController
    {
        private readonly FileModel _model;
        public FileController()
        {
            _model = new FileModel();
        }


        public void OpenFile(string filePath)
        {
            _model.FilePath = filePath;
            _model.ReadFile();
        }


        public void SaveFile()
        {
            _model.SaveFile();
        }

        public void CreateFile(string filePath, string content)
        {
            _model.FilePath = filePath;
            _model.Content = content;
            _model.CreateFile();
        }

        public void DeleteFile(string filePath)
        {
            _model.FilePath = filePath;
            _model.DeleteFile();
        }

        public string GetFileContent()
        {
            return _model.Content;
        }

        public void SetFileContent(string content)
        {
            _model.Content = content;
        }


    }
}