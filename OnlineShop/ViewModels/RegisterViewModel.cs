using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace OnlineShop.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "وارد  کردن {0} اجباری است ")]
        [Display(Name = "نام کاربری")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "وارد  کردن {0} اجباری است ")]
        [DataType(DataType.Password)]
        [Display(Name = "رمز عبور")]
        [StringLength(50, ErrorMessage = "کلمه عبور حداقل 8 کاراکتور باشد. ", MinimumLength = 8)]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "تکرار پسورد اشتباه است")]
        [DataType(DataType.Password)]
        [Display(Name = "تکرار رمز عبور")]
        public string ConfirmPassword { get; set; }
    }
}
