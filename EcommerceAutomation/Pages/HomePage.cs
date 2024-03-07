using EcommerceAutomation.Pages.Forms;

namespace EcommerceAutomation.Pages;

public class HomePage : WebPage<HomePage>
{
    public SearchForm SearchForm => SearchForm.Instance;
}