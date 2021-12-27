namespace HTMLHelperExamples.Models
{
    public class CatSubCatViewModel
    {
        public CategoryModel Cm { get; set; } = new CategoryModel();

        public SubCategoryModel Scm { get; set; } = new SubCategoryModel();

        public Gender Gender { get; set; } = new Gender();

        public string SelectedGender { set; get; }
    }
}
