using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JustCreativePublishings.Domain.Entities;

namespace JustCreativePublishings.ApiClient.Models
{
    public class Posts : ObservableCollection<Post>
    {
        public void CopyFrom(IEnumerable<Post> posts)
        {
            this.Items.Clear();
            foreach (var post in posts)
            {
                this.Items.Add(post);
            }
            this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
    }
}
