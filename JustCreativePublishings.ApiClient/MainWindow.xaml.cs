using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using JustCreativePublishings.ApiClient.Models;
using JustCreativePublishings.Domain.Entities;

namespace JustCreativePublishings.ApiClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HttpClient client = new HttpClient();
        Posts posts = new Posts();

        public MainWindow()
        {
            InitializeComponent();

            client.BaseAddress = new Uri("http://localhost:30532");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            this.PostsList.ItemsSource = posts;
        }

        private async void GetPosts(object sender, RoutedEventArgs e)
        {
            try
            {
                GetPostsButton.IsEnabled = false;

                var response = await client.GetAsync("api/postapi");
                response.EnsureSuccessStatusCode();

                var postsApi = await response.Content.ReadAsAsync<IEnumerable<Post>>();
                posts.CopyFrom(postsApi);
            }
            catch (Newtonsoft.Json.JsonException jsonException)
            {
                MessageBox.Show(jsonException.Message);
            }
            catch (HttpRequestException requestException)
            {
                MessageBox.Show(requestException.Message);
            }
            finally
            {
                GetPostsButton.IsEnabled = true;
            }
        }

        private void AddPost(object sender, RoutedEventArgs e)
        {
            var addPost = new AddPost();
            addPost.ShowDialog();
        }

        private async void GetOnePost(object sender, RoutedEventArgs e)
        {
            var addPost = new AddPost();
            try
            {
                var response = await client.GetAsync("api/postapi/" + PostId.Text);
                var post = await response.Content.ReadAsAsync<Post>();
                if (post != null)
                {
                    addPost.TitleTextBox.Text = post.Title;
                    addPost.DescriptionTextBox.Text = post.ShortDescription;
                    addPost.TagsTextBox.Text = String.Empty;
                    foreach (var tag in post.Tags)
                    {
                        addPost.TagsTextBox.Text += tag.Content + " ";
                    }
                    addPost.Chapter1TitleTextBox.Text = post.Chapters.ToList()[0].Title;
                    addPost.Chapter1DescriptionTextBox.Text = post.Chapters.ToList()[0].Content;
                    addPost.Chapter2TitleTextBox.Text = post.Chapters.ToList()[1].Title;
                    addPost.Chapter2DescriptionTextBox.Text = post.Chapters.ToList()[1].Content;
                    addPost.Id.Text = PostId.Text;
                    addPost.SendButton.Content = "Update";
                    addPost.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Error ID");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void DeleteRequest(object sender, RoutedEventArgs e)
        {
            try
            {
                var response = await client.DeleteAsync(client.BaseAddress + "/api/postapi/" + PostId.Text);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Deleted");
                }
                else
                {
                    MessageBox.Show("Error Occured");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
