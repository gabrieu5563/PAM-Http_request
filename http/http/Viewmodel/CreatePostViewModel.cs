using CommunityToolkit.Mvvm.ComponentModel;
using http.Models;
using http.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace http.Viewmodel;

	public partial class CreatePostViewModel : ObservableObject
	{
		[ObservableProperty]
		string title;
        [ObservableProperty]
        string body;
        [ObservableProperty]
        int id;
        [ObservableProperty]
        int userId = 1;

        public ICommand SavePostCommand { get; }

        CreatePostViewModel()
        {
        SavePostCommand = new Command(SavePost);
        }

        public async void SavePost()
        {
           Post post = new Post();
           Post newPost = new Post();
           post.Title = title;
           post.Body = body;
           post.Id = id;



           PostService postService = new PostService();
           newPost = await postService.SavePostAsync(post);
        }
	};

	
