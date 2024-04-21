namespace PowerCalculator
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new AppShell();
        }

        protected override Window CreateWindow(IActivationState activationState) =>
        new Window(new AppShell())
        {
            Width = 500,
            Height = 700,
            X = 650,
            Y = 200
        };
    }
}
