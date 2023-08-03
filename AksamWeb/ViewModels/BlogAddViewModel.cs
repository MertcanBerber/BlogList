using System.ComponentModel.DataAnnotations;

namespace AksamWeb.ViewModels
{
    public class BlogAddViewModel
    {

        [Display(Name ="Blog Başlığı",Prompt ="Blog Başlığını Giriniz...")]
        [Required(ErrorMessage ="Title boş bırakılırmı hacı...")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Açıklama boş bırakılırmı hacı...")]
        [Display(Name ="Açıklama")]
        public string Description { get; set; }
        [Required(ErrorMessage = "İçerik boş bırakılırmı hacı...")]
        [Display(Name ="İçerik")]
        [MinLength(25,ErrorMessage ="25 karakterden az içerik hangi makalede gördün ? ")]
        public string Content { get; set; }
    }
}
