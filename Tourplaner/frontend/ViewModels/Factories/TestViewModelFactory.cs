namespace frontend.ViewModels.Factories
{
    public class TestViewModelFactory : IViewModelFactory<TestViewModel>
    {
        public TestViewModel CreateViewModel()
        {
            return new TestViewModel();
        }
    }
}