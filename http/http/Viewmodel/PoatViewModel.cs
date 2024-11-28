using CommunityToolkit.Mvvm.ComponentModel;
using http.Models;
using http.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace http.Viewmodel
{
    public partial class PoatViewModel : ObservableObject 
    {
        [ObservableProperty]
        ObservableCollection<Post> posts;
        PostService postsService;

        public ICommand getPostagensCommand { get; }

        public PoatViewModel()
        {
            getPostagensCommand = new Command(getPostagens);
            postsService = new PostService();

        }
        public async void getPostagens()
        {
            PostService postsService = new PostService();
            posts = await postsService.GetPostAsync();

        }
    }
}
