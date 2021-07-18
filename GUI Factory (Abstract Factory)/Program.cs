using System;

namespace GUI_Factory__Abstract_Factory_
{
    interface IButton
    {
        bool hasCorner();
        bool isEnable();
    }

    class WinButton : IButton
    {
        public WinButton()
        {
            Console.WriteLine("WinButton");
        }
        public bool hasCorner()
        {
            return true;
        }

        public bool isEnable()
        {
            return false;
        }
    }

    class MacButton : IButton
    {
        public MacButton()
        {
            Console.WriteLine("MacButton");
        }
        public bool hasCorner()
        {
            return true;
        }

        public bool isEnable()
        {
            return true;
        }
    }

    class LinuxButton : IButton
    {
        public LinuxButton()
        {
            Console.WriteLine("LinuxButton");
        }
        public bool hasCorner()
        {
            return true;
        }

        public bool isEnable()
        {
            return true;
        }
    }

    interface ICheckbox
    {
        bool isList();
        bool isEnable();
    }

    class WinCheckBox : ICheckbox
    {
        public WinCheckBox()
        {
            Console.WriteLine("WinCheckBox");
        }

        public bool isEnable()
        {
            return true;
        }

        public bool isList()
        {
            return false;
        }
    }

    class MacCheckBox : ICheckbox
    {
        public MacCheckBox()
        {
            Console.WriteLine("MacCheckBox");
        }

        public bool isEnable()
        {
            return false;
        }

        public bool isList()
        {
            return true;
        }
    }

    class LinuxCheckBox : ICheckbox
    {
        public LinuxCheckBox()
        {
            Console.WriteLine("LinuxCheckBox");
        }

        public bool isEnable()
        {
            return true;
        }

        public bool isList()
        {
            return true;
        }
    }

    interface IGUIFactory
    {
        ICheckbox createCheckbox();
        IButton createButton();
    }

    class WinFactory : IGUIFactory
    {
        public IButton createButton()
        {
            return new WinButton();
        }

        public ICheckbox createCheckbox()
        {
            return new WinCheckBox();
        }
    }

    class MacFactory : IGUIFactory
    {
        public IButton createButton()
        {
            return new MacButton();
        }

        public ICheckbox createCheckbox()
        {
            return new MacCheckBox();
        }
    }

    class LinuxFactory : IGUIFactory
    {
        public IButton createButton()
        {
            return new LinuxButton();
        }

        public ICheckbox createCheckbox()
        {
            return new LinuxCheckBox();
        }
    }


    class Application
    {
        IGUIFactory gUIFactory;


        public Application()
        {
            
        }
        public Application(IGUIFactory f)
        {
    

            gUIFactory = f;

        }

        public  void createUI()
        {

            Console.Write(" \n for button ->1 for checkbox ->2 : ");
            int select = int.Parse(Console.ReadLine());

            Console.WriteLine();

            if (select == 1)
            {
         
                var ui = gUIFactory.createButton();

                Console.WriteLine($"\n hasCorner: {ui.hasCorner()}");
                Console.WriteLine($" isEnable: {ui.isEnable()} \n");


            }

            if(select==2)
            {
          
                var ui = gUIFactory.createCheckbox();

                Console.WriteLine($"\n hasCorner: {ui.isList()}");
                Console.WriteLine($" isEnable: {ui.isEnable()} \n");

            }
        }

        public  void paint()
        {
           
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Painting");
                Console.BackgroundColor = ConsoleColor.Black;
            
        }
    }






    class Program
    {
        static void Main(string[] args)
        {


            IGUIFactory gUIFactory;


            while (true)
            {
                Console.Write(" \n for Windows ->1 for Mac ->2 for Linux ->3 : ");
                int select = int.Parse(Console.ReadLine());

         

                if (select == 1)
                {
                    gUIFactory = new WinFactory();
                    Application application = new Application(gUIFactory);

                    application.createUI();
                    application.paint();
                }

                if (select == 2)
                {
                    gUIFactory = new MacFactory();
                    Application application = new Application(gUIFactory);

                    application.createUI();
                    application.paint();
                }

                if (select == 3)
                {
                    gUIFactory = new LinuxFactory();
                    Application application = new Application(gUIFactory);

                    application.createUI();
                    application.paint();
                }
            }

        }
    } 
}
