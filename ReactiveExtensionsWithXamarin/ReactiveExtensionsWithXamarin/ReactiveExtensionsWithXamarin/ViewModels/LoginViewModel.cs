using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactiveExtensionsWithXamarin.Core.ViewModels
{
    public class LoginViewModel : ReactiveObject, IRoutableViewModel
    {
        public string UrlPathSegment => "ReactiveUI with Xamarin!";
        public IScreen HostScreen { get; protected set; }

        string _userName;
        public string Username
        {
            get { return _userName; }
            set { this.RaiseAndSetIfChanged(ref _userName, value); }
        }

        string _password;
        public string Password
        {
            get { return _password; }
            set { this.RaiseAndSetIfChanged(ref _password, value); }
        }

        public ReactiveCommand LoginCommand { get; set; }

        //ObservableAsPropertyHelper is helper class which enables ViewModel implement output properties
        //which are backed by an Observable so in this case by _isLoading

        ObservableAsPropertyHelper<bool> _isLoading;
        public bool IsLoading
        {
            get { return _isLoading?.Value ?? false; }
        }

        //ObservableAsPropertyHelper is helper class which enables ViewModel implement output properties
        //which are backed by an Observable so in this case by _isValid

        ObservableAsPropertyHelper<bool> _isValid;
        public bool IsValid
        {
            get { return _isValid?.Value ?? false; }
        }

        public LoginViewModel()
        {
            HostScreen = Locator.Current.GetService<IScreen>();
            PrepareObservables();
        }

        private void PrepareObservables()
        {
            //When any value is provided in Username or Password field
            //Check if these value is not empty or null and additionally check the length for password
           
            this.WhenAnyValue(e => e.Username, p => p.Password,
                  (emailAddress, password) => (!string.IsNullOrEmpty(emailAddress)) && !string.IsNullOrEmpty(password) && password.Length > 6)
                 .ToProperty(this, v => v.IsValid, out _isValid);

            //When any value is provided to IsLoading property and IsValid property
            //Check if IsLoading is not already started AND if IsValid property is true
            //If condition is fulfilled canExecuteLogin observable is set to true
            var canExecuteLogin =
            this.WhenAnyValue(x => x.IsLoading, x => x.IsValid,
                (isLoading, IsValid) => !isLoading && IsValid);


            //Create LoginCommand that will handle async operation - in this case fake web service call
            //If command is invoked, create new Random instance and delay Task
            //Once Task is finished, use HostScreen.Router property to navigate to the next ViewModel
            //LoginCommand can be executed only when canExecuteLogin property is set to true
            LoginCommand = ReactiveCommand.CreateFromTask(
                async execute =>
                {
                    var random = new Random();
                    await Task.Delay(random.Next(400, 2000));
                    HostScreen.Router.Navigate.Execute(new CarsListViewModel()).Subscribe();
                }, canExecuteLogin);

            //When LoginCommand is being executed, change IsLoading propety to true
            //This will make ActivityIndicator show on LoginPage
            //ToProperty method converts Observable to ObservableAsPropertyHelper and automatically raise property changed event

            this.WhenAnyObservable(x => x.LoginCommand.IsExecuting)
                .StartWith(false)
                .ToProperty(this, x => x.IsLoading, out _isLoading);
        }
    }
}
