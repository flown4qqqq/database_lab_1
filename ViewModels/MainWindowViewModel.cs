using System.Collections.Generic;
using System.Reactive;
using ReactiveUI;

namespace dblaba.ViewModels {
    public class MainWindowViewModel : ViewModelBase
    {
        Stack<SubViewModel> contentStack;
        SubViewModel content;

        public MainWindowViewModel()
        {
            contentStack = new Stack<SubViewModel>();
            // AddView(new MainMenuViewModel());
        }
        public void AddView(SubViewModel view)
        {
            contentStack.Push(view);
            Content = view;
        }

        public void RemoveTopView()
        {
            contentStack.Pop();
            Content = contentStack.Peek();
        }

        public SubViewModel Content
        {
            get => content;
            private set => this.RaiseAndSetIfChanged(ref content, value);
        }
    }
}
