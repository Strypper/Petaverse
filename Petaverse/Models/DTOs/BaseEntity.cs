using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PetaVerse.Models.DTOs
{
    public class BaseEntity : ObservableRecipient
    {
        public virtual int Id { get; set; }
    }
}
