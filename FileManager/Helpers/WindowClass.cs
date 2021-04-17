using System;
using System.IO;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FileManager
{
    public class WindowClass
    {
        private const int START_WINDOW_COORD_X = 0;
        private const int START_WINDOW_COORD_Y = 0;
        private const int MAX_NUMBER_FILE_NAMES = 17;
        private const int WINDOW_HEIGHT = 40;
        private int _itemDirIndex = 0;

        private bool _isWork = true;
        private bool _canClearInfo = true;

        private string _selectedRoot = "Disks";
        private string _txtInfo = $"Hello FM v.{Assembly.GetExecutingAssembly().GetName().Version}";
        private string _soursePath = string.Empty;
        private string _destPath = string.Empty;

        private List<string> _selectedDir;
        private List<string> _selectedDirName;
        private List<string> _listInfo;

        private CountControllerInWin _indexController;

        private SettingWorkerJson _settingWorker;
        private AppSettingClass _appSetting;

        public WindowClass( )
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            Console.WindowHeight = WINDOW_HEIGHT;
            Console.SetBufferSize(Console.WindowWidth, WINDOW_HEIGHT);
            Console.SetWindowSize(Console.WindowWidth, WINDOW_HEIGHT);

            _settingWorker = new SettingWorkerJson();
            _appSetting = _settingWorker.ReadJsonSetting();

            _selectedDir = FDWorker.GetDirectory(_appSetting.LastPath);
            _selectedDirName = FDWorker.GetDirectoryNames(_appSetting.LastPath);
            _listInfo = new List<string> { _txtInfo };

            _indexController = new CountControllerInWin();
            _indexController.StartIndex = 0;
            _indexController.EndIndex = MAX_NUMBER_FILE_NAMES;
        }

        public void StartFMWindows()
        {
            while (_isWork)
            {
                CreateFileManagerWindow();
                DrawingClass.PrintButtons(0, 35);
                CreateInfoWindow();
                try
                {
                
                    
                
                }
                catch (Exception e)
                {

                    ExceptionWriter.Write(e.Message);
                    _isWork = false;
                }
            }

        }

        /// <summary>
        /// Основное окно ФМ
        /// </summary>
        private void CreateFileManagerWindow()
        {
           
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            DrawingClass.PrintSquareDoubelLine(START_WINDOW_COORD_X, START_WINDOW_COORD_Y, Console.WindowWidth, Console.WindowHeight / 2, _selectedRoot);

            DrawingClass.PrintFileOrDir(START_WINDOW_COORD_X + 1, START_WINDOW_COORD_Y + 1, _selectedDirName, _itemDirIndex, _indexController);

            

        }

        /// <summary>
        /// Создание окна с информацией
        /// </summary>
        private void CreateInfoWindow()
        {

            DrawingClass.PrintSquareDoubelLine(0, Console.WindowHeight / 2, Console.WindowWidth, Console.WindowHeight / 3);
            DrawingClass.PrintList(START_WINDOW_COORD_X + 1, (Console.WindowHeight / 2) + 1, _listInfo);
            WaitForInput();
        }

        /// <summary>
        /// Ввод команд от пользователя
        /// </summary>
        private void WaitForInput()
        {
            if (_canClearInfo)
            {
                SetStrFieldsEmpty();
            }
            ConsoleKeyInfo cki = Console.ReadKey();
            switch (cki.Key)
            {
                case ConsoleKey.DownArrow:
                    MoveDown();
                    break;
                case ConsoleKey.UpArrow:
                    MoveUp();
                    break;
                case ConsoleKey.Enter:
                    _appSetting.LastPath = _selectedDir[_itemDirIndex];
                    PressEnter();
                    break;
                case ConsoleKey.F1:
                    GetInfoFileOrDir();
                    break;
                case ConsoleKey.F2:
                    MoveDirOrFile(_selectedDir[_itemDirIndex]);
                    break;
                case ConsoleKey.F3:
                    CopyDirOrFile(_selectedDir[_itemDirIndex]);
                    break;
                case ConsoleKey.F4:
                    DeleteFileOrDir();
                    break;
                case ConsoleKey.F5:
                    _settingWorker.WriteSettingInFile(_appSetting);
                    _isWork = false;
                    break;
                case ConsoleKey.F8:
                    throw new ArgumentException("Это искуственная ошибка");
                    break;
                case ConsoleKey.Escape:
                    _canClearInfo = true;
                    UpdateDir();
                    break;
            }
        }
        /// <summary>
        /// Информация о папке/файле
        /// </summary>
        private void GetInfoFileOrDir()
        {
            _listInfo.AddRange(FDWorker.InfoFileOrDirectory(_selectedDir[_itemDirIndex]));
            
        }
        /// <summary>
        /// Удаление файла/папки
        /// </summary>
        private void DeleteFileOrDir()
        {
            SetStrFieldsEmpty();
            FDWorker.DeleteFileOrDirectory(_selectedDir[_itemDirIndex]);
            UpdateDir();
        }

        /// <summary>
        /// Обработка нажатия вверх
        /// </summary>
        private void MoveDown()
        {
            if (_selectedDir.Count == 1)
            {
                _itemDirIndex = 0;
            }
            else
            {
                _itemDirIndex = _itemDirIndex == _selectedDir.Count - 1 ? 0 : _itemDirIndex + 1;
                
            }

            if (_itemDirIndex == 0)
            {
                _indexController.StartIndex = 0;
                _indexController.EndIndex = MAX_NUMBER_FILE_NAMES;
            }
            else if (_itemDirIndex > _indexController.EndIndex)
            {
                _indexController.StartIndex++;
                _indexController.EndIndex++;
            }


            if (_selectedRoot == "")
            {
                _selectedRoot = "Discks";
            }
            else
            {
                _selectedRoot = Directory.GetDirectoryRoot(_selectedRoot);
            }
        }

        /// <summary>
        /// Обработка нажатия вниз
        /// </summary>
        private void MoveUp()
        {
            if(_selectedDir.Count == 1)
            {
                _itemDirIndex = 0;
            }
            else
            {
                _itemDirIndex = _itemDirIndex == 0 ? _selectedDir.Count - 1 : _itemDirIndex - 1;
            }

            if (_itemDirIndex == _selectedDir.Count - 1 && _selectedDir.Count - 1 > MAX_NUMBER_FILE_NAMES)
            {
                _indexController.StartIndex = (_selectedDir.Count - 1) - MAX_NUMBER_FILE_NAMES;
                _indexController.EndIndex = _selectedDir.Count - 1;
            }
            else if (_itemDirIndex < _indexController.StartIndex)
            {
                _indexController.StartIndex--;
                _indexController.EndIndex--;
            }

            if (_selectedRoot == "")
            {
                _selectedRoot = "Discks";
            }
            else
            {
                _selectedRoot = Directory.GetDirectoryRoot(_selectedRoot);
            }

        }
       
        /// <summary>
        /// Обработка нажатия Enter
        /// </summary>
        private void PressEnter()
        {
            
            _selectedRoot = _selectedDir[_itemDirIndex];
            _selectedDir = FDWorker.GetDirectory(_selectedRoot);
            _selectedDirName = FDWorker.GetDirectoryNames(_selectedRoot);

            _itemDirIndex = 0;
            _indexController.StartIndex = 0;
            _indexController.EndIndex = MAX_NUMBER_FILE_NAMES;

            if (_selectedRoot == "")
            {
                _selectedRoot = "Discks";
            }
            else
            {
                _selectedRoot = Directory.GetDirectoryRoot(_selectedRoot);
            }


        }

        /// <summary>
        /// Обновление окна
        /// </summary>
        private void UpdateDir()
        {
            _selectedRoot = Directory.GetParent(_selectedDir[_itemDirIndex]).FullName; ;
            _selectedDir = FDWorker.GetDirectory(_selectedRoot);
            _selectedDirName = FDWorker.GetDirectoryNames(_selectedRoot);

            _itemDirIndex = 0;
            _indexController.StartIndex = 0;
            _indexController.EndIndex = MAX_NUMBER_FILE_NAMES;

            if (_selectedRoot == "")
            {
                _selectedRoot = "Discks";
            }
            else
            {
                _selectedRoot = Directory.GetDirectoryRoot(_selectedRoot);
            }

            SetStrFieldsEmpty();
        }
       
        /// <summary>
        /// Перемещение файла/папки в два клика
        /// </summary>
        /// <param name="path"></param>
        private void MoveDirOrFile(string path)
        {
            _canClearInfo = false;
            if (_soursePath == string.Empty)
            {
                _soursePath = path;
            }
            else
            {
                string dirName = string.Empty;
                string copyFullDirName = string.Empty;

                if (!File.Exists(_soursePath))
                {
                    DirectoryInfo dir = new DirectoryInfo(_soursePath);
                    dirName = dir.Name;
                    
                }
                

                if (File.Exists(path))
                {
                    copyFullDirName = Path.GetDirectoryName(path) + "\\" + dirName;
                    _destPath = copyFullDirName;
                }
                else
                {
                    copyFullDirName = path + "\\" + dirName;
                    _destPath = copyFullDirName;
                }
                
            }

            _listInfo.Add($"Переместить {_soursePath} в ... *Еще раз F2 для перемещение в директорию*");

            if (_soursePath != string.Empty && _destPath != string.Empty)
            {
                FDWorker.MoveFileOrDirectory(_soursePath, _destPath);
                UpdateDir();
                _canClearInfo = true;
            }

        }
        
        /// <summary>
        /// Копирование файла/папки в два клика
        /// </summary>
        /// <param name="path"></param>
        private void CopyDirOrFile(string path)
        {
            _canClearInfo = false;
            if (_soursePath == string.Empty)
            {
                _soursePath = path;
            }
            else
            {
                string dirName = string.Empty;
                string copyFullDirName = string.Empty;

                if (!File.Exists(_soursePath))
                {
                    DirectoryInfo dir = new DirectoryInfo(_soursePath);
                    dirName = dir.Name;

                }


                if (File.Exists(path))
                {
                    copyFullDirName = Path.GetDirectoryName(path) + "\\" + dirName;
                    _destPath = copyFullDirName;
                }
                else
                {
                    copyFullDirName = path + "\\" + dirName;
                    _destPath = copyFullDirName;
                }

            }

            _listInfo.Add($"Копировать {_soursePath} в ... *Еще раз F3 для копировать в директорию*");

            if (_soursePath != string.Empty && _destPath != string.Empty)
            {
                FDWorker.CopyFileOrDirectory(_soursePath, _destPath);
                UpdateDir();
                _canClearInfo = true;
            }

        }

        /// <summary>
        /// Очищает информационные поля
        /// </summary>
        private void SetStrFieldsEmpty()
        {
            _soursePath = string.Empty;
            _destPath = string.Empty;
            _listInfo.RemoveRange(1, _listInfo.Count - 1);
        }
    }
}
