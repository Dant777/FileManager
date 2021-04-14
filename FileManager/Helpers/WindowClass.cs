using System;
using System.IO;
using System.Collections.Generic;
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

        private string _selectedRoot = "Disks";

        private List<string> _selectedDir;
        private List<string> _selectedDirName;

        private CountControllerInWin _indexController;

        public WindowClass( )
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            Console.WindowHeight = WINDOW_HEIGHT;
            Console.SetBufferSize(Console.WindowWidth, WINDOW_HEIGHT);
            Console.SetWindowSize(Console.WindowWidth, WINDOW_HEIGHT);

            _selectedDir = FDWorker.GetDirectory("");
            _selectedDirName = FDWorker.GetDirectoryNames("");

            _indexController = new CountControllerInWin();
            _indexController.StartIndex = 0;
            _indexController.EndIndex = MAX_NUMBER_FILE_NAMES;

        }

        public void StartFMWindows()
        {
            while (_isWork)
            {
                CreateFileManagerWindow();
                CreateInfoWindow();
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
            DrawingClass.PrintSquareDoubelLine(0, (Console.WindowHeight / 2 ), Console.WindowWidth, Console.WindowHeight / 3);
            WaitForInput();
        }

        /// <summary>
        /// Ввод команд от пользователя
        /// </summary>
        private void WaitForInput()
        {
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
                    PressEnter();
                    break;
                case ConsoleKey.F4:
                    DeleteFileOrDir();
                    break;
                case ConsoleKey.F5:
                    _isWork = false;
                    break;
            }
        }

        private void DeleteFileOrDir()
        {
            
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
        }
    }
}
