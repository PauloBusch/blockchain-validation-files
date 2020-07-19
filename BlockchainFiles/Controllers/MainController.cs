using BlockchainFiles.Interfaces;

namespace BlockchainFiles.Controllers
{
    public class MainController
    {
        private IMainView _view;
        public void SetView(IMainView view) => _view = view;

        public MainController() { }
    }
}
