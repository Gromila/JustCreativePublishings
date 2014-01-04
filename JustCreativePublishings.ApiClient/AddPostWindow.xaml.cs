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
using System.Windows.Shapes;
using JustCreativePublishings.ApiClient.Models;
using JustCreativePublishings.Domain.Entities;

namespace JustCreativePublishings.ApiClient
{
    /// <summary>
    /// Interaction logic for AddPost.xaml
    /// </summary>
    public partial class AddPost : Window
    {
        private HttpClient client = new HttpClient();

        public AddPost()
        {
            InitializeComponent();

            client.BaseAddress = new Uri("http://localhost:30532");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private async void SendRequest(object sender, RoutedEventArgs e)
        {
            SendButton.IsEnabled = false;

            try
            {
                var post = new Post
                {
                    Title = TitleTextBox.Text,
                    ShortDescription = DescriptionTextBox.Text,
                    IsPublished = true,
                    LastUpdateDate = DateTime.Now,
                    Chapters =
                        new List<Chapter>
                        {
                            new Chapter()
                            {
                                Content = Chapter1DescriptionTextBox.Text,
                                Title = Chapter1DescriptionTextBox.Text,
                                OrderNumber = 1
                            },
                            new Chapter()
                            {
                                Content = Chapter2DescriptionTextBox.Text,
                                Title = Chapter2DescriptionTextBox.Text,
                                OrderNumber = 2
                            }
                        },
                    Tags = new List<Tag>(),
                    UserId = "d3e00cd2-a222-4c80-acfd-529126977683"
                };
                foreach (var tag in TagsTextBox.Text.Split(new char[] {',', ' '}))
                {
                    post.Tags.Add(new Tag() {Content = tag});
                }
                var response = await client.PostAsJsonAsync("api/postapi", post);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Close();
            }
        }

        private async void UpdateRequest(object sender, RoutedEventArgs e)
        {
            SendButton.IsEnabled = false;
            try
            {
                var post = new Post
                {
                    Title = TitleTextBox.Text,
                    ShortDescription = DescriptionTextBox.Text,
                    IsPublished = true,
                    LastUpdateDate = DateTime.Now,
                    Chapters =
                        new List<Chapter>
                        {
                            new Chapter()
                            {
                                Content = Chapter1DescriptionTextBox.Text,
                                Title = Chapter1DescriptionTextBox.Text,
                                OrderNumber = 1
                            },
                            new Chapter()
                            {
                                Content = Chapter2DescriptionTextBox.Text,
                                Title = Chapter2DescriptionTextBox.Text,
                                OrderNumber = 2
                            }
                        },
                    Tags = new List<Tag>(),
                    UserId = "d3e00cd2-a222-4c80-acfd-529126977683"
                };
                foreach (var tag in TagsTextBox.Text.Split(new char[] {',', ' '}))
                {
                    post.Tags.Add(new Tag() {Content = tag});
                }

                var response = await client.PutAsJsonAsync(client.BaseAddress + "/api/postapi/" + Id.Text, post);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Updated");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (SendButton.Content == "Update")
            {
                SendButton.Click -= SendRequest;
                SendButton.Click += UpdateRequest;
            }
        }
    }
}
